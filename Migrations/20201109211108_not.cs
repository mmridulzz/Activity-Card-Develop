using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication9.Migrations
{
    public partial class not : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notification",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notification",
                table: "Users");
        }
    }
}
