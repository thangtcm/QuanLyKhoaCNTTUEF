using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Data.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31d3773b-0223-44a1-b613-81c5ed17c0b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43793b3e-c48f-42b9-986a-46a2955eb1e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7284e8af-4c82-42f1-8a27-ff69e18cac6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79a4d24b-797e-4f6d-a394-6f94218e9093");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e3c33ac-a72b-4088-893d-cd8c3c0705aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "067eb158-f812-4491-9be9-0f141cd9c35a", "310bfeb6-780e-46e3-ae2b-df95ca180176", "Administrator", "Administrator" },
                    { "0c48841e-ee61-4427-9133-e70396f8fcd1", "0d727cde-ba7f-4dd5-a2eb-f9fc20c6ec6f", "Student", "Student" },
                    { "8e521788-f42d-4ce2-98c9-fe8a3020d5b3", "3d1d3238-90f3-4d69-b6bd-99370e87d694", "Staff", "Staff" },
                    { "a7cf0dcf-bb35-4250-90e7-46f64eb60973", "f04619c9-f81d-47c6-8d72-0266de16362b", "Manager", "Manager" },
                    { "afe1f6ec-b5e3-4b18-b8ae-02f3536e76df", "0a592259-33c9-431f-a040-4c04bce1e8d8", "Teacher", "Teacher" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "067eb158-f812-4491-9be9-0f141cd9c35a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c48841e-ee61-4427-9133-e70396f8fcd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e521788-f42d-4ce2-98c9-fe8a3020d5b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7cf0dcf-bb35-4250-90e7-46f64eb60973");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afe1f6ec-b5e3-4b18-b8ae-02f3536e76df");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31d3773b-0223-44a1-b613-81c5ed17c0b6", "5501a29e-e3cf-47ff-b5ec-c2673ee73826", "Staff", "Staff" },
                    { "43793b3e-c48f-42b9-986a-46a2955eb1e1", "2040ee89-f81c-4d79-95b4-158d194163ba", "Administrator", "Administrator" },
                    { "7284e8af-4c82-42f1-8a27-ff69e18cac6d", "9cad4f4d-098c-4ef9-bdee-64ae29be1ad2", "Teacher", "Teacher" },
                    { "79a4d24b-797e-4f6d-a394-6f94218e9093", "c49f1be8-83e4-44fb-b3e8-04d4d740657c", "Student", "Student" },
                    { "7e3c33ac-a72b-4088-893d-cd8c3c0705aa", "af234387-a063-408a-b07c-2e5d717b4c90", "Manager", "Manager" }
                });
        }
    }
}
