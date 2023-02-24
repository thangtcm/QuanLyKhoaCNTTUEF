using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Data.Migrations
{
    public partial class UpdatePlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathFilePDF",
                table: "Plan");

            migrationBuilder.CreateTable(
                name: "PdfFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanIDKeHoach = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PdfFile_Plan_PlanIDKeHoach",
                        column: x => x.PlanIDKeHoach,
                        principalTable: "Plan",
                        principalColumn: "IDKeHoach");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PdfFile_PlanIDKeHoach",
                table: "PdfFile",
                column: "PlanIDKeHoach");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdfFile");

            migrationBuilder.AddColumn<string>(
                name: "PathFilePDF",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
