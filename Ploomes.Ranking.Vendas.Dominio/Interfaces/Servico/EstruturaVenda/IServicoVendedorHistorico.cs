

using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.API;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.ValoresRank;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaVenda
{
    public interface IServicoVendedorHistorico
    {

        Task<string> AdicionaVendedorHistorico(
            IEnumerable<VendedorHistorico> listaVendedorHistorico,
               int usuarioId);

        Task<IEnumerable<VendedorHistorico>> GeraVendedorHistorico(
            IEnumerable<VendedorClienteHistorico> listaVendedorClienteHistorico,
               int usuarioId);

        Task<IEnumerable<RankingVendedor>> RetornaRankingVendedor(
            Usuario usuario,
               bool usuarioAdmin);

        Task<IEnumerable<RankingVendedorSku>> RetornaRankingVendedorSku(
            Usuario usuario,
               bool usuarioAdmin);

        Task<IEnumerable<RankingVendedorCliente>> RetornaRankingVendedorCliente(
            Usuario usuario,
               bool usuarioAdmin);
    }
}
