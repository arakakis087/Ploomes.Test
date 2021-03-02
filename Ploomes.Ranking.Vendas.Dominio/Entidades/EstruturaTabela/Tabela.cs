
using Ploomes.Ranking.Vendas.Dominio.Entidades.Base;
using System.Collections.Generic;

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaTabela
{
    public class Tabela : Entidade
    {
        public List<TabelaColuna> ListaTabelaColuna { get; set; }
    }
}
