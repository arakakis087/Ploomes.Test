

using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaVenda;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor;
using Ploomes.Ranking.Vendas.Dominio.Servicos.EstruturaTabela;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.API;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.ValoresRank;

namespace Ploomes.Ranking.Vendas.Dominio.Servicos.EstruturaVenda
{
    public class ServicoVendedorHistorico : IServicoVendedorHistorico
    {
        private readonly IRepositorioTabela repositorioTabela;
        private readonly IRepositorioTabelaColuna repositorioTabelaColuna;
        private readonly ServicoTabelaColuna servicoTabelaColuna;
        private readonly IRepositorioVendedorHistorico repositorioVendedorHistorico;

        public ServicoVendedorHistorico(
            IRepositorioTabela repositorioTabela,
               IRepositorioTabelaColuna repositorioTabelaColuna,
                 ServicoTabelaColuna servicoTabelaColuna,
                    IRepositorioVendedorHistorico repositorioVendedorHistorico)
        {
            this.repositorioTabela = repositorioTabela;
            this.repositorioTabelaColuna = repositorioTabelaColuna;
            this.servicoTabelaColuna = servicoTabelaColuna;
            this.repositorioVendedorHistorico = repositorioVendedorHistorico;
        }

        public async Task<string> AdicionaVendedorHistorico(
            IEnumerable<VendedorHistorico> listaVendedorHistorico,
               int usuarioId)
        {
            try
            { 

               bool linhasValidadas =
                await ValidaLinhasVendedorHistorico(
                    listaVendedorHistorico,
                        usuarioId);

                if(linhasValidadas == true)
                {
                    await repositorioVendedorHistorico
                        .AdicionarBlocoAssincrono(
                           listaVendedorHistorico.ToList());

                    return "Sucesso";
                }

                return "Houve linhas inválidas, verifique os valores da tabela de ErrosVendedorHistorico";

            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<VendedorHistorico>> GeraVendedorHistorico(
            IEnumerable<VendedorClienteHistorico> listaVendedorClienteHistorico,
               int usuarioId)
        {
            return await Task.FromResult(
                (from vendedorHistorico in listaVendedorClienteHistorico
                 select new VendedorHistorico
                 {
                     Ativo = true,
                     Codigo = Guid.NewGuid().ToString(),
                     CodigoCliente = vendedorHistorico.CodigoCliente,
                     NomeCliente = vendedorHistorico.NomeCliente,
                     CodigoSku = vendedorHistorico.CodigoSku,
                     NomeSku = vendedorHistorico.NomeSku,
                     CodigoVendedor = vendedorHistorico.CodigoVendedor,
                     NomeVendedor = vendedorHistorico.NomeVendedor,
                     UsuarioId = usuarioId,
                     DataCriacao = DateTime.Now,
                     DataModificacao = DateTime.Now,
                     VolumeHistorico = vendedorHistorico.VolumeHistorico
                 }));

        }

        public async Task<IEnumerable<RankingVendedor>> RetornaRankingVendedor(
            Usuario usuario,
               bool usuarioAdmin)
        {
            List<RankingVendedor> listaRankingVendedor = new List<RankingVendedor>();
            try
            {
                if(usuarioAdmin == true)
                {
                    listaRankingVendedor = (await repositorioVendedorHistorico
                        .RetornaValoresAgrupadoVendedor()).ToList();
                }
                else
                {
                    listaRankingVendedor = (await repositorioVendedorHistorico
                        .RetornaValoresAgrupadoVendedorPorUsuarioId(
                            usuario.Id)).ToList();
                }


                int i = 0;

                foreach (var rank in listaRankingVendedor)
                {
                        i = i + 1;

                        rank.Rank = i;
                }


                return listaRankingVendedor;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<RankingVendedorSku>> RetornaRankingVendedorSku(
            Usuario usuario,
               bool usuarioAdmin)
        {
            List<RankingVendedorSku> listaRankingVendedorSku = new List<RankingVendedorSku>();
            try
            {
                if (usuarioAdmin == true)
                {
                    listaRankingVendedorSku = (await repositorioVendedorHistorico
                        .RetornaValoresAgrupadoVendedorSku()).ToList();
                }
                else
                {
                    listaRankingVendedorSku = (await repositorioVendedorHistorico
                        .RetornaValoresAgrupadoVendedorSkuPorUsuarioId(
                            usuario.Id)).ToList();
                }


                int i = 0;

                foreach (var rank in listaRankingVendedorSku)
                {
                    i = i + 1;

                    rank.Rank = i;
                }


                return listaRankingVendedorSku;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<RankingVendedorCliente>> RetornaRankingVendedorCliente(
            Usuario usuario,
               bool usuarioAdmin)
        {
            List<RankingVendedorCliente> listaRankingVendedorCliente = new List<RankingVendedorCliente>();
            try
            {
                if (usuarioAdmin == true)
                {
                    listaRankingVendedorCliente = (await repositorioVendedorHistorico
                        .RetornaValoresAgrupadoVendedorCliente()).ToList();
                }
                else
                {
                    listaRankingVendedorCliente = (await repositorioVendedorHistorico
                        .RetornaValoresAgrupadoVendedorClientePorUsuarioId(
                            usuario.Id)).ToList();
                }


                int i = 0;

                foreach (var rank in listaRankingVendedorCliente)
                {
                    i = i + 1;

                    rank.Rank = i;
                }


                return listaRankingVendedorCliente;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<bool> ValidaLinhasVendedorHistorico(
            IEnumerable<VendedorHistorico> listaVendedorHistorico,
               int usuarioId)
        {
            bool valido = true;
            List<string> listaValores = new List<string>();

            Tabela tabelaVendedorHistorico =
                await repositorioTabela
                    .BuscarPorCodigoAssincrono(
                       "VendedorHistorico");

            IEnumerable<TabelaColuna> listaTabelaColuna =
                await repositorioTabelaColuna
                    .RetornaTabelaColunaPorTabelaId(
                        tabelaVendedorHistorico.Id);

            foreach (var tabelaColuna in listaTabelaColuna)
            {
                bool colunaValida = true;

                listaValores =
                    (from itens in listaVendedorHistorico
                     select
                      (itens.GetType().GetProperty(tabelaColuna.Nome.Trim()).GetValue(itens)).ToString()).ToList();

                var propriedades = (from valores in listaValores
                                    select new ValoresPropriedades
                                    {
                                        Campo = tabelaColuna.Nome.Trim(),
                                        Tamanho = valores.Length,
                                        Valor = valores
                                    });

                colunaValida =
                    await servicoTabelaColuna.ValidaColunas(
                      propriedades,
                        tabelaVendedorHistorico,
                         tabelaColuna,
                            usuarioId);

                if (colunaValida == false)
                {
                    valido = false;
                }
            }

            return valido;
        }

        
    }
}
