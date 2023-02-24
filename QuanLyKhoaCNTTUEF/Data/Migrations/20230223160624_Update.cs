using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirtName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DanhSachThongTin",
                columns: table => new
                {
                    IDNhom = table.Column<string>(type: "varchar(50)", nullable: false),
                    UserID = table.Column<string>(type: "varchar(50)", nullable: false),
                    IDTask = table.Column<string>(type: "varchar(50)", nullable: false),
                    IDSinhVien = table.Column<string>(type: "varchar(50)", nullable: false),
                    IDGiaoVien = table.Column<string>(type: "varchar(50)", nullable: false),
                    IDKhoa = table.Column<string>(type: "varchar(50)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DiaChiHienTai = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Nganh = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachThongTin", x => x.IDNhom);
                });

            migrationBuilder.CreateTable(
                name: "DetailTask",
                columns: table => new
                {
                    IDTask = table.Column<string>(type: "varchar(20)", nullable: false),
                    IDNhom = table.Column<string>(type: "varchar(20)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    KetQua = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailTask", x => x.IDTask);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    IDKeHoach = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKeHoach = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NgayTrinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTrinh = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NguoiDuyet = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PathFilePDF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.IDKeHoach);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSuKien = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NgayBD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    XoaTam = table.Column<int>(type: "int", nullable: false),
                    IDNguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDNguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDNguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanIDKeHoach = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_Plan_PlanIDKeHoach",
                        column: x => x.PlanIDKeHoach,
                        principalTable: "Plan",
                        principalColumn: "IDKeHoach");
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: true),
                    TenNhom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(150)", nullable: true),
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
                name: "Task",
                columns: table => new
                {
                    IDTask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    TenTask = table.Column<string>(type: "varchar(50)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    NgayBD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.IDTask);
                    table.ForeignKey(
                        name: "FK_Task_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersGroups",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersGroups", x => new { x.UserID, x.GroupID });
                    table.ForeignKey(
                        name: "FK_MembersGroups_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersGroups_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_PlanIDKeHoach",
                table: "Event",
                column: "PlanIDKeHoach");

            migrationBuilder.CreateIndex(
                name: "IX_Group_EventID",
                table: "Group",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_MembersGroups_GroupID",
                table: "MembersGroups",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_EventID",
                table: "Task",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhSachThongTin");

            migrationBuilder.DropTable(
                name: "DetailTask");

            migrationBuilder.DropTable(
                name: "MembersGroups");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirtName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");
        }
    }
}
