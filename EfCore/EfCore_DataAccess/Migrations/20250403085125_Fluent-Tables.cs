using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FluentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluentAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FluentBookDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapter = table.Column<int>(type: "int", nullable: true),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBookDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FluentPublishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentPublishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FluentBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Categoryidfk = table.Column<int>(name: "Category_id_fk", type: "int", nullable: false),
                    BookDetailidfk = table.Column<int>(name: "BookDetail_id_fk", type: "int", nullable: true),
                    Publisheridfk = table.Column<int>(name: "Publisher_id_fk", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FluentBooks_Categories_Category_id_fk",
                        column: x => x.Categoryidfk,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentBooks_FluentBookDetails_BookDetail_id_fk",
                        column: x => x.BookDetailidfk,
                        principalTable: "FluentBookDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FluentBooks_FluentPublishers_Publisher_id_fk",
                        column: x => x.Publisheridfk,
                        principalTable: "FluentPublishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FluentBookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bookidfk = table.Column<int>(name: "Book_id_fk", type: "int", nullable: false),
                    Authoridfk = table.Column<int>(name: "Author_id_fk", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBookAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FluentBookAuthors_FluentAuthors_Author_id_fk",
                        column: x => x.Authoridfk,
                        principalTable: "FluentAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentBookAuthors_FluentBooks_Book_id_fk",
                        column: x => x.Bookidfk,
                        principalTable: "FluentBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthors_Author_id_fk",
                table: "FluentBookAuthors",
                column: "Author_id_fk");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthors_Book_id_fk",
                table: "FluentBookAuthors",
                column: "Book_id_fk");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_BookDetail_id_fk",
                table: "FluentBooks",
                column: "BookDetail_id_fk",
                unique: true,
                filter: "[BookDetail_id_fk] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_Category_id_fk",
                table: "FluentBooks",
                column: "Category_id_fk");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_Publisher_id_fk",
                table: "FluentBooks",
                column: "Publisher_id_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentBookAuthors");

            migrationBuilder.DropTable(
                name: "FluentAuthors");

            migrationBuilder.DropTable(
                name: "FluentBooks");

            migrationBuilder.DropTable(
                name: "FluentBookDetails");

            migrationBuilder.DropTable(
                name: "FluentPublishers");
        }
    }
}
