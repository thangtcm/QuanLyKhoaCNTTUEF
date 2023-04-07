using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Migrations
{
    public partial class FixForeignKeyTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Assignments_MembersGroups_MemberGroupID",
                table: "Task_Assignments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dda6baf-fee8-4ae5-9521-87ad43d9a203");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c43480a-ea57-4493-8b7d-1185ad37243e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2de6fa80-cebf-40cd-aab8-0211c7f3cbf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "437cf6c5-d5aa-4e0e-8d17-92edf75faccc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7335e6da-bc77-4e3a-88b0-fbd555f0e631");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Task_Assignments");

            migrationBuilder.AlterColumn<int>(
                name: "MemberGroupID",
                table: "Task_Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2242c515-36e8-4fb7-8b30-f7d98f1af35a", "d03c349c-9998-4fba-8404-9759ce23696c", "Administrator", "Administrator" },
                    { "448ba368-3084-4bf3-940a-d44fc8012160", "9af105b2-cc23-4abe-8af0-513962bf1ad7", "Staff", "Staff" },
                    { "776902cc-5cb3-49f5-9af9-8f20bc0e16a6", "46656462-faa3-44e2-ad33-071e0c792211", "Teacher", "Teacher" },
                    { "babb6f3e-955a-41bb-b6fa-e16877a0698c", "fe041e27-4f2d-4849-b111-d810b1dc09bb", "Manager", "Manager" },
                    { "da58c18b-fa75-4d3d-993c-a7271a1c0b30", "0d0d953f-7e47-401e-8f84-efb9cdea0479", "Student", "Student" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Assignments_MembersGroups_MemberGroupID",
                table: "Task_Assignments",
                column: "MemberGroupID",
                principalTable: "MembersGroups",
                principalColumn: "MemberGroupID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Assignments_MembersGroups_MemberGroupID",
                table: "Task_Assignments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2242c515-36e8-4fb7-8b30-f7d98f1af35a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "448ba368-3084-4bf3-940a-d44fc8012160");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "776902cc-5cb3-49f5-9af9-8f20bc0e16a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "babb6f3e-955a-41bb-b6fa-e16877a0698c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da58c18b-fa75-4d3d-993c-a7271a1c0b30");

            migrationBuilder.AlterColumn<int>(
                name: "MemberGroupID",
                table: "Task_Assignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "Task_Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dda6baf-fee8-4ae5-9521-87ad43d9a203", "2c23e43d-284a-435b-a4cf-2bb0beced7a2", "Administrator", "Administrator" },
                    { "2c43480a-ea57-4493-8b7d-1185ad37243e", "5c2f2cf2-5d86-4a61-9036-85bb3a693c02", "Teacher", "Teacher" },
                    { "2de6fa80-cebf-40cd-aab8-0211c7f3cbf7", "aac807f8-6cc3-49b9-8b41-79aa5356a6c1", "Staff", "Staff" },
                    { "437cf6c5-d5aa-4e0e-8d17-92edf75faccc", "9a23bc88-abef-4045-8a6d-d0d4d14d568a", "Manager", "Manager" },
                    { "7335e6da-bc77-4e3a-88b0-fbd555f0e631", "91ad72fb-60bb-433e-ba8a-e46b97f4d389", "Student", "Student" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Assignments_MembersGroups_MemberGroupID",
                table: "Task_Assignments",
                column: "MemberGroupID",
                principalTable: "MembersGroups",
                principalColumn: "MemberGroupID");
        }
    }
}
