using Ploomes.Ranking.Vendas.Dominio.Entidades.Base;

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.Login
{
    public class LogUsuario : Entidade
    {
        public string Mensagem { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
