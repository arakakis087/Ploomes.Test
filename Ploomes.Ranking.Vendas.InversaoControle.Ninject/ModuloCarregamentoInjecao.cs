using Ninject.Modules;
using Ploomes.Ranking.Vendas.Dados.Repositorio.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dados.Repositorio.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dados.Repositorio.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.Login;
using Ploomes.Ranking.Vendas.Dominio.Servicos.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Servicos.Login;

namespace Ploomes.Ranking.Vendas.InversaoControle.Ninject
{
    public class ModuloCarregamentoInjecao : NinjectModule
    {
        public override void Load()
        {

            #region Repositorios

            Bind<IRepositorioVendedorHistorico>().To<RepositorioVendedorHistorico>();
            Bind<IRepositorioErrosVendedorHistorico>().To<RepositorioErrosVendedorHistorico>();
            Bind<IRepositorioUsuario>().To<RepositorioUsuario>();
            Bind<IRepositorioPerfil>().To<RepositorioPerfil>();
            Bind<IRepositorioLogUsuario>().To<RepositorioLogUsuario>();
            Bind<IRepositorioTabela>().To<RepositorioTabela>();
            Bind<IRepositorioTabelaColuna>().To<RepositorioTabelaColuna>();


            #endregion

            #region Servicos

            Bind<IServicoUsuario>().To<ServicoUsuario>();
            Bind<IServicoErrosVendedorHistorico>().To<ServicoErrosVendedorHistorico>();
            Bind<IServicoVendedorHistorico>().To<ServicoVendedorHistorico>();

            #endregion
        }
    }
}
