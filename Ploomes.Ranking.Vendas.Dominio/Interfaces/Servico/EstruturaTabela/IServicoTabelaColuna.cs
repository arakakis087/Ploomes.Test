

using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaTabela
{
    public interface IServicoTabelaColuna
    {
        Task<bool> ValidaColunas(
            IEnumerable<ValoresPropriedades> listaValoresPropriedades,
               Tabela tabela,
                TabelaColuna tabelaColuna,
                   int usuarioId);
    }
}
