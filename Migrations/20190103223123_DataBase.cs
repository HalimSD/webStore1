using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class DataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RootParent",
                table: "Productsoort");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Productsoort",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Productsoort");

            migrationBuilder.AddColumn<bool>(
                name: "RootParent",
                table: "Productsoort",
                nullable: false,
                defaultValue: false);
        }
    }
}
