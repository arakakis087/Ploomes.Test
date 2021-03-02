using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.ValoresRank;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaVenda
{
    public interface IRepositorioVendedorHistorico :
        IRepositorioEFBase<VendedorHistorico>
    {
        Task<IEnumerable<VendedorHistorico>> RetornaListaPorUsuarioId(
            int usuarioId);

        Task<IEnumerable<RankingVendedor>> RetornaValoresAgrupadoVendedorPorUsuarioId(
            int usuarioId);

        Task<IEnumerable<RankingVendedor>> RetornaValoresAgrupadoVendedor();

        Task<IEnumerable<RankingVendedorSku>> RetornaValoresAgrupadoVendedorSkuPorUsuarioId(
            int usuarioId);

        Task<IEnumerable<RankingVendedorSku>> RetornaValoresAgrupadoVendedorSku();

        Task<IEnumerable<RankingVendedorCliente>> RetornaValoresAgrupadoVendedorClientePorUsuarioId(
            int usuarioId);

        Task<IEnumerable<RankingVendedorCliente>> RetornaValoresAgrupadoVendedorCliente();
    }
}
