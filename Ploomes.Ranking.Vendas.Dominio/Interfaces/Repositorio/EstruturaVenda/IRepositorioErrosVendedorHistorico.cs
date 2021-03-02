using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaVenda
{
    public interface IRepositorioErrosVendedorHistorico :
        IRepositorioEFBase<ErrosVendedorHistorico>
    {
        Task<IEnumerable<ErrosVendedorHistorico>> RetornaListaPorUsuarioId(
            int usuarioId);
    }
}
