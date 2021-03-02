

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.API
{
    public class VendedorClienteHistorico
    {
        public string CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CodigoSku { get; set; }
        public string NomeSku { get; set; }
        public string CodigoVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public double VolumeHistorico { get; set; }
    }
}
