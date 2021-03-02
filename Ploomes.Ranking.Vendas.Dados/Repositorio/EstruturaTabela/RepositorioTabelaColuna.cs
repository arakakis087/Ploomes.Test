using Ploomes.Ranking.Vendas.Dados.Contexto;
using Ploomes.Ranking.Vendas.Dados.Repositorio.Base;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaTabela;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ploomes.Ranking.Vendas.Dados.Repositorio.EstruturaTabela
{
    public class RepositorioTabelaColuna :
        RepositorioEFBase<TabelaColuna>,
        IRepositorioTabelaColuna
    {
        private readonly ContextoRankingVendas _db;

        public RepositorioTabelaColuna(ContextoRankingVendas context)
         : base(
               context)
        {
            _db = context;
        }

        public async Task<IEnumerable<TabelaColuna>> RetornaTabelaColunaPorTabelaId(
            int tabelaId)
        {
            return
                  await (from tabelaColuna in _db.TabelaColuna
                         where tabelaColuna.TabelaId == tabelaId
                         select tabelaColuna).ToListAsync();
        }
    }
}
