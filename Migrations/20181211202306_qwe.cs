using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class qwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParentChild",
                columns: table => new
                {
                    ParentId = table.Column<int>(nullable: false),
                    ChildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentChild", x => new { x.ChildId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_ParentChild_Productsoort_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Productsoort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentChild_Productsoort_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Productsoort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParentChild_ParentId",
                table: "ParentChild",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParentChild");
        }
    }
}
