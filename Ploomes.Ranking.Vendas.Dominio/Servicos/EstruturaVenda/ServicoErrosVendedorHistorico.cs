

using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaVenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Servicos.EstruturaVenda
{
    public class ServicoErrosVendedorHistorico : IServicoErrosVendedorHistorico
    {
        

        public ServicoErrosVendedorHistorico()
        {
        }

        public async Task<IEnumerable<ErrosVendedorHistorico>> GeraErrosVendedorHistorico(
            IEnumerable<string> listaValores,
              string nomeColuna,
                string mensagemErro,
                   int usuarioId)
        {
            return
                await Task.FromResult(
                (from valores in listaValores
                 select new ErrosVendedorHistorico
                 {
                     Ativo = true,
                     Codigo = "",
                     DataCriacao = DateTime.Now,
                     DataModificacao = DateTime.Now,
                     Mensagem = mensagemErro + "|" + "Coluna:" + nomeColuna + "|Valor:" + valores,
                     Nome = "",
                     UsuarioId = usuarioId
                 }));
        }
    }
}
