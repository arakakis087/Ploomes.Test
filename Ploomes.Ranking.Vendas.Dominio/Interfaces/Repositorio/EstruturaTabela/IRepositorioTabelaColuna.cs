using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaTabela
{
    public interface IRepositorioTabelaColuna :
        IRepositorioEFBase<TabelaColuna>
    {
        Task<IEnumerable<TabelaColuna>> RetornaTabelaColunaPorTabelaId(
            int tabelaId);
    }
}
