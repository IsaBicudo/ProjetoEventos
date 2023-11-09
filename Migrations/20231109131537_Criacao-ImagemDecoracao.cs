using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoEventos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoImagemDecoracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemDecoracao1",
                table: "Decoracao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemDecoracao2",
                table: "Decoracao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemDecoracao3",
                table: "Decoracao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemDecoracao1",
                table: "Decoracao");

            migrationBuilder.DropColumn(
                name: "ImagemDecoracao2",
                table: "Decoracao");

            migrationBuilder.DropColumn(
                name: "ImagemDecoracao3",
                table: "Decoracao");
        }
    }
}
