

using Ploomes.Ranking.Vendas.Dominio.Entidades.Base;

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaTabela
{
    public class TabelaColuna : Entidade
    {
        public int Ordem { get; set; }
        public int TamanhoMaximo { get; set; }
        public bool Obrigatorio { get; set; }
        public string TipoCampo { get; set; }
        public int TabelaId { get; set; }
        public Tabela Tabela { get; set; }
    }
}
