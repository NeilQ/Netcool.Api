﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Netcool.Api.Domain.EfCore;
using Netcool.Core.AppSettings;
using Netcool.Core.Sessions;

namespace Netcool.Api.Domain.Configuration
{
    public class EfConfigurationProvider : ConfigurationProvider
    {
        public Action<DbContextOptionsBuilder> OptionsAction { get; }

        public EfConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<NetcoolDbContext>();

            OptionsAction(builder);

            using var dbContext = new NetcoolDbContext(builder.Options, NullUserSession.Instance);
            if (!dbContext.AppConfigurations.Any())
            {
                InitializeDefaultConfigurations(dbContext);
            }

            Data = dbContext.AppConfigurations.ToDictionary(c => c.Name, c => c.Value);
        }

        public static void InitializeDefaultConfigurations(NetcoolDbContext dbContext)
        {
            var configs = dbContext.AppConfigurations.ToList();
            if (configs.All(t => t.Name != "User:DefaultPassword"))
            {
                dbContext.AddRange(new AppConfiguration()
                {
                    Name = "User:DefaultPassword",
                    Value = "123456",
                    Type = AppConfigurationType.String,
                    Description = "默认用户密码"
                });
            }

            dbContext.SaveChanges();
        }
    }
}