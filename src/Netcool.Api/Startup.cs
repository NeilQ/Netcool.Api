using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Netcool.Api.Domain.Authorization;
using Netcool.Api.Domain.EfCore;
using Netcool.Api.Domain.Repositories;
using Netcool.Core;
using Netcool.Core.Authorization;
using Netcool.Core.Extensions;
using Netcool.Core.Repositories;
using Netcool.Core.Services;
using Netcool.Core.Sessions;
using Netcool.Core.WebApi;
using Netcool.Core.WebApi.Middlewares;
using Serilog;

[assembly: ApiController]

namespace Netcool.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<NetcoolDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Database"))
                    .UseSnakeCaseNamingConvention();
            });
            services.AddHealthChecks();

            // swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Netcool API", Version = "v1"});

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Netcool.Core.xml"));
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Netcool.Api.Domain.xml"));

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme,
                            },
                            Name = "Bearer"
                        },
                        new string[] { }
                    }
                });
            });

            // jwt
            var jwtOptions = new JwtOptions();
            var jwtSection = Configuration.GetSection("Jwt");
            jwtSection.Bind(jwtOptions);
            services.Configure<JwtOptions>(jwtSection);
            services.AddAuthentication(s =>
                {
                    s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    s.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret))
                    };

                    // We have to hook the OnMessageReceived event in order to
                    // allow the JWT authentication handler to read the access
                    // token from the query string when a WebSocket or 
                    // Server-Sent Events request comes in.
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        },
                    };
                });

            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // domain
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPermissionChecker, NullPermissionChecker>();
            services.AddScoped<IUserSession, UserSession>();
            services.AddScoped<IClientInfoProvider, HttpContextClientInfoProvider>();
            services.AddScoped(typeof(IRepository<>), typeof(CommonRepository<>));
            services.AddScoped(typeof(IRepository<,>), typeof(CommonRepository<,>));
            services.AddTransient<IServiceAggregator, ServiceAggregator>();
            services.AddDomainServiceTypes(Assembly.GetAssembly(typeof(NetcoolDbContext)), ServiceLifetime.Scoped);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseSerilogRequestLogging();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Netcool API V1"); });
        }
    }
}