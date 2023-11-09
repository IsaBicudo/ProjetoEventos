using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoEventos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoImagemBuffet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemBuffet1",
                table: "Buffet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemBuffet2",
                table: "Buffet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemBuffet3",
                table: "Buffet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemBuffet1",
                table: "Buffet");

            migrationBuilder.DropColumn(
                name: "ImagemBuffet2",
                table: "Buffet");

            migrationBuilder.DropColumn(
                name: "ImagemBuffet3",
                table: "Buffet");
        }
    }
}
