using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Base
{
    public interface IRepositorioEFBase<EntidadeDominio>
        where EntidadeDominio : class
    {
        #region Métodos genéricos de leitura

        Task<EntidadeDominio> BuscarPorIdAssincrono(
            int id);

        Task<IEnumerable<EntidadeDominio>> BuscarTudoAssincrono();

        Task<EntidadeDominio> BuscarPorCodigoAssincrono(
            string codigo);

        Task<int> RetornaQtdLinhas();

        #endregion

        #region Métodos genéricos de Escrita

        Task AdicionarAssincrono(
          EntidadeDominio entidade);

        Task AdicionarListaAssincrono(
            IEnumerable<EntidadeDominio> listaEntidades);

        void Atualizar(
           EntidadeDominio entidade);

        void AtualizarLista(
             IEnumerable<EntidadeDominio> listaEntidades);

        void Remover(
            EntidadeDominio entidade);

        void RemoverLista(
          IEnumerable<EntidadeDominio> listaEntidades);

        Task RemoverTudoAssincrono();

        Task AdicionarBlocoAssincrono(
          List<EntidadeDominio> listaEntidades);

        Task AdicionarAtualizarBlocoAssincrono(
          List<EntidadeDominio> listaEntidades);

        Task AtualizarBlocoAssincrono(
          List<EntidadeDominio> listaEntidades);

        Task DeletarBlocoAssincrono(
          List<EntidadeDominio> listaEntidades);

        #endregion

    }
}
