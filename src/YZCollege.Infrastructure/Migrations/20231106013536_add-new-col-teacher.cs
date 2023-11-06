using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YZCollege.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolteacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavoritePokemon",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoritePokemon",
                table: "Teachers");
        }
    }
}
