using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedatabaseSuKien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDNguoiCapNhat",
                table: "SuKien",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IDNguoiTao",
                table: "SuKien",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IDNguoiXoa",
                table: "SuKien",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "SuKien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "SuKien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "SuKien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "XoaTam",
                table: "SuKien",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "trangthai",
                table: "SuKien",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDNguoiCapNhat",
                table: "SuKien");

            migrationBuilder.DropColumn(
                name: "IDNguoiTao",
                table: "SuKien");

            migrationBuilder.DropColumn(
                name: "IDNguoiXoa",
                table: "SuKien");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "SuKien");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "SuKien");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "SuKien");

            migrationBuilder.DropColumn(
                name: "XoaTam",
                table: "SuKien");

            migrationBuilder.DropColumn(
                name: "trangthai",
                table: "SuKien");
        }
    }
}
