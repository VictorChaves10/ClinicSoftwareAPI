using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicSoftware.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemodelandoNegocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Descontos_IdDesconto",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pagamentos_IdPagamento",
                table: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Descontos");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_IdDesconto",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_IdPagamento",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "IdDesconto",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "IdPagamento",
                table: "Atendimentos");

            migrationBuilder.CreateTable(
                name: "PagamentosAtendimentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAtendimento = table.Column<long>(type: "bigint", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FormaPagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentosAtendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentosAtendimentos_Atendimentos_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosAtendimentos_IdAtendimento",
                table: "PagamentosAtendimentos",
                column: "IdAtendimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagamentosAtendimentos");

            migrationBuilder.AddColumn<long>(
                name: "IdDesconto",
                table: "Atendimentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdPagamento",
                table: "Atendimentos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdDesconto",
                table: "Atendimentos",
                column: "IdDesconto");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdPagamento",
                table: "Atendimentos",
                column: "IdPagamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Descontos_IdDesconto",
                table: "Atendimentos",
                column: "IdDesconto",
                principalTable: "Descontos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Pagamentos_IdPagamento",
                table: "Atendimentos",
                column: "IdPagamento",
                principalTable: "Pagamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
