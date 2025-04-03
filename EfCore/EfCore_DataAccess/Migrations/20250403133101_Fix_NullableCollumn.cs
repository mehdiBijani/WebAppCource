using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixNullableCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetail_id_fk",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_id_fk",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookDetail_id_fk",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_id_fk",
                table: "Books",
                column: "BookDetail_id_fk",
                unique: true,
                filter: "[BookDetail_id_fk] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetail_id_fk",
                table: "Books",
                column: "BookDetail_id_fk",
                principalTable: "BookDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetail_id_fk",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_id_fk",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookDetail_id_fk",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_id_fk",
                table: "Books",
                column: "BookDetail_id_fk",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetail_id_fk",
                table: "Books",
                column: "BookDetail_id_fk",
                principalTable: "BookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
