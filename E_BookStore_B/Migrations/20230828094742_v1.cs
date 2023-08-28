using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_BookStore_B.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "autor_id",
                table: "books",
                newName: "autori_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "autori_id",
                table: "books",
                newName: "autor_id");
        }
    }
}
