﻿// <auto-generated />
using System;
using Microservice.Identity.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Microservice.Identity.Domain.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20220205125809_migration_v1.0")]
    partial class migration_v10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.LoginHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LoginType")
                        .HasColumnType("int");

                    b.Property<bool>("Succeed")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoginHistories");
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PermissionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Default Permission",
                            IsDeleted = false,
                            PermissionType = 1
                        },
                        new
                        {
                            Id = 2L,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Admin Permission",
                            IsDeleted = false,
                            PermissionType = 0
                        });
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.PermissionGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PermissionGroups");
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("PermissionGroupId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PermissionGroupId")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.SubscribedClient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("SubscribedClients");
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EmailConfirmedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPasswordExpired")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastPasswordUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PictureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.UserActionHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserActionHistories");
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.UserCommonToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<int>("TokenType")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserCommonTokens");
                });

            modelBuilder.Entity("PermissionPermissionGroup", b =>
                {
                    b.Property<long>("PermissionGroupsId")
                        .HasColumnType("bigint");

                    b.Property<long>("PermissionsId")
                        .HasColumnType("bigint");

                    b.HasKey("PermissionGroupsId", "PermissionsId");

                    b.HasIndex("PermissionsId");

                    b.ToTable("PermissionPermissionGroup");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<string>("RolesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.LoginHistory", b =>
                {
                    b.HasOne("Microservice.Identity.Domain.Entity.User", "User")
                        .WithMany("LoginHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.Role", b =>
                {
                    b.HasOne("Microservice.Identity.Domain.Entity.PermissionGroup", "PermissionGroup")
                        .WithOne("Role")
                        .HasForeignKey("Microservice.Identity.Domain.Entity.Role", "PermissionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionGroup");
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.UserActionHistory", b =>
                {
                    b.HasOne("Microservice.Identity.Domain.Entity.User", "User")
                        .WithMany("ActionHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.UserCommonToken", b =>
                {
                    b.HasOne("Microservice.Identity.Domain.Entity.User", "User")
                        .WithMany("CommonTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PermissionPermissionGroup", b =>
                {
                    b.HasOne("Microservice.Identity.Domain.Entity.PermissionGroup", null)
                        .WithMany()
                        .HasForeignKey("PermissionGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservice.Identity.Domain.Entity.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Microservice.Identity.Domain.Entity.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservice.Identity.Domain.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.PermissionGroup", b =>
                {
                    b.Navigation("Role")
                        .IsRequired();
                });

            modelBuilder.Entity("Microservice.Identity.Domain.Entity.User", b =>
                {
                    b.Navigation("ActionHistories");

                    b.Navigation("CommonTokens");

                    b.Navigation("LoginHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
