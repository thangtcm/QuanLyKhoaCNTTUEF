using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Data.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "127e40ee-e806-481a-a87a-95e302849617");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1de5e3e1-3cb1-4b45-9cba-3aed4f4c8eb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8186f41d-df04-4576-815a-f479fa1b342f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2d5956d-480e-45bc-9374-35e3d241b52d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cde6fc7b-7fd4-4554-8cfc-066b519667e4");

            migrationBuilder.RenameColumn(
                name: "FirtName",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "UrlAvartar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39d5b150-357b-4356-8ec9-c00e28153305", "94059fac-2063-49f0-9f02-a8f6bc82d832", "Administrator", "Administrator" },
                    { "9eadac84-d369-463f-99fa-fff167eb72c9", "b7163dc2-700c-4f5f-9c95-657d633b92ee", "Teacher", "Teacher" },
                    { "a4b20055-2306-4973-9695-b8f7d599d4d8", "18889e7f-7193-4c51-aa63-907d4c6f994b", "Student", "Student" },
                    { "c23e6684-a979-4822-a020-5770f4763ce0", "71c4493d-4450-412c-8e81-6f46e9084b1d", "Manager", "Manager" },
                    { "e43f1469-a4b4-4dbe-b42a-013c1008fe9b", "a3aead75-4aca-4b63-b616-0b05f2cdaae6", "Staff", "Staff" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39d5b150-357b-4356-8ec9-c00e28153305");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eadac84-d369-463f-99fa-fff167eb72c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4b20055-2306-4973-9695-b8f7d599d4d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c23e6684-a979-4822-a020-5770f4763ce0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e43f1469-a4b4-4dbe-b42a-013c1008fe9b");

            migrationBuilder.DropColumn(
                name: "UrlAvartar",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "FirtName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "127e40ee-e806-481a-a87a-95e302849617", "70e6c1b0-9068-415b-8acf-326ffc8934ed", "Teacher", "Teacher" },
                    { "1de5e3e1-3cb1-4b45-9cba-3aed4f4c8eb3", "43b0dd4e-94d0-4208-b2e6-5b8169fa4818", "Administrator", "Administrator" },
                    { "8186f41d-df04-4576-815a-f479fa1b342f", "6c92f060-e610-4821-b49e-5ea9b55ba5be", "Student", "Student" },
                    { "c2d5956d-480e-45bc-9374-35e3d241b52d", "a68e8adc-1099-430c-a7eb-a459ce2dd23f", "Staff", "Staff" },
                    { "cde6fc7b-7fd4-4554-8cfc-066b519667e4", "e6c3a625-ad72-4549-a779-76172dc7475d", "Manager", "Manager" }
                });
        }
    }
}
