using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoEventos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoImagemLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemLocal1",
                table: "Local",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemLocal2",
                table: "Local",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemLocal3",
                table: "Local",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemLocal1",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "ImagemLocal2",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "ImagemLocal3",
                table: "Local");
        }
    }
}
