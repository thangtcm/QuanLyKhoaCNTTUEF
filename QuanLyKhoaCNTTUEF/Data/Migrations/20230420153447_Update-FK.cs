using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Migrations
{
    public partial class UpdateFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02dbc3d4-18fc-4b6c-a2e4-683956cea69a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05954a7f-a4dc-43f1-b590-92f0a41e0cc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "429659e6-161a-4cd6-a950-d4e71b3dee5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e21ff63f-311d-4948-8ae5-bd46afa083e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa173d6a-1a1a-43e5-8d93-72ad5bdabb85");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d1269f2-cb75-4254-9b2c-f1a0115e1f31", null, "Teacher", "Teacher" },
                    { "8a6a0983-3636-47ce-9765-3fba2a7afe49", null, "Manager", "Manager" },
                    { "93283c08-dee5-44af-b151-eff73ad78d74", null, "Student", "Student" },
                    { "d31d0e88-87a9-44a0-bfa9-75a0c21b92cb", null, "Administrator", "Administrator" },
                    { "de0c4125-a09d-418f-b652-eccf49681ccb", null, "Staff", "Staff" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d1269f2-cb75-4254-9b2c-f1a0115e1f31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a6a0983-3636-47ce-9765-3fba2a7afe49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93283c08-dee5-44af-b151-eff73ad78d74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d31d0e88-87a9-44a0-bfa9-75a0c21b92cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de0c4125-a09d-418f-b652-eccf49681ccb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02dbc3d4-18fc-4b6c-a2e4-683956cea69a", null, "Staff", "Staff" },
                    { "05954a7f-a4dc-43f1-b590-92f0a41e0cc3", null, "Teacher", "Teacher" },
                    { "429659e6-161a-4cd6-a950-d4e71b3dee5b", null, "Student", "Student" },
                    { "e21ff63f-311d-4948-8ae5-bd46afa083e2", null, "Administrator", "Administrator" },
                    { "fa173d6a-1a1a-43e5-8d93-72ad5bdabb85", null, "Manager", "Manager" }
                });
        }
    }
}
