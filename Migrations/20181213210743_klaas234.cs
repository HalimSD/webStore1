using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class klaas234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribuutsoort_Productwaarde_ProductwaardeId",
                table: "Attribuutsoort");

            migrationBuilder.AlterColumn<int>(
                name: "ProductwaardeId",
                table: "Attribuutsoort",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Custom",
                table: "Attribuutsoort",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Attribuutsoort_Productwaarde_ProductwaardeId",
                table: "Attribuutsoort",
                column: "ProductwaardeId",
                principalTable: "Productwaarde",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribuutsoort_Productwaarde_ProductwaardeId",
                table: "Attribuutsoort");

            migrationBuilder.DropColumn(
                name: "Custom",
                table: "Attribuutsoort");

            migrationBuilder.AlterColumn<int>(
                name: "ProductwaardeId",
                table: "Attribuutsoort",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attribuutsoort_Productwaarde_ProductwaardeId",
                table: "Attribuutsoort",
                column: "ProductwaardeId",
                principalTable: "Productwaarde",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
