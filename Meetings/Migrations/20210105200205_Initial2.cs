using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetings.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kebab11",
                table: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kebab11",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
