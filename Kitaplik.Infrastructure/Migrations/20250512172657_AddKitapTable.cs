using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitaplik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddKitapTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YayinYili",
                table: "Kitaplar");

            migrationBuilder.AddColumn<string>(
                name: "Yayinevi",
                table: "Kitaplar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Yayinevi",
                table: "Kitaplar");

            migrationBuilder.AddColumn<int>(
                name: "YayinYili",
                table: "Kitaplar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
