using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_BookStore_B.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "autori_id",
                table: "books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "autori_id",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
