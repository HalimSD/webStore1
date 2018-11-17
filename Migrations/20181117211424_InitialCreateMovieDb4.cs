using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class InitialCreateMovieDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Productwaarde",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Productwaarde",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Productwaarde");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Productwaarde");
        }
    }
}
