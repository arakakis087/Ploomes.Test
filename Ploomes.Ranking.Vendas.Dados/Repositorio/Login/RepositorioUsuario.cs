

using Microsoft.EntityFrameworkCore;
using Ploomes.Ranking.Vendas.Dados.Contexto;
using Ploomes.Ranking.Vendas.Dados.Repositorio.Base;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dados.Repositorio.Login
{
    public class RepositorioUsuario :
        RepositorioEFBase<Usuario>,
        IRepositorioUsuario
    {
        private readonly ContextoRankingVendas _db;

        public RepositorioUsuario(ContextoRankingVendas context)
         : base(
               context)
        {
            _db = context;
        }

        public async Task<Usuario> RetornaUsuarioPorToken(
            string token)
        {
            return await
                (from usuario in _db.Usuario
                 where usuario.Token == token
                 select usuario).FirstOrDefaultAsync();
        }
    }
}
