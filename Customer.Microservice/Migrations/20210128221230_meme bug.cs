using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Microservice.Migrations
{
    public partial class memebug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BotomText",
                table: "Memes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BotomText",
                table: "Memes");
        }
    }
}
