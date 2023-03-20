using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Data.Migrations
{
    public partial class UpdateSeedSqlUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1f0d9424-6371-418b-a96e-3fea6a4ce8ef", "3167a319-d53e-4a1a-b860-040033efb7e7", "Student", "Student" },
                    { "24c9ea65-513e-483b-b0fe-6df7cc75ed23", "d94f71f7-46cb-41f8-b729-35a0b2508077", "Staff", "Staff" },
                    { "9e4410a3-6cd4-4f4e-b0fb-30dd0c5ce710", "ccf79de8-3bd7-4cc0-b7b6-bd6e9835b29b", "Administrator", "Administrator" },
                    { "bca1cce5-2700-44d0-8c36-821631315ff3", "33410e02-eb1a-4890-a308-ae4a93297cb0", "Teacher", "Teacher" },
                    { "e3006648-5c5f-4b36-9494-624d5ebe0b51", "8ed026a5-0ad8-4bce-a27e-edbdc7dfcd6d", "Manager", "Manager" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f0d9424-6371-418b-a96e-3fea6a4ce8ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24c9ea65-513e-483b-b0fe-6df7cc75ed23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e4410a3-6cd4-4f4e-b0fb-30dd0c5ce710");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bca1cce5-2700-44d0-8c36-821631315ff3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3006648-5c5f-4b36-9494-624d5ebe0b51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5");

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
    }
}
