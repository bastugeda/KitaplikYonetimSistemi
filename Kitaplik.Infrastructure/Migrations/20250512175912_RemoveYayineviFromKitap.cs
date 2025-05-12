using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitaplik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveYayineviFromKitap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Yayinevi",
                table: "Kitaplar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Yayinevi",
                table: "Kitaplar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
