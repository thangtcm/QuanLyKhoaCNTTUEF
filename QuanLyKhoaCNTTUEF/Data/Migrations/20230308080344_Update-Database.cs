using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Data.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "Group",
                type: "nvarchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65592b81-8aea-4127-97ac-d94911a52acb", "eacc1350-51ed-442e-8c74-0dd5b8e52146", "Staff", "Staff" },
                    { "886fb0f1-b228-43a4-a91d-fe466c6f6166", "7aee3d91-e327-4ff8-93d7-45ff19855e75", "Student", "Student" },
                    { "a3ce8d44-02e8-4eed-83f8-778d4b445f33", "e64a0ccc-0dbb-4a2a-a61b-7c89ad5ea763", "Teacher", "Teacher" },
                    { "c54f5bae-41d2-4f5f-b152-0fdbbe9fd1bd", "689adbbc-d7a5-41c1-9e27-eefabdc2f500", "Administrator", "Administrator" },
                    { "f98efae4-27c3-429f-8ee0-81a3e18574d4", "afa7da52-1506-46a4-9ef0-80515e3be5f8", "Manager", "Manager" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65592b81-8aea-4127-97ac-d94911a52acb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "886fb0f1-b228-43a4-a91d-fe466c6f6166");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3ce8d44-02e8-4eed-83f8-778d4b445f33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c54f5bae-41d2-4f5f-b152-0fdbbe9fd1bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f98efae4-27c3-429f-8ee0-81a3e18574d4");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "Group",
                type: "nvarchar(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldNullable: true);

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
    }
}
