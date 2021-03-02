
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ploomes.Ranking.Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IRepositorioPerfil repositorioPerfil;
        private readonly IRepositorioUsuario repositorioUsuario;

        public PerfilController(
            IRepositorioPerfil repositorioPerfil,
                IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioPerfil = repositorioPerfil;
            this.repositorioUsuario = repositorioUsuario;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromHeader] string token)
        {
            try
            {
                List<Perfil> listaPerfil = new List<Perfil>();

                Usuario usuario =
                         await repositorioUsuario
                            .RetornaUsuarioPorToken(
                                token);

                if (usuario == null)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new { Mensagem = "Token inválido." });
                }

                listaPerfil =
                         (await repositorioPerfil
                            .BuscarTudoAssincrono())
                              .ToList();

                var listaRetornoPerfil =
                    (from perfil in listaPerfil
                     select new
                     {
                         Id = perfil.Id,
                         Nome = perfil.Nome,
                         Codigo = perfil.Codigo,
                         DataCriacao = perfil.DataCriacao,
                         DataModificacao = perfil.DataModificacao,
                         Ativo = perfil.Ativo
                     }).ToList();

                listaPerfil = null;

                return StatusCode((int)HttpStatusCode.OK, new { listaRetornoPerfil });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Mensagem = "Houve um problema na hora de buscar as linhas." });
            }
        }
    }
}