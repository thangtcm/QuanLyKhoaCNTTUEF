using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietTask",
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
                    table.PrimaryKey("PK_ChiTietTask", x => x.IDTask);
                });

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
                name: "KeHoach",
                columns: table => new
                {
                    IDKeHoach = table.Column<string>(type: "varchar(20)", nullable: false),
                    TenKeHoach = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NgayTrinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTrinh = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NguoiDuyet = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHoach", x => x.IDKeHoach);
                });

            migrationBuilder.CreateTable(
                name: "Nhom",
                columns: table => new
                {
                    IDNhom = table.Column<string>(type: "varchar(20)", nullable: false),
                    IDSuKien = table.Column<string>(type: "varchar(50)", nullable: true),
                    TenNhom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhom", x => x.IDNhom);
                });

            migrationBuilder.CreateTable(
                name: "SuKien",
                columns: table => new
                {
                    IDSuKien = table.Column<string>(type: "varchar(20)", nullable: false),
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
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuKien", x => x.IDSuKien);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    IDSuKien = table.Column<string>(type: "varchar(20)", nullable: false),
                    IDTask = table.Column<string>(type: "varchar(50)", nullable: false),
                    TenTask = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    NgayBD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.IDSuKien);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietTask");

            migrationBuilder.DropTable(
                name: "DanhSachThongTin");

            migrationBuilder.DropTable(
                name: "KeHoach");

            migrationBuilder.DropTable(
                name: "Nhom");

            migrationBuilder.DropTable(
                name: "SuKien");

            migrationBuilder.DropTable(
                name: "Task");
        }
    }
}
