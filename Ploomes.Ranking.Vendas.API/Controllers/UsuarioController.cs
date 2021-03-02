
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IServicoUsuario servicoUsuario;

        public UsuarioController(
            IRepositorioUsuario repositorioUsuario,
              IServicoUsuario servicoUsuario)
        {
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
                List<Usuario> listaUsuario = new List<Usuario>();

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
                    listaUsuario =
                        (await repositorioUsuario
                           .BuscarTudoAssincrono())
                             .ToList();
                }
                else
                {
                    listaUsuario.Add(
                        (await repositorioUsuario
                           .BuscarPorIdAssincrono(
                               usuario.Id)));
                }

                var listaRetornoUsuario =
                    (from usuarios in listaUsuario
                     select new
                     {
                         Id = usuarios.Id,
                         Nome = usuarios.Nome,
                         Codigo = usuarios.Codigo,
                         DataCriacao = usuarios.DataCriacao,
                         DataModificacao = usuarios.DataModificacao,
                         Ativo = usuarios.Ativo,
                         PerfilId = usuarios.PerfilId,
                     }).ToList();

                listaUsuario = null;

                return StatusCode((int)HttpStatusCode.OK, new { listaRetornoUsuario });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Mensagem = "Houve um problema na hora de buscar as linhas." });
            }
        }
    }
}