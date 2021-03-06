﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Netcool.Api.Domain.EfCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Netcool.Api.Domain.Migrations
{
    [DbContext(typeof(NetcoolDbContext))]
    [Migration("20200216095657_ChangeMenuRoute")]
    partial class ChangeMenuRoute
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Netcool.Api.Domain.Configuration.AppConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("create_user_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnName("delete_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeleteUserId")
                        .HasColumnName("delete_user_id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnName("type")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("update_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnName("update_user_id")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_app_configurations");

                    b.ToTable("app_configurations");
                });

            modelBuilder.Entity("Netcool.Api.Domain.Menus.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'1000', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("create_user_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnName("delete_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeleteUserId")
                        .HasColumnName("delete_user_id")
                        .HasColumnType("integer");

                    b.Property<string>("DisplayName")
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .HasColumnName("icon")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Level")
                        .HasColumnName("level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnName("order")
                        .HasColumnType("integer");

                    b.Property<int>("ParentId")
                        .HasColumnName("parent_id")
                        .HasColumnType("integer");

                    b.Property<string>("Path")
                        .HasColumnName("path")
                        .HasColumnType("text");

                    b.Property<string>("Route")
                        .HasColumnName("route")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnName("type")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("update_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnName("update_user_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_menus");

                    b.ToTable("menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayName = "首页",
                            Icon = "home",
                            IsDeleted = false,
                            Level = 1,
                            Name = "dashboard",
                            Order = 1,
                            ParentId = 0,
                            Path = "/1",
                            Route = "/dashboard",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            DisplayName = "系统设置",
                            Icon = "setting",
                            IsDeleted = false,
                            Level = 1,
                            Name = "system",
                            Order = 2,
                            ParentId = 0,
                            Path = "/2",
                            Route = "/system",
                            Type = 0
                        },
                        new
                        {
                            Id = 20,
                            DisplayName = "应用配置",
                            Icon = "setting",
                            IsDeleted = false,
                            Level = 2,
                            Name = "app-configuration",
                            Order = 1,
                            ParentId = 2,
                            Path = "/2/20",
                            Route = "/app-configuration",
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            DisplayName = "权限管理",
                            Icon = "safety-certificate",
                            IsDeleted = false,
                            Level = 1,
                            Name = "auth",
                            Order = 3,
                            ParentId = 0,
                            Path = "/3",
                            Route = "/auth",
                            Type = 0
                        },
                        new
                        {
                            Id = 30,
                            DisplayName = "菜单管理",
                            Icon = "menu",
                            IsDeleted = false,
                            Level = 2,
                            Name = "menu",
                            Order = 1,
                            ParentId = 3,
                            Path = "/3/30",
                            Route = "/menu",
                            Type = 1
                        },
                        new
                        {
                            Id = 31,
                            DisplayName = "角色管理",
                            Icon = "usergroup-add",
                            IsDeleted = false,
                            Level = 2,
                            Name = "role",
                            Order = 2,
                            ParentId = 3,
                            Path = "/3/31",
                            Route = "/role",
                            Type = 1
                        },
                        new
                        {
                            Id = 32,
                            DisplayName = "用户管理",
                            Icon = "user",
                            IsDeleted = false,
                            Level = 2,
                            Name = "user",
                            Order = 3,
                            ParentId = 3,
                            Path = "/3/32",
                            Route = "/user",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Netcool.Api.Domain.Permissions.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'1000', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("create_user_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnName("delete_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeleteUserId")
                        .HasColumnName("delete_user_id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<int>("MenuId")
                        .HasColumnName("menu_id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnName("type")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("update_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnName("update_user_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_permissions");

                    b.HasIndex("MenuId")
                        .HasName("ix_permissions_menu_id");

                    b.ToTable("permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "home.view",
                            IsDeleted = false,
                            MenuId = 1,
                            Name = "首页",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Code = "system.view",
                            IsDeleted = false,
                            MenuId = 2,
                            Name = "系统",
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Code = "auth.view",
                            IsDeleted = false,
                            MenuId = 3,
                            Name = "权限",
                            Type = 0
                        },
                        new
                        {
                            Id = 20,
                            Code = "config.view",
                            IsDeleted = false,
                            MenuId = 20,
                            Name = "配置",
                            Type = 0
                        },
                        new
                        {
                            Id = 100,
                            Code = "config.update",
                            IsDeleted = false,
                            MenuId = 20,
                            Name = "配置修改",
                            Type = 1
                        },
                        new
                        {
                            Id = 30,
                            Code = "menu.view",
                            IsDeleted = false,
                            MenuId = 30,
                            Name = "菜单",
                            Type = 0
                        },
                        new
                        {
                            Id = 110,
                            Code = "menu.update",
                            IsDeleted = false,
                            MenuId = 30,
                            Name = "菜单修改",
                            Type = 1
                        },
                        new
                        {
                            Id = 31,
                            Code = "role.view",
                            IsDeleted = false,
                            MenuId = 31,
                            Name = "角色",
                            Type = 0
                        },
                        new
                        {
                            Id = 120,
                            Code = "role.create",
                            IsDeleted = false,
                            MenuId = 31,
                            Name = "角色新增",
                            Type = 1
                        },
                        new
                        {
                            Id = 121,
                            Code = "role.update",
                            IsDeleted = false,
                            MenuId = 31,
                            Name = "角色修改",
                            Type = 1
                        },
                        new
                        {
                            Id = 122,
                            Code = "role.delete",
                            IsDeleted = false,
                            MenuId = 31,
                            Name = "角色删除",
                            Type = 1
                        },
                        new
                        {
                            Id = 32,
                            Code = "user.view",
                            IsDeleted = false,
                            MenuId = 32,
                            Name = "用户",
                            Type = 0
                        },
                        new
                        {
                            Id = 130,
                            Code = "user.create",
                            IsDeleted = false,
                            MenuId = 32,
                            Name = "用户新增",
                            Type = 1
                        },
                        new
                        {
                            Id = 131,
                            Code = "user.update",
                            IsDeleted = false,
                            MenuId = 32,
                            Name = "用户修改",
                            Type = 1
                        },
                        new
                        {
                            Id = 132,
                            Code = "user.delete",
                            IsDeleted = false,
                            MenuId = 32,
                            Name = "用户删除",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Netcool.Api.Domain.Roles.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'1000', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("create_user_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnName("delete_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeleteUserId")
                        .HasColumnName("delete_user_id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("update_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnName("update_user_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "超级管理员"
                        });
                });

            modelBuilder.Entity("Netcool.Api.Domain.Roles.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'1000', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("create_user_id")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionId")
                        .HasColumnName("permission_id")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_role_permissions");

                    b.HasIndex("PermissionId")
                        .HasName("ix_role_permissions_permission_id");

                    b.HasIndex("RoleId")
                        .HasName("ix_role_permissions_role_id");

                    b.ToTable("role_permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PermissionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            PermissionId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            PermissionId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 20,
                            PermissionId = 20,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 100,
                            PermissionId = 100,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 30,
                            PermissionId = 30,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 110,
                            PermissionId = 110,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 31,
                            PermissionId = 31,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 120,
                            PermissionId = 120,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 121,
                            PermissionId = 121,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 122,
                            PermissionId = 122,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 32,
                            PermissionId = 32,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 130,
                            PermissionId = 130,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 131,
                            PermissionId = 131,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 132,
                            PermissionId = 132,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Netcool.Api.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'1000', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("create_user_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnName("delete_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeleteUserId")
                        .HasColumnName("delete_user_id")
                        .HasColumnType("integer");

                    b.Property<string>("DisplayName")
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnName("gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("update_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnName("update_user_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayName = "Admin",
                            Gender = 0,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "admin",
                            Password = "21232F297A57A5A743894A0E4A801FC3"
                        });
                });

            modelBuilder.Entity("Netcool.Api.Domain.Users.UserLoginAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BrowserInfo")
                        .HasColumnName("browser_info")
                        .HasColumnType("text");

                    b.Property<string>("ClientIp")
                        .HasColumnName("client_ip")
                        .HasColumnType("text");

                    b.Property<string>("ClientName")
                        .HasColumnName("client_name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("create_user_id")
                        .HasColumnType("integer");

                    b.Property<string>("LoginName")
                        .HasColumnName("login_name")
                        .HasColumnType("text");

                    b.Property<bool>("Success")
                        .HasColumnName("success")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_user_login_attempts");

                    b.ToTable("user_login_attempts");
                });

            modelBuilder.Entity("Netcool.Api.Domain.Users.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'1000', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("create_user_id")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_user_roles");

                    b.HasIndex("RoleId")
                        .HasName("ix_user_roles_role_id");

                    b.HasIndex("UserId")
                        .HasName("ix_user_roles_user_id");

                    b.ToTable("user_roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Netcool.Api.Domain.Permissions.Permission", b =>
                {
                    b.HasOne("Netcool.Api.Domain.Menus.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .HasConstraintName("fk_permissions_menus_menu_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Netcool.Api.Domain.Roles.RolePermission", b =>
                {
                    b.HasOne("Netcool.Api.Domain.Permissions.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .HasConstraintName("fk_role_permissions_permissions_permission_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Netcool.Api.Domain.Roles.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role_permissions_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Netcool.Api.Domain.Users.UserRole", b =>
                {
                    b.HasOne("Netcool.Api.Domain.Roles.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_user_roles_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Netcool.Api.Domain.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_roles_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
