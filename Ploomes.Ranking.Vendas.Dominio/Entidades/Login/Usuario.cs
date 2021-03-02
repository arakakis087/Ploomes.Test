using Ploomes.Ranking.Vendas.Dominio.Entidades.Base;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using System.Collections.Generic;

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.Login
{
    public class Usuario : Entidade
    {
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
        public string Token { get; set; }
        public List<LogUsuario> ListaLogAutenticacao { get; set; }
        public List<VendedorHistorico> ListaVendedorHistorico { get; set; }
        public List<ErrosVendedorHistorico> ListaErrosVendedorHistorico { get; set; }
    }
}
