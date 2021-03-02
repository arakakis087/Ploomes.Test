
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Base;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login
{
    public interface IRepositorioUsuario :
        IRepositorioEFBase<Usuario>
    {
        Task<Usuario> RetornaUsuarioPorToken(
            string token);
    }
}
