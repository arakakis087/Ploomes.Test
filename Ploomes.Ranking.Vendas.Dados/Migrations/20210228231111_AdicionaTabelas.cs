using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ploomes.Ranking.Vendas.Dados.Migrations
{
    public partial class AdicionaTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    PerfilId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErrosVendedorHistorico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    CodigoSku = table.Column<string>(maxLength: 50, nullable: true),
                    CodigoCliente = table.Column<string>(maxLength: 50, nullable: true),
                    CodigoVendedor = table.Column<string>(maxLength: 50, nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Mensagem = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrosVendedorHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErrosVendedorHistorico_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Mensagem = table.Column<string>(maxLength: 300, nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendedorHistorico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    CodigoCliente = table.Column<string>(maxLength: 50, nullable: true),
                    NomeCliente = table.Column<string>(maxLength: 100, nullable: true),
                    CodigoSku = table.Column<string>(maxLength: 50, nullable: true),
                    NomeSku = table.Column<string>(maxLength: 100, nullable: true),
                    CodigoVendedor = table.Column<string>(maxLength: 50, nullable: true),
                    NomeVendedor = table.Column<string>(maxLength: 100, nullable: true),
                    VolumeHistorico = table.Column<double>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendedorHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendedorHistorico_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrosVendedorHistorico_UsuarioId",
                table: "ErrosVendedorHistorico",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LogUsuario_UsuarioId",
                table: "LogUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_VendedorHistorico_UsuarioId",
                table: "VendedorHistorico",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrosVendedorHistorico");

            migrationBuilder.DropTable(
                name: "LogUsuario");

            migrationBuilder.DropTable(
                name: "VendedorHistorico");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
