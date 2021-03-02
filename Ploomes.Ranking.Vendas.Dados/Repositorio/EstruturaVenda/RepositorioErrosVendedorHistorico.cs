using Ploomes.Ranking.Vendas.Dados.Contexto;
using Ploomes.Ranking.Vendas.Dados.Repositorio.Base;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaVenda;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ploomes.Ranking.Vendas.Dados.Repositorio.EstruturaVenda
{
    public class RepositorioErrosVendedorHistorico :
        RepositorioEFBase<ErrosVendedorHistorico>,
        IRepositorioErrosVendedorHistorico
    {
        private readonly ContextoRankingVendas _db;

        public RepositorioErrosVendedorHistorico(ContextoRankingVendas context)
         : base(
               context)
        {
            _db = context;
        }

        public async Task<IEnumerable<ErrosVendedorHistorico>> RetornaListaPorUsuarioId(
            int usuarioId)
        {
            return await
                (from errosVendedorHistorico in _db.ErrosVendedorHistorico
                 where errosVendedorHistorico.UsuarioId == usuarioId
                 select errosVendedorHistorico).ToListAsync();
        }
    }
}
