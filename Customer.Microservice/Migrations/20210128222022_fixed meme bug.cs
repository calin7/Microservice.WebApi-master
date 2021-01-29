using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Microservice.Migrations
{
    public partial class fixedmemebug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BotomText",
                table: "Memes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BotomText",
                table: "Memes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
