using Ploomes.Ranking.Vendas.Dominio.Entidades.Base;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda
{
    public class VendedorHistorico : Entidade
    {
        public string CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CodigoSku { get; set; }
        public string NomeSku { get; set; }
        public string CodigoVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public double VolumeHistorico { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
