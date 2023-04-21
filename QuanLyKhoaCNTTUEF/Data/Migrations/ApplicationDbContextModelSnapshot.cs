﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKhoaCNTTUEF.Data;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d31d0e88-87a9-44a0-bfa9-75a0c21b92cb",
                            Name = "Administrator",
                            NormalizedName = "Administrator"
                        },
                        new
                        {
                            Id = "8a6a0983-3636-47ce-9765-3fba2a7afe49",
                            Name = "Manager",
                            NormalizedName = "Manager"
                        },
                        new
                        {
                            Id = "3d1269f2-cb75-4254-9b2c-f1a0115e1f31",
                            Name = "Teacher",
                            NormalizedName = "Teacher"
                        },
                        new
                        {
                            Id = "de0c4125-a09d-418f-b652-eccf49681ccb",
                            Name = "Staff",
                            NormalizedName = "Staff"
                        },
                        new
                        {
                            Id = "93283c08-dee5-44af-b151-eff73ad78d74",
                            Name = "Student",
                            NormalizedName = "Student"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UrlAvartar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            FirstName = "Trần",
                            LastName = "Thắng",
                            LockoutEnabled = true,
                            MiddleName = "Cao Minh",
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ",
                            TwoFactorEnabled = false,
                            UrlAvartar = "/img/Admin.png",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            FirstName = "Lê",
                            LastName = "Duyên",
                            LockoutEnabled = true,
                            MiddleName = "Thảo",
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ",
                            TwoFactorEnabled = false,
                            UrlAvartar = "/img/Duyen.png",
                            UserName = "user2@example.com"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e",
                            Email = "user4@example.com",
                            EmailConfirmed = true,
                            FirstName = "Lê",
                            LastName = "Đình",
                            LockoutEnabled = true,
                            MiddleName = "Ngọc Đình",
                            NormalizedEmail = "USER4@EXAMPLE.COM",
                            NormalizedUserName = "USER4@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ",
                            TwoFactorEnabled = false,
                            UrlAvartar = "/img/DinhDinh.png",
                            UserName = "user4@example.com"
                        },
                        new
                        {
                            Id = "5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e",
                            Email = "user5@example.com",
                            EmailConfirmed = true,
                            FirstName = "Nguyễn",
                            LastName = "Khoa",
                            LockoutEnabled = true,
                            MiddleName = "Tuấn",
                            NormalizedEmail = "USER5@EXAMPLE.COM",
                            NormalizedUserName = "USER5@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ",
                            TwoFactorEnabled = false,
                            UrlAvartar = "/img/Khoa.png",
                            UserName = "user5@example.com"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e",
                            Email = "user3@example.com",
                            EmailConfirmed = true,
                            FirstName = "Hồ",
                            LastName = "Khánh",
                            LockoutEnabled = true,
                            MiddleName = "Lâm Gia",
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER3@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ",
                            TwoFactorEnabled = false,
                            UrlAvartar = "/img/Khanh.png",
                            UserName = "user3@example.com"
                        });
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Event", b =>
                {
                    b.Property<int?>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("EventID"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PlanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCreate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserDelete")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserUpdate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("XoaTam")
                        .HasColumnType("int");

                    b.HasKey("EventID");

                    b.HasIndex("PlanID");

                    b.HasIndex("UserCreate");

                    b.HasIndex("UserDelete");

                    b.HasIndex("UserUpdate");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Files.PdfFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateUpload")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlanID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanID");

                    b.ToTable("PdfFile");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Group", b =>
                {
                    b.Property<int?>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("GroupID"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("EventID")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupID");

                    b.HasIndex("EventID");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.MembersGroups", b =>
                {
                    b.Property<int>("MemberGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberGroupID"), 1L, 1);

                    b.Property<int?>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MemberGroupID");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserID");

                    b.ToTable("MembersGroups");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Plan", b =>
                {
                    b.Property<int?>("PlanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PlanID"), 1L, 1);

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Approver")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlanName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PresenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Presenter")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PlanID");

                    b.HasIndex("Approver");

                    b.HasIndex("Presenter");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.TaskAssignments", b =>
                {
                    b.Property<int>("TaskAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskAssignmentId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberGroupID")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TaskID")
                        .HasColumnType("int");

                    b.HasKey("TaskAssignmentId");

                    b.HasIndex("MemberGroupID");

                    b.HasIndex("TaskID");

                    b.ToTable("Task_Assignments");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Tasks", b =>
                {
                    b.Property<int?>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("TaskID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EventID")
                        .HasColumnType("int");

                    b.Property<int?>("GroupID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TaskName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("TaskID");

                    b.HasIndex("EventID");

                    b.HasIndex("GroupID");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QuanLyKhoaCNTTUEF.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuanLyKhoaCNTTUEF.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoaCNTTUEF.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QuanLyKhoaCNTTUEF.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Event", b =>
                {
                    b.HasOne("QuanLyKhoaCNTTUEF.Models.Plan", "Plan")
                        .WithMany("Events")
                        .HasForeignKey("PlanID");

                    b.HasOne("QuanLyKhoaCNTTUEF.Data.ApplicationUser", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreate");

                    b.HasOne("QuanLyKhoaCNTTUEF.Data.ApplicationUser", "UserDeleted")
                        .WithMany()
                        .HasForeignKey("UserDelete");

                    b.HasOne("QuanLyKhoaCNTTUEF.Data.ApplicationUser", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdate");

                    b.Navigation("Plan");

                    b.Navigation("UserCreated");

                    b.Navigation("UserDeleted");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Files.PdfFile", b =>
                {
                    b.HasOne("QuanLyKhoaCNTTUEF.Models.Plan", "Plan")
                        .WithMany("PdfFiles")
                        .HasForeignKey("PlanID");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Group", b =>
                {
                    b.HasOne("QuanLyKhoaCNTTUEF.Models.Event", "Event")
                        .WithMany("Groups")
                        .HasForeignKey("EventID");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.MembersGroups", b =>
                {
                    b.HasOne("QuanLyKhoaCNTTUEF.Models.Group", "Group")
                        .WithMany("MembersGroups")
                        .HasForeignKey("GroupID");

                    b.HasOne("QuanLyKhoaCNTTUEF.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("MembersGroups")
                        .HasForeignKey("UserID");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Plan", b =>
                {
                    b.HasOne("QuanLyKhoaCNTTUEF.Data.ApplicationUser", "UserApprover")
                        .WithMany()
                        .HasForeignKey("Approver");

                    b.HasOne("QuanLyKhoaCNTTUEF.Data.ApplicationUser", "UserPresenter")
                        .WithMany()
                        .HasForeignKey("Presenter");

                    b.Navigation("UserApprover");

                    b.Navigation("UserPresenter");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.TaskAssignments", b =>
                {
                    b.HasOne("QuanLyKhoaCNTTUEF.Models.MembersGroups", "MembersGroups")
                        .WithMany()
                        .HasForeignKey("MemberGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoaCNTTUEF.Models.Tasks", "Tasks")
                        .WithMany()
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembersGroups");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Tasks", b =>
                {
                    b.HasOne("QuanLyKhoaCNTTUEF.Models.Event", "Event")
                        .WithMany("Tasks")
                        .HasForeignKey("EventID");

                    b.HasOne("QuanLyKhoaCNTTUEF.Models.Group", "Group")
                        .WithMany("Tasks")
                        .HasForeignKey("GroupID");

                    b.Navigation("Event");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Data.ApplicationUser", b =>
                {
                    b.Navigation("MembersGroups");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Event", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Group", b =>
                {
                    b.Navigation("MembersGroups");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Plan", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("PdfFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
