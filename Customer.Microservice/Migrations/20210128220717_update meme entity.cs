using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Microservice.Migrations
{
    public partial class updatememeentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemePhoto",
                table: "Memes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemePhoto",
                table: "Memes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
