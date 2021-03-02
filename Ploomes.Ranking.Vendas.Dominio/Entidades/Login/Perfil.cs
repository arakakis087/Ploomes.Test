using Ploomes.Ranking.Vendas.Dominio.Entidades.Base;
using System.Collections.Generic;

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.Login
{
    public class Perfil : Entidade
    {
        public List<Usuario> ListaUsuario { get; set; }
    }
}
