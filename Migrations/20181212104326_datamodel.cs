using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class datamodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductwaardeId",
                table: "Attribuutsoort",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attribuutsoort_ProductwaardeId",
                table: "Attribuutsoort",
                column: "ProductwaardeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attribuutsoort_Productwaarde_ProductwaardeId",
                table: "Attribuutsoort",
                column: "ProductwaardeId",
                principalTable: "Productwaarde",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribuutsoort_Productwaarde_ProductwaardeId",
                table: "Attribuutsoort");

            migrationBuilder.DropIndex(
                name: "IX_Attribuutsoort_ProductwaardeId",
                table: "Attribuutsoort");

            migrationBuilder.DropColumn(
                name: "ProductwaardeId",
                table: "Attribuutsoort");
        }
    }
}
