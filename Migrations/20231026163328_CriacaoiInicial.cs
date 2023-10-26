using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoEventos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoiInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buffet",
                columns: table => new
                {
                    BuffetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuffetTipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buffet", x => x.BuffetId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteCpf = table.Column<int>(name: "ClienteCpf ", type: "int", nullable: false),
                    ClienteEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Convidado",
                columns: table => new
                {
                    ConvidadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConvidadoTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convidado", x => x.ConvidadoId);
                });

            migrationBuilder.CreateTable(
                name: "Decoracao",
                columns: table => new
                {
                    DecoracaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DecoracaoTipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decoracao", x => x.DecoracaoId);
                });

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

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    LocalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    TipoEventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoTipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.TipoEventoId);
                });

            migrationBuilder.CreateTable(
                name: "TotalPagar",
                columns: table => new
                {
                    TotalPagarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ConvidadoId = table.Column<int>(type: "int", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    HorarioId = table.Column<int>(type: "int", nullable: false),
                    DecoracaoId = table.Column<int>(type: "int", nullable: false),
                    BuffetId = table.Column<int>(type: "int", nullable: false),
                    TipoEventoId = table.Column<int>(type: "int", nullable: false),
                    TotalValor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalPagar", x => x.TotalPagarId);
                    table.ForeignKey(
                        name: "FK_TotalPagar_Buffet_BuffetId",
                        column: x => x.BuffetId,
                        principalTable: "Buffet",
                        principalColumn: "BuffetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalPagar_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalPagar_Convidado_ConvidadoId",
                        column: x => x.ConvidadoId,
                        principalTable: "Convidado",
                        principalColumn: "ConvidadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalPagar_Decoracao_DecoracaoId",
                        column: x => x.DecoracaoId,
                        principalTable: "Decoracao",
                        principalColumn: "DecoracaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalPagar_Horario_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horario",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalPagar_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalPagar_TipoEvento_TipoEventoId",
                        column: x => x.TipoEventoId,
                        principalTable: "TipoEvento",
                        principalColumn: "TipoEventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TotalPagar_BuffetId",
                table: "TotalPagar",
                column: "BuffetId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalPagar_ClienteId",
                table: "TotalPagar",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalPagar_ConvidadoId",
                table: "TotalPagar",
                column: "ConvidadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalPagar_DecoracaoId",
                table: "TotalPagar",
                column: "DecoracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalPagar_HorarioId",
                table: "TotalPagar",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalPagar_LocalId",
                table: "TotalPagar",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalPagar_TipoEventoId",
                table: "TotalPagar",
                column: "TipoEventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TotalPagar");

            migrationBuilder.DropTable(
                name: "Buffet");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Convidado");

            migrationBuilder.DropTable(
                name: "Decoracao");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "TipoEvento");
        }
    }
}
