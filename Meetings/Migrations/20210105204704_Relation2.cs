using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetings.Migrations
{
    public partial class Relation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_User_UserId",
                table: "Profile");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_ToUser",
                table: "Profile",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_ToUser",
                table: "Profile");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_User_UserId",
                table: "Profile",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
