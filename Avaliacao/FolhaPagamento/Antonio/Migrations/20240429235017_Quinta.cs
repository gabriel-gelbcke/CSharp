using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Antonio.Migrations
{
    /// <inheritdoc />
    public partial class Quinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FuncionarioId",
                table: "FolhaPagamentos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ImpostoFgts",
                table: "FolhaPagamentos",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ImpostoInss",
                table: "FolhaPagamentos",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ImpostoIrrf",
                table: "FolhaPagamentos",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SalarioBruto",
                table: "FolhaPagamentos",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SalarioLiquido",
                table: "FolhaPagamentos",
                type: "REAL",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FolhaPagamentos_FuncionarioId",
                table: "FolhaPagamentos",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_FolhaPagamentos_Funcionarios_FuncionarioId",
                table: "FolhaPagamentos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FolhaPagamentos_Funcionarios_FuncionarioId",
                table: "FolhaPagamentos");

            migrationBuilder.DropIndex(
                name: "IX_FolhaPagamentos_FuncionarioId",
                table: "FolhaPagamentos");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "FolhaPagamentos");

            migrationBuilder.DropColumn(
                name: "ImpostoFgts",
                table: "FolhaPagamentos");

            migrationBuilder.DropColumn(
                name: "ImpostoInss",
                table: "FolhaPagamentos");

            migrationBuilder.DropColumn(
                name: "ImpostoIrrf",
                table: "FolhaPagamentos");

            migrationBuilder.DropColumn(
                name: "SalarioBruto",
                table: "FolhaPagamentos");

            migrationBuilder.DropColumn(
                name: "SalarioLiquido",
                table: "FolhaPagamentos");
        }
    }
}
