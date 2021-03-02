using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.Login;

namespace Ploomes.Ranking.Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrosVendedorHistoricoController : ControllerBase
    {
        private readonly IRepositorioErrosVendedorHistorico repositorioErrosVendedorHistorico;
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IServicoUsuario servicoUsuario;

        public ErrosVendedorHistoricoController(
            IRepositorioErrosVendedorHistorico repositorioErrosVendedorHistorico,
                IRepositorioUsuario repositorioUsuario,
                  IServicoUsuario servicoUsuario)
        {
            this.repositorioErrosVendedorHistorico = repositorioErrosVendedorHistorico;
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
                List<ErrosVendedorHistorico> listaErrosVendedorHistorico = new List<ErrosVendedorHistorico>();

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

                if (usuarioAdmin == true)
                {
                    listaErrosVendedorHistorico =
                        (await repositorioErrosVendedorHistorico
                           .BuscarTudoAssincrono())
                             .ToList();
                }
                else
                {
                    listaErrosVendedorHistorico.AddRange(
                        (await repositorioErrosVendedorHistorico
                             .RetornaListaPorUsuarioId(
                                 usuario.Id)));
                }

                var listaRetornoErrosVendedorHistorico =
                    (from errosVendedorHistorico in listaErrosVendedorHistorico
                     select new
                     {
                         Id = errosVendedorHistorico.Id,
                         errosVendedorHistorico.Mensagem,
                         DataCriacao = errosVendedorHistorico.DataCriacao,
                         DataModificacao = errosVendedorHistorico.DataModificacao,
                         Ativo = errosVendedorHistorico.Ativo
                     }).ToList();

                listaErrosVendedorHistorico = null;

                return StatusCode((int)HttpStatusCode.OK, new { listaRetornoErrosVendedorHistorico });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Mensagem = "Houve um problema na hora de buscar as linhas." });
            }
        }
    }
}