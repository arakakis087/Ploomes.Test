

using Ploomes.Ranking.Vendas.Dados.Contexto;
using Ploomes.Ranking.Vendas.Dados.Repositorio.Base;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaTabela;

namespace Ploomes.Ranking.Vendas.Dados.Repositorio.EstruturaTabela
{
    public class RepositorioTabela :
        RepositorioEFBase<Tabela>,
        IRepositorioTabela
    {
        private readonly ContextoRankingVendas _db;

        public RepositorioTabela(ContextoRankingVendas context)
         : base(
               context)
        {
            _db = context;
        }
    }
}
