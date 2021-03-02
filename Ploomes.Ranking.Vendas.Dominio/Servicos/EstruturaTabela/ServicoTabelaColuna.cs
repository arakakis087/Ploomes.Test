

using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaVenda;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Servicos.EstruturaTabela
{
    public class ServicoTabelaColuna : IServicoTabelaColuna
    {
        private readonly IServicoErrosVendedorHistorico servicoErrosVendedorHistorico;
        private readonly IRepositorioErrosVendedorHistorico repositorioErrosVendedorHistorico;

        public ServicoTabelaColuna(
            IServicoErrosVendedorHistorico servicoErrosVendedorHistorico,
              IRepositorioErrosVendedorHistorico repositorioErrosVendedorHistorico)
        {
            this.servicoErrosVendedorHistorico = servicoErrosVendedorHistorico;
            this.repositorioErrosVendedorHistorico = repositorioErrosVendedorHistorico;
        }

        public async Task<bool> ValidaColunas(
            IEnumerable<ValoresPropriedades> listaValoresPropriedades,
               Tabela tabela,
                TabelaColuna tabelaColuna,
                   int usuarioId)
        {
            bool valido = true;
            List<ErrosVendedorHistorico> listaErros = new List<ErrosVendedorHistorico>();

            //Valida tamanho                

            if (tabelaColuna.TipoCampo == "varchar" && listaValoresPropriedades.Where(x => x.Tamanho > tabelaColuna.TamanhoMaximo).Count() > 0)
            {
                valido = false;

                listaErros.AddRange(
                    await servicoErrosVendedorHistorico
                       .GeraErrosVendedorHistorico(
                           listaValoresPropriedades.Where(x => x.Tamanho > tabelaColuna.TamanhoMaximo).Select(x => x.Valor),
                              tabelaColuna.Nome,
                                 "Tamanho de campo maior que " + tabelaColuna.TamanhoMaximo + " ",
                                    usuarioId));
            }


            //Valida se é obrigatório

            if (tabelaColuna.Obrigatorio == true && listaValoresPropriedades.Where(x => x.Valor == "" || x.Valor == null).Count() > 0)
            {
                valido = false;

                listaErros.AddRange(
                    await servicoErrosVendedorHistorico
                       .GeraErrosVendedorHistorico(
                           listaValoresPropriedades.Where(x => x.Valor == "" || x.Valor == null).Select(x => x.Valor),
                              tabelaColuna.Nome,
                                 "Campo é obrigatório.",
                                    usuarioId));
            }

            if(tabela.Nome == "VendedorHistorico" && listaErros.Count() > 0)
            {
                await repositorioErrosVendedorHistorico
                    .AdicionarBlocoAssincrono(
                       listaErros);
            }

            return valido;
        }


    }
}
