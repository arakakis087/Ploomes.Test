using Ploomes.Ranking.Vendas.Dominio.Entidades.Base;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda
{
    public class ErrosVendedorHistorico : Entidade
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Mensagem { get; set; }
    }
}
