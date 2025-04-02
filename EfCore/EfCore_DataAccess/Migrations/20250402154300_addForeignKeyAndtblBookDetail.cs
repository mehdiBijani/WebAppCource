using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyAndtblBookDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDetail_id_fk",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Category_id_fk",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapter = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_id_fk",
                table: "Books",
                column: "BookDetail_id_fk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Category_id_fk",
                table: "Books",
                column: "Category_id_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetail_id_fk",
                table: "Books",
                column: "BookDetail_id_fk",
                principalTable: "BookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_Category_id_fk",
                table: "Books",
                column: "Category_id_fk",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetail_id_fk",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Category_id_fk",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_id_fk",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Category_id_fk",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookDetail_id_fk",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Category_id_fk",
                table: "Books");
        }
    }
}
