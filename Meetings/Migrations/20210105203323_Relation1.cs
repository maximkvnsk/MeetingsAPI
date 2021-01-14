using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetings.Migrations
{
    public partial class Relation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserId",
                table: "Profile",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_User_UserId",
                table: "Profile",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_User_UserId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_UserId",
                table: "Profile");
        }
    }
}
