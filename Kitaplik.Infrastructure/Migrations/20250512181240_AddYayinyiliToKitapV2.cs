using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitaplik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddYayinyiliToKitapV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Yayinyili",
                table: "Kitaplar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Yayinyili",
                table: "Kitaplar");
        }
    }
}
