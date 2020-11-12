using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication9.Migrations
{
    public partial class abcadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notification",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "abc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notification",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "abc",
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
