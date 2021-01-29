using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Microservice.Migrations
{
    public partial class addmeme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Memes");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Memes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Memes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Memes");

            migrationBuilder.AddColumn<string>(
                name: "BottomText",
                table: "Memes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemePhoto",
                table: "Memes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopText",
                table: "Memes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BottomText",
                table: "Memes");

            migrationBuilder.DropColumn(
                name: "MemePhoto",
                table: "Memes");

            migrationBuilder.DropColumn(
                name: "TopText",
                table: "Memes");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Memes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Memes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Memes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Memes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
