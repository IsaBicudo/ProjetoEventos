using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoEventos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoNova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TotalPagar_Convidado_ConvidadoId",
                table: "TotalPagar");

            migrationBuilder.DropIndex(
                name: "IX_TotalPagar_ConvidadoId",
                table: "TotalPagar");

            migrationBuilder.RenameColumn(
                name: "ConvidadoId",
                table: "TotalPagar",
                newName: "QuantidadeConvidados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantidadeConvidados",
                table: "TotalPagar",
                newName: "ConvidadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalPagar_ConvidadoId",
                table: "TotalPagar",
                column: "ConvidadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TotalPagar_Convidado_ConvidadoId",
                table: "TotalPagar",
                column: "ConvidadoId",
                principalTable: "Convidado",
                principalColumn: "ConvidadoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
