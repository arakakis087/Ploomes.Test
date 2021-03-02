using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.ValoresRank;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.Login;

namespace Ploomes.Ranking.Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingVendedorClienteController : ControllerBase
    {
        private IServicoVendedorHistorico servicoVendedorHistorico;
        private IRepositorioUsuario repositorioUsuario;
        private IServicoUsuario servicoUsuario;

        public RankingVendedorClienteController(
            IServicoVendedorHistorico servicoVendedorHistorico,
               IRepositorioUsuario repositorioUsuario,
                  IServicoUsuario servicoUsuario)
        {
            this.servicoVendedorHistorico = servicoVendedorHistorico;
            this.repositorioUsuario = repositorioUsuario;
            this.servicoUsuario = servicoUsuario;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromHeader] string token)
        {
            try
            {
                List<RankingVendedorCliente> listaRankingVendedorCliente = new List<RankingVendedorCliente>();

                Usuario usuario =
                         await repositorioUsuario
                            .RetornaUsuarioPorToken(
                                token);

                if (usuario == null)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new { Mensagem = "Token inválido." });
                }

                bool usuarioAdmin =
                    await servicoUsuario
                      .ValidaPerfilAdmin(
                          usuario);

                listaRankingVendedorCliente =
                    (await servicoVendedorHistorico
                         .RetornaRankingVendedorCliente(
                             usuario,
                                usuarioAdmin)
                                  ).ToList();

                return StatusCode((int)HttpStatusCode.OK, new { listaRankingVendedorCliente });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Mensagem = "Houve um problema na hora de buscar as linhas." });
            }
        }
    }
}