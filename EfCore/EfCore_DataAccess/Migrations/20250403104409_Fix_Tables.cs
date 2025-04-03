using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_Categories_Category_id_fk",
                table: "FluentBooks");

            migrationBuilder.CreateTable(
                name: "FluentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentCategories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentCategories_Category_id_fk",
                table: "FluentBooks",
                column: "Category_id_fk",
                principalTable: "FluentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentCategories_Category_id_fk",
                table: "FluentBooks");

            migrationBuilder.DropTable(
                name: "FluentCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_Categories_Category_id_fk",
                table: "FluentBooks",
                column: "Category_id_fk",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
