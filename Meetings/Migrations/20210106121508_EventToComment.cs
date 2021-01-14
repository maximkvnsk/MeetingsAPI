using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetings.Migrations
{
    public partial class EventToComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Comment",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_EventId",
                table: "Comment",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ToEvent",
                table: "Comment",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ToEvent",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_EventId",
                table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                table: "Comment",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });
        }
    }
}
