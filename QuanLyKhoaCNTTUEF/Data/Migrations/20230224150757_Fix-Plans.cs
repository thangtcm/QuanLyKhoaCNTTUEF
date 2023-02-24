using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Data.Migrations
{
    public partial class FixPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PdfFile_Plan_PlanIDKeHoach",
                table: "PdfFile");

            migrationBuilder.DropIndex(
                name: "IX_PdfFile_PlanIDKeHoach",
                table: "PdfFile");

            migrationBuilder.DropColumn(
                name: "PlanIDKeHoach",
                table: "PdfFile");

            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "PdfFile",
                newName: "DateUpload");

            migrationBuilder.AddColumn<int>(
                name: "IDKeHoach",
                table: "PdfFile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PdfFile_IDKeHoach",
                table: "PdfFile",
                column: "IDKeHoach");

            migrationBuilder.AddForeignKey(
                name: "FK_PdfFile_Plan_IDKeHoach",
                table: "PdfFile",
                column: "IDKeHoach",
                principalTable: "Plan",
                principalColumn: "IDKeHoach",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PdfFile_Plan_IDKeHoach",
                table: "PdfFile");

            migrationBuilder.DropIndex(
                name: "IX_PdfFile_IDKeHoach",
                table: "PdfFile");

            migrationBuilder.DropColumn(
                name: "IDKeHoach",
                table: "PdfFile");

            migrationBuilder.RenameColumn(
                name: "DateUpload",
                table: "PdfFile",
                newName: "DateCreate");

            migrationBuilder.AddColumn<int>(
                name: "PlanIDKeHoach",
                table: "PdfFile",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PdfFile_PlanIDKeHoach",
                table: "PdfFile",
                column: "PlanIDKeHoach");

            migrationBuilder.AddForeignKey(
                name: "FK_PdfFile_Plan_PlanIDKeHoach",
                table: "PdfFile",
                column: "PlanIDKeHoach",
                principalTable: "Plan",
                principalColumn: "IDKeHoach");
        }
    }
}
