using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tblBookAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_id_fk",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Bookidfk = table.Column<int>(name: "Book_id_fk", type: "int", nullable: false),
                    Authoridfk = table.Column<int>(name: "Author_id_fk", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.Authoridfk, x.Bookidfk });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_Author_id_fk",
                        column: x => x.Authoridfk,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_Book_id_fk",
                        column: x => x.Bookidfk,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publisher_id_fk",
                table: "Books",
                column: "Publisher_id_fk");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_Book_id_fk",
                table: "BookAuthors",
                column: "Book_id_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_Publisher_id_fk",
                table: "Books",
                column: "Publisher_id_fk",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_Publisher_id_fk",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_Books_Publisher_id_fk",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Publisher_id_fk",
                table: "Books");
        }
    }
}
