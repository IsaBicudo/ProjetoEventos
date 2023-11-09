using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoEventos.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TotalPagar_Horario_HorarioId",
                table: "TotalPagar");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropIndex(
                name: "IX_TotalPagar_HorarioId",
                table: "TotalPagar");

            migrationBuilder.DropColumn(
                name: "HorarioId",
                table: "TotalPagar");

            migrationBuilder.AddColumn<DateTime>(
                name: "Horario",
                table: "TotalPagar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horario",
                table: "TotalPagar");

            migrationBuilder.AddColumn<int>(
                name: "HorarioId",
                table: "TotalPagar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioEvento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TotalPagar_HorarioId",
                table: "TotalPagar",
                column: "HorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TotalPagar_Horario_HorarioId",
                table: "TotalPagar",
                column: "HorarioId",
                principalTable: "Horario",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
