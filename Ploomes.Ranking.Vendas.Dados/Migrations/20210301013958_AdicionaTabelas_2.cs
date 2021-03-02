using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ploomes.Ranking.Vendas.Dados.Migrations
{
    public partial class AdicionaTabelas_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaColuna",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    TamanhoMaximo = table.Column<int>(nullable: false),
                    Obrigatorio = table.Column<bool>(nullable: false),
                    TipoCampo = table.Column<string>(nullable: true),
                    TabelaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaColuna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaColuna_Tabela_TabelaId",
                        column: x => x.TabelaId,
                        principalTable: "Tabela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabelaColuna_TabelaId",
                table: "TabelaColuna",
                column: "TabelaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelaColuna");

            migrationBuilder.DropTable(
                name: "Tabela");
        }
    }
}
