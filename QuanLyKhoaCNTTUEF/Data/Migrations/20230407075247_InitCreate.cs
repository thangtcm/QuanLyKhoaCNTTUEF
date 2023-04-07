﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UrlAvartar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    PlanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKeHoach = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NgayTrinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTrinh = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NguoiDuyet = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.PlanID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanID = table.Column<int>(type: "int", nullable: true),
                    TenSuKien = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    XoaTam = table.Column<int>(type: "int", nullable: false),
                    IDNguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDNguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDNguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_Plan_PlanID",
                        column: x => x.PlanID,
                        principalTable: "Plan",
                        principalColumn: "PlanID");
                });

            migrationBuilder.CreateTable(
                name: "PdfFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpload = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PdfFile_Plan_PlanID",
                        column: x => x.PlanID,
                        principalTable: "Plan",
                        principalColumn: "PlanID");
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: true),
                    TenNhom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupID);
                    table.ForeignKey(
                        name: "FK_Group_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateTable(
                name: "MembersGroups",
                columns: table => new
                {
                    MemberGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersGroups", x => x.MemberGroupID);
                    table.ForeignKey(
                        name: "FK_MembersGroups_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MembersGroups_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: true),
                    TaskName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Task_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID");
                    table.ForeignKey(
                        name: "FK_Task_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID");
                });

            migrationBuilder.CreateTable(
                name: "Task_Assignments",
                columns: table => new
                {
                    TaskAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    MemberGroupID = table.Column<int>(type: "int", nullable: true),
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Assignments", x => x.TaskAssignmentId);
                    table.ForeignKey(
                        name: "FK_Task_Assignments_MembersGroups_MemberGroupID",
                        column: x => x.MemberGroupID,
                        principalTable: "MembersGroups",
                        principalColumn: "MemberGroupID");
                    table.ForeignKey(
                        name: "FK_Task_Assignments_Task_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Task",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dda6baf-fee8-4ae5-9521-87ad43d9a203", "2c23e43d-284a-435b-a4cf-2bb0beced7a2", "Administrator", "Administrator" },
                    { "2c43480a-ea57-4493-8b7d-1185ad37243e", "5c2f2cf2-5d86-4a61-9036-85bb3a693c02", "Teacher", "Teacher" },
                    { "2de6fa80-cebf-40cd-aab8-0211c7f3cbf7", "aac807f8-6cc3-49b9-8b41-79aa5356a6c1", "Staff", "Staff" },
                    { "437cf6c5-d5aa-4e0e-8d17-92edf75faccc", "9a23bc88-abef-4045-8a6d-d0d4d14d568a", "Manager", "Manager" },
                    { "7335e6da-bc77-4e3a-88b0-fbd555f0e631", "91ad72fb-60bb-433e-ba8a-e46b97f4d389", "Student", "Student" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UrlAvartar", "UserName" },
                values: new object[,]
                {
                    { "1", 0, null, "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e", "user1@example.com", true, "Trần", "Thắng", true, null, "Cao Minh", "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==", null, false, "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ", false, "/img/Admin.png", "user1@example.com" },
                    { "2", 0, null, "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e", "user2@example.com", true, "Lê", "Duyên", true, null, "Thảo", "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==", null, false, "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ", false, "/img/Duyen.png", "user2@example.com" },
                    { "3", 0, null, "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e", "user3@example.com", true, "Hồ", "Khánh", true, null, "Lâm Gia", "USER2@EXAMPLE.COM", "USER3@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==", null, false, "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ", false, "/img/Khanh.png", "user3@example.com" },
                    { "4", 0, null, "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e", "user4@example.com", true, "Lê", "Đình", true, null, "Ngọc Đình", "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==", null, false, "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ", false, "/img/DinhDinh.png", "user4@example.com" },
                    { "5", 0, null, "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e", "user5@example.com", true, "Nguyễn", "Khoa", true, null, "Tuấn", "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==", null, false, "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ", false, "/img/Khoa.png", "user5@example.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Event_PlanID",
                table: "Event",
                column: "PlanID");

            migrationBuilder.CreateIndex(
                name: "IX_Group_EventID",
                table: "Group",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_MembersGroups_GroupID",
                table: "MembersGroups",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_MembersGroups_UserID",
                table: "MembersGroups",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PdfFile_PlanID",
                table: "PdfFile",
                column: "PlanID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_EventID",
                table: "Task",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_GroupID",
                table: "Task",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Assignments_MemberGroupID",
                table: "Task_Assignments",
                column: "MemberGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Assignments_TaskID",
                table: "Task_Assignments",
                column: "TaskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PdfFile");

            migrationBuilder.DropTable(
                name: "Task_Assignments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MembersGroups");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
