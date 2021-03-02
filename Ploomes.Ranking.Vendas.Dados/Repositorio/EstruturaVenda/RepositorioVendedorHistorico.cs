using Ploomes.Ranking.Vendas.Dados.Contexto;
using Ploomes.Ranking.Vendas.Dados.Repositorio.Base;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaVenda;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.ValoresRank;

namespace Ploomes.Ranking.Vendas.Dados.Repositorio.EstruturaVenda
{
    public class RepositorioVendedorHistorico :
        RepositorioEFBase<VendedorHistorico>,
        IRepositorioVendedorHistorico
    {
        private readonly ContextoRankingVendas _db;

        public RepositorioVendedorHistorico(ContextoRankingVendas context)
         : base(
               context)
        {
            _db = context;
        }

        public async Task<IEnumerable<VendedorHistorico>> RetornaListaPorUsuarioId(
            int usuarioId)
        {
            return await
                (from vendedorHistorico in _db.VendedorHistorico
                 where vendedorHistorico.UsuarioId == usuarioId
                 select vendedorHistorico).ToListAsync();
        }

        public async Task<IEnumerable<RankingVendedor>> RetornaValoresAgrupadoVendedorPorUsuarioId(
            int usuarioId)
        {
            return await
                (from vendedorHistorico in _db.VendedorHistorico
                 where vendedorHistorico.UsuarioId == usuarioId
                 group vendedorHistorico by 
                 new
                 {
                     vendedorHistorico.CodigoVendedor,
                     vendedorHistorico.NomeVendedor,
                     vendedorHistorico.UsuarioId
                 }
                 into agrupado
                 select new RankingVendedor
                 {
                     CodigoVendedor = agrupado.Key.CodigoVendedor,
                     NomeVendedor = agrupado.Key.NomeVendedor,
                     UsuarioId = agrupado.Key.UsuarioId,
                     SomaVolume = agrupado.Sum(x => x.VolumeHistorico)
                 }).OrderByDescending(x => x.SomaVolume).ToListAsync();
        }

        public async Task<IEnumerable<RankingVendedor>> RetornaValoresAgrupadoVendedor()
        {
            return await
                (from vendedorHistorico in _db.VendedorHistorico
                 group vendedorHistorico by
                 new
                 {
                     vendedorHistorico.CodigoVendedor,
                     vendedorHistorico.NomeVendedor,
                     vendedorHistorico.UsuarioId
                 }
                 into agrupado
                 select new RankingVendedor
                 {
                     CodigoVendedor = agrupado.Key.CodigoVendedor,
                     NomeVendedor = agrupado.Key.NomeVendedor,
                     UsuarioId = agrupado.Key.UsuarioId,
                     SomaVolume = agrupado.Sum(x => x.VolumeHistorico)
                 }).OrderByDescending(x => x.SomaVolume).ToListAsync();
        }

        public async Task<IEnumerable<RankingVendedorSku>> RetornaValoresAgrupadoVendedorSkuPorUsuarioId(
            int usuarioId)
        {
            return await
                (from vendedorHistorico in _db.VendedorHistorico
                 where vendedorHistorico.UsuarioId == usuarioId
                 group vendedorHistorico by
                 new
                 {
                     vendedorHistorico.CodigoVendedor,
                     vendedorHistorico.NomeVendedor,
                     vendedorHistorico.CodigoSku,
                     vendedorHistorico.NomeSku,
                     vendedorHistorico.UsuarioId
                 }
                 into agrupado
                 select new RankingVendedorSku
                 {
                     CodigoVendedor = agrupado.Key.CodigoVendedor,
                     NomeVendedor = agrupado.Key.NomeVendedor,
                     CodigoSku = agrupado.Key.CodigoSku,
                     NomeSku = agrupado.Key.NomeSku,
                     UsuarioId = agrupado.Key.UsuarioId,
                     SomaVolume = agrupado.Sum(x => x.VolumeHistorico)
                 }).OrderByDescending(x => x.SomaVolume).ToListAsync();
        }

        public async Task<IEnumerable<RankingVendedorSku>> RetornaValoresAgrupadoVendedorSku()
        {
            return await
                (from vendedorHistorico in _db.VendedorHistorico
                 group vendedorHistorico by
                 new
                 {
                     vendedorHistorico.CodigoVendedor,
                     vendedorHistorico.NomeVendedor,
                     vendedorHistorico.CodigoSku,
                     vendedorHistorico.NomeSku,
                     vendedorHistorico.UsuarioId
                 }
                 into agrupado
                 select new RankingVendedorSku
                 {
                     CodigoVendedor = agrupado.Key.CodigoVendedor,
                     NomeVendedor = agrupado.Key.NomeVendedor,
                     CodigoSku = agrupado.Key.CodigoSku,
                     NomeSku = agrupado.Key.NomeSku,
                     UsuarioId = agrupado.Key.UsuarioId,
                     SomaVolume = agrupado.Sum(x => x.VolumeHistorico)
                 }).OrderByDescending(x => x.SomaVolume).ToListAsync();
        }

        public async Task<IEnumerable<RankingVendedorCliente>> RetornaValoresAgrupadoVendedorClientePorUsuarioId(
            int usuarioId)
        {
            return await
                (from vendedorHistorico in _db.VendedorHistorico
                 where vendedorHistorico.UsuarioId == usuarioId
                 group vendedorHistorico by
                 new
                 {
                     vendedorHistorico.CodigoVendedor,
                     vendedorHistorico.NomeVendedor,
                     vendedorHistorico.CodigoCliente,
                     vendedorHistorico.NomeCliente,
                     vendedorHistorico.UsuarioId
                 }
                 into agrupado
                 select new RankingVendedorCliente
                 {
                     CodigoVendedor = agrupado.Key.CodigoVendedor,
                     NomeVendedor = agrupado.Key.NomeVendedor,
                     CodigoCliente = agrupado.Key.CodigoCliente,
                     NomeCliente = agrupado.Key.NomeCliente,
                     UsuarioId = agrupado.Key.UsuarioId,
                     SomaVolume = agrupado.Sum(x => x.VolumeHistorico)
                 }).OrderByDescending(x => x.SomaVolume).ToListAsync();
        }

        public async Task<IEnumerable<RankingVendedorCliente>> RetornaValoresAgrupadoVendedorCliente()
        {
            return await
                (from vendedorHistorico in _db.VendedorHistorico
                 group vendedorHistorico by
                 new
                 {
                     vendedorHistorico.CodigoVendedor,
                     vendedorHistorico.NomeVendedor,
                     vendedorHistorico.CodigoCliente,
                     vendedorHistorico.NomeCliente,
                     vendedorHistorico.UsuarioId
                 }
                 into agrupado
                 select new RankingVendedorCliente
                 {
                     CodigoVendedor = agrupado.Key.CodigoVendedor,
                     NomeVendedor = agrupado.Key.NomeVendedor,
                     CodigoCliente = agrupado.Key.CodigoCliente,
                     NomeCliente = agrupado.Key.NomeCliente,
                     UsuarioId = agrupado.Key.UsuarioId,
                     SomaVolume = agrupado.Sum(x => x.VolumeHistorico)
                 }).OrderByDescending(x => x.SomaVolume).ToListAsync();
        }
    }
}
