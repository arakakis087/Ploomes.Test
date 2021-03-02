

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.ValoresRank
{
    public class RankingVendedorCliente
    {
        public int UsuarioId { get; set; }
        public string CodigoVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public double SomaVolume { get; set; }
        public int Rank { get; set; }
    }
}
