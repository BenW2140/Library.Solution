using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class UpdateCatalogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Catalogs_CatalogId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.RenameColumn(
                name: "CatalogId",
                table: "Books",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CatalogId",
                table: "Books",
                newName: "IX_Books_GenreId");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Books",
                newName: "CatalogId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                newName: "IX_Books_CatalogId");

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    CatalogId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.CatalogId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Catalogs_CatalogId",
                table: "Books",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "CatalogId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
