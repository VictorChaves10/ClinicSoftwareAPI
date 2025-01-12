using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicSoftware.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Clientes",
                type: "datetime2",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: true),
                    SalarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Clientes");
        }
    }
}
