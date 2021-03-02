
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.ValoresRank;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingVendedorController : ControllerBase
    {
        private IServicoVendedorHistorico servicoVendedorHistorico;
        private IRepositorioUsuario repositorioUsuario;
        private IServicoUsuario servicoUsuario;

        public RankingVendedorController(
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
                List<RankingVendedor> listaRankingVendedor = new List<RankingVendedor>();

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

                listaRankingVendedor =
                    (await servicoVendedorHistorico
                         .RetornaRankingVendedor(
                             usuario,
                                usuarioAdmin)
                                  ).ToList();

                return StatusCode((int)HttpStatusCode.OK, new { listaRankingVendedor });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Mensagem = "Houve um problema na hora de buscar as linhas." });
            }
        }

    }
}