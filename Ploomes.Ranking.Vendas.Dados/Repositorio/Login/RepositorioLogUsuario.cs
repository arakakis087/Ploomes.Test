using Ploomes.Ranking.Vendas.Dados.Contexto;
using Ploomes.Ranking.Vendas.Dados.Repositorio.Base;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login;

namespace Ploomes.Ranking.Vendas.Dados.Repositorio.Login
{
    public class RepositorioLogUsuario :
        RepositorioEFBase<LogUsuario>,
        IRepositorioLogUsuario
    {
        private readonly ContextoRankingVendas _db;

        public RepositorioLogUsuario(ContextoRankingVendas context)
         : base(
               context)
        {
            _db = context;
        }
    }
}
