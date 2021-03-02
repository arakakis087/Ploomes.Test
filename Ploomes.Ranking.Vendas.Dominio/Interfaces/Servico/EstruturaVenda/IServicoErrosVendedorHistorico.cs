using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaVenda
{
    public interface IServicoErrosVendedorHistorico
    {
        Task<IEnumerable<ErrosVendedorHistorico>> GeraErrosVendedorHistorico(
            IEnumerable<string> listaValores,
              string nomeColuna,
                string mensagemErro,
                   int usuarioId);
    }
}
