using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BesteldeItem_Productwaarde_ProductwaardeId",
                table: "BesteldeItem");

            migrationBuilder.DropIndex(
                name: "IX_BesteldeItem_ProductwaardeId",
                table: "BesteldeItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BesteldeItem_ProductwaardeId",
                table: "BesteldeItem",
                column: "ProductwaardeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BesteldeItem_Productwaarde_ProductwaardeId",
                table: "BesteldeItem",
                column: "ProductwaardeId",
                principalTable: "Productwaarde",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
