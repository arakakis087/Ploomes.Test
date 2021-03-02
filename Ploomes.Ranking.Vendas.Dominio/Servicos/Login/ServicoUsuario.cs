

using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.Login;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Servicos.Login
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IRepositorioPerfil repositorioPerfil;

        public ServicoUsuario(
            IRepositorioPerfil repositorioPerfil)
        {
            this.repositorioPerfil = repositorioPerfil;
        }

        public async Task<bool> ValidaPerfilAdmin(
           Usuario usuario)
        {
            Perfil perfil = 
                await repositorioPerfil
                 .BuscarPorIdAssincrono(
                    usuario.PerfilId);

            if (perfil.Codigo == "Admin_Teste")
                return true;

            return false;
        }

        

    }
}
