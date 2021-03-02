using Microsoft.EntityFrameworkCore;
using Ploomes.Ranking.Vendas.Dados.Configuracao.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dados.Configuracao.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dados.Configuracao.Login;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor;

namespace Ploomes.Ranking.Vendas.Dados.Contexto
{
    public class ContextoRankingVendas :
        DbContext
    {
        public ContextoRankingVendas()
        {
            base.Database.EnsureCreated();
        }

        public ContextoRankingVendas(
            DbContextOptions<ContextoRankingVendas> opcoes)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConexaoDB.CadeiaConexaoDBRanking;

            optionsBuilder.UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(20000000));
        }

        #region Tabelas

        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<VendedorHistorico> VendedorHistorico { get; set; }
        public DbSet<ErrosVendedorHistorico> ErrosVendedorHistorico { get; set; }
        public DbSet<LogUsuario> LogUsuario { get; set; }
        public DbSet<Tabela> Tabela { get; set; }
        public DbSet<TabelaColuna> TabelaColuna { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder construtorModelo)
        {
            ConfiguracaoEntidadeEstruturaVenda configuracaoEntidadeEstruturaVenda = new ConfiguracaoEntidadeEstruturaVenda();
            configuracaoEntidadeEstruturaVenda.RetornaModelagemAtualizada(construtorModelo);

            ConfiguracaoEntidadeEstruturaTabela configuracaoEntidadeEstruturaTabela = new ConfiguracaoEntidadeEstruturaTabela();
            configuracaoEntidadeEstruturaTabela.RetornaModelagemAtualizada(construtorModelo);

            ConfiguracaoEntidadeLogin configuracaoEntidadeLogin = new ConfiguracaoEntidadeLogin();
            configuracaoEntidadeLogin.RetornaModelagemAtualizada(construtorModelo);
        }
        
    }
}
