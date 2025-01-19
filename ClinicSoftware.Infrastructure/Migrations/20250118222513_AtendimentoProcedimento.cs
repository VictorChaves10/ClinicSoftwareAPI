using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicSoftware.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtendimentoProcedimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Descontos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descontos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormaDePagamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<long>(type: "bigint", nullable: false),
                    DataHoraAtendimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IdPagamento = table.Column<long>(type: "bigint", nullable: false),
                    IdDesconto = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Descontos_IdDesconto",
                        column: x => x.IdDesconto,
                        principalTable: "Descontos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Pagamentos_IdPagamento",
                        column: x => x.IdPagamento,
                        principalTable: "Pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentosProcedimentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAtendimento = table.Column<long>(type: "bigint", nullable: false),
                    IdProcedimento = table.Column<long>(type: "bigint", nullable: false),
                    IdFuncionario = table.Column<long>(type: "bigint", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentosProcedimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtendimentosProcedimentos_Atendimentos_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentosProcedimentos_Funcionarios_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtendimentosProcedimentos_Procedimentos_IdProcedimento",
                        column: x => x.IdProcedimento,
                        principalTable: "Procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdCliente",
                table: "Atendimentos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdDesconto",
                table: "Atendimentos",
                column: "IdDesconto");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdPagamento",
                table: "Atendimentos",
                column: "IdPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosProcedimentos_IdAtendimento",
                table: "AtendimentosProcedimentos",
                column: "IdAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosProcedimentos_IdFuncionario",
                table: "AtendimentosProcedimentos",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosProcedimentos_IdProcedimento",
                table: "AtendimentosProcedimentos",
                column: "IdProcedimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentosProcedimentos");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Descontos");

            migrationBuilder.DropTable(
                name: "Pagamentos");
        }
    }
}
