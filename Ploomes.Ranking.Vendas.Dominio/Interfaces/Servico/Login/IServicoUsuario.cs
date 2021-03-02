

using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.Login
{
    public interface IServicoUsuario
    {
        Task<bool> ValidaPerfilAdmin(
           Usuario usuario);

    }
}
