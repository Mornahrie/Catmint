using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catmint.Migrations
{
    public partial class mod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Comments",
                newName: "comment_text");

            migrationBuilder.AddColumn<int>(
                name: "modered",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "modered",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "comment_text",
                table: "Comments",
                newName: "comment");
        }
    }
}
