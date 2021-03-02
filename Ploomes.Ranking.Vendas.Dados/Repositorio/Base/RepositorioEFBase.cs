using EFCore.BulkExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ploomes.Ranking.Vendas.Dados.Contexto;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Base;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.Dados.Repositorio.Base
{
    public class RepositorioEFBase<EntidadeDominio> :
       IRepositorioEFBase<EntidadeDominio>,
           IDisposable where EntidadeDominio :
               Entidade
    {
        private readonly ContextoRankingVendas _db;

        protected ContextoRankingVendas Db
        {
            get { return _db; }
        }


        public RepositorioEFBase(
            ContextoRankingVendas context)
        {
            _db = context;
        }

        #region Métodos genéricos de leitura

        public async Task<EntidadeDominio> BuscarPorIdAssincrono(
            int id)
        {
            return
                await _db.Set<EntidadeDominio>()
                    .AsNoTracking()
                        .Where(x =>
                            x.Id.Equals(
                                id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EntidadeDominio>> BuscarTudoAssincrono()
        {
            return
                  await _db.Set<EntidadeDominio>()
                       .AsNoTracking()
                            .ToListAsync() as IEnumerable<EntidadeDominio>;
        }


        public async Task<EntidadeDominio> BuscarPorCodigoAssincrono(string codigo)
        {
            return
               await
                  _db.Set<EntidadeDominio>()
                   .AsNoTracking()
                       .Where(x =>
                           x.Codigo.Equals(
                               codigo)).FirstOrDefaultAsync();
        }

        public async Task<int> RetornaQtdLinhas()
        {
            return
               await _db.Set<EntidadeDominio>()
                  .AsNoTracking()
                      .CountAsync();
        }

        #endregion

        #region Métodos genéricos de escrita


        public async Task AdicionarAssincrono(EntidadeDominio obj)
        {
            await Db.Set<EntidadeDominio>().AddAsync(obj);
            await Db.SaveChangesAsync();
        }

        public async Task AdicionarListaAssincrono(
            IEnumerable<EntidadeDominio> entities)
        {
            if (entities.Count() <= 0)
                return;

            await Db.Set<EntidadeDominio>().AddRangeAsync(
                entities);

            await Db.SaveChangesAsync();
        }

        public void Atualizar(
            EntidadeDominio entity)
        {
            Db.Set<EntidadeDominio>().Update(entity);

            Db.SaveChanges();
        }

        public void AtualizarLista(
            IEnumerable<EntidadeDominio> entities)
        {
            if (entities.Count() <= 0)
                return;

            Db.UpdateRange(entities);

            Db.SaveChanges();
        }

        public void Remover(EntidadeDominio obj)
        {
            Db.Entry(obj).State = EntityState.Deleted;
            Db.Set<EntidadeDominio>().Remove(obj);
            Db.SaveChanges();
        }

        public void RemoverLista(
            IEnumerable<EntidadeDominio> entities)
        {
            if (entities.Count() <= 0)
                return;

            //Db.Configuration.AutoDetectChangesEnabled = false;

            foreach (EntidadeDominio item in entities)
            {
                Db.Entry(item).State = EntityState.Deleted;
            }

            Db.ChangeTracker.DetectChanges();

            Db.Set<EntidadeDominio>().RemoveRange(
                entities);

            Db.SaveChanges();
        }

        public async Task RemoverTudoAssincrono()
        {
            await Db.Database.ExecuteSqlRawAsync(
                string.Format(
                    "truncate table {0}",
                        typeof(EntidadeDominio).Name));
            await Db.SaveChangesAsync();
        }

        public async Task AdicionarBlocoAssincrono(
            List<EntidadeDominio> entities)
        {
            if (entities.Count() <= 0)
                return;

            await Db.BulkInsertAsync(
                entities,
                    new BulkConfig()
                    {
                        SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                        EnableStreaming = true,
                        BatchSize = 3000,
                        BulkCopyTimeout = 2000000000
                    });

            await Db.SaveChangesAsync();
        }


        public async Task DeletarBlocoAssincrono(
            List<EntidadeDominio> entities)
        {
            if (entities.Count() <= 0)
                return;


            await Db.BulkDeleteAsync(
                entities,
                    new BulkConfig()
                    {
                        SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                        EnableStreaming = true,
                        BatchSize = 3000,
                        BulkCopyTimeout = 2000000000
                    });

            await Db.SaveChangesAsync();
        }

        public async Task AtualizarBlocoAssincrono(
            List<EntidadeDominio> entities)
        {
            if (entities.Count() <= 0)
                return;

            await Db.BulkUpdateAsync(
                entities,
                    new BulkConfig()
                    {
                        SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                        EnableStreaming = true,
                        BatchSize = 3000,
                        BulkCopyTimeout = 2000000000
                    });

            await Db.SaveChangesAsync();
        }

        public async Task AdicionarAtualizarBlocoAssincrono(
            List<EntidadeDominio> entities)
        {
            if (entities.Count() <= 0)
                return;

            await Db.BulkInsertOrUpdateAsync(
                entities,
                    new BulkConfig()
                    {
                        SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                        EnableStreaming = true,
                        BatchSize = 3000,
                        BulkCopyTimeout = 2000000000
                    });

            await Db.SaveChangesAsync();
        }

        #endregion

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose();
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
