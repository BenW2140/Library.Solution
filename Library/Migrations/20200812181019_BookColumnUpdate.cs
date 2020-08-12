using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class BookColumnUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Catalogs_CatalogId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "CatalogId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Catalogs_CatalogId",
                table: "Books",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "CatalogId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Catalogs_CatalogId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "CatalogId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Catalogs_CatalogId",
                table: "Books",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "CatalogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
