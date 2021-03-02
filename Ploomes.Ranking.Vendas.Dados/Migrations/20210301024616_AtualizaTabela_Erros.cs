using Microsoft.EntityFrameworkCore.Migrations;

namespace Ploomes.Ranking.Vendas.Dados.Migrations
{
    public partial class AtualizaTabela_Erros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoCliente",
                table: "ErrosVendedorHistorico");

            migrationBuilder.DropColumn(
                name: "CodigoSku",
                table: "ErrosVendedorHistorico");

            migrationBuilder.DropColumn(
                name: "CodigoVendedor",
                table: "ErrosVendedorHistorico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoCliente",
                table: "ErrosVendedorHistorico",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoSku",
                table: "ErrosVendedorHistorico",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoVendedor",
                table: "ErrosVendedorHistorico",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
