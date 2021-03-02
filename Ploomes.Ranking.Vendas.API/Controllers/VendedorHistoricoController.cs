using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;
using Ploomes.Ranking.Vendas.Dominio.Entidades.ObjetoValor.API;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Repositorio.Login;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.EstruturaVenda;
using Ploomes.Ranking.Vendas.Dominio.Interfaces.Servico.Login;

namespace Ploomes.Ranking.Vendas.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VendedorHistoricoController : ControllerBase
    {
        private IServicoVendedorHistorico servicoVendedorHistorico;
        private IRepositorioUsuario repositorioUsuario;
        private IServicoUsuario servicoUsuario;
        private IRepositorioVendedorHistorico repositorioVendedorHistorico;

        public VendedorHistoricoController(
            IServicoVendedorHistorico servicoVendedorHistorico,
              IRepositorioUsuario repositorioUsuario,
                IServicoUsuario servicoUsuario,
                  IRepositorioVendedorHistorico repositorioVendedorHistorico)
        {
            this.servicoVendedorHistorico = servicoVendedorHistorico;
            this.repositorioUsuario = repositorioUsuario;
            this.servicoUsuario = servicoUsuario;
            this.repositorioVendedorHistorico = repositorioVendedorHistorico;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(
              [FromHeader] string token,
                [FromBody] IEnumerable<VendedorClienteHistorico> listaVendedorClienteHistorico)
        {
            try
            { 

            if (listaVendedorClienteHistorico == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionRequired, new { Mensagem = "Objeto Json está vazio" });
            }
        

                Usuario usuario =
                         await repositorioUsuario
                            .RetornaUsuarioPorToken(
                                token);

                if(usuario == null)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new { Mensagem = "Token inválido." });
                }

            IEnumerable<VendedorHistorico> listaVendedorHistorico =
                await servicoVendedorHistorico
                .GeraVendedorHistorico(
                   listaVendedorClienteHistorico,
                     usuario.Id);

            string mensagem = await servicoVendedorHistorico
                .AdicionaVendedorHistorico(
                    listaVendedorHistorico,
                        usuario.Id);

                listaVendedorHistorico = null;

            if (mensagem == "Sucesso")
            {
                return StatusCode((int)HttpStatusCode.OK, new { Mensagem = "Sucesso ao adicionar as linhas na base." });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Mensagem = mensagem });
            }

            }
            catch(Exception)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Mensagem = "Houve um problema na hora adicionar novas linhas." });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromHeader] string token)
        {
            try
            {
                List<VendedorHistorico> listaVendedorHistorico = new List<VendedorHistorico>();

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

                if(usuarioAdmin == true)
                {
                    listaVendedorHistorico = 
                        (await repositorioVendedorHistorico
                           .BuscarTudoAssincrono())
                             .ToList();
                }
                else
                {
                    listaVendedorHistorico =
                        (await repositorioVendedorHistorico
                           .RetornaListaPorUsuarioId(
                               usuario.Id))
                             .ToList();
                }

                var listaVendedorHistoricoRetorno =
                    (from vendedorHistorico in listaVendedorHistorico
                     select new
                     {
                         vendedorHistorico.Id,
                         vendedorHistorico.CodigoVendedor,
                         vendedorHistorico.NomeVendedor,
                         vendedorHistorico.CodigoSku,
                         vendedorHistorico.NomeSku,
                         vendedorHistorico.CodigoCliente,
                         vendedorHistorico.NomeCliente,
                         vendedorHistorico.VolumeHistorico,
                         vendedorHistorico.UsuarioId,
                         vendedorHistorico.DataCriacao,
                         vendedorHistorico.DataModificacao,
                         vendedorHistorico.Ativo
                     }).ToList();

                listaVendedorHistorico = null;

                return StatusCode((int)HttpStatusCode.OK, new { listaVendedorHistoricoRetorno });
            }
            catch(Exception)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Mensagem = "Houve um problema na hora de buscar as linhas." });
            }
        }
    }
}