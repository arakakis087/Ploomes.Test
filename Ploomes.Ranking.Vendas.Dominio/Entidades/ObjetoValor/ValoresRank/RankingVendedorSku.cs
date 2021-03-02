

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.ValoresRank
{
    public class RankingVendedorSku
    {
        public int UsuarioId { get; set; }
        public string CodigoVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string CodigoSku { get; set; }
        public string NomeSku { get; set; }
        public double SomaVolume { get; set; }
        public int Rank { get; set; }
    }
}
