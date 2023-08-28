using HETech.Domain.Dtos;
using HETech.Domain.Exceptions;
using HETech.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HETech.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioService usuarioService, ILogger<UsuarioController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }
        //somente admin pode ver  os usuarios
        [HttpGet]
        [Route("GetUsuarioId")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUsuarioPorId(int idusuario)
        {
            try
            {
                var usuario = _usuarioService.GetUsuarioPorId(idusuario);
                return Ok(usuario);
            }
            catch (NaoExisteException ex)
            {
                _logger.LogError("Ocorreu um erro na pesquisa: " + ex.Message);
                return BadRequest("Erro ao buscar  usuario.");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro no registro: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDto()
                {
                    Description = "Erro ao buscar  usuario.",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        //pesquisar usuario por nome, somente admin pode ver
        [HttpGet]
        [Route("pesquisanome")]
        [Authorize(Roles = "Admin")]
        public IActionResult PesquisasUsuarioNome(string nome)
        {
            try
            {
                var usuario = _usuarioService.GetUsuarioNome(nome);
                return Ok(usuario);

            }
            catch (NaoExisteException ex)
            {
                _logger.LogError("Ocorreu um erro na pesquisa: " + ex.Message);
                return BadRequest("Erro ao buscar  usuario.");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro no registro: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDto()
                {
                    Description = "Erro ao buscar  usuario.",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }


        //metodo atualizar usuario
        //somente usuario pode atualizar
        [HttpPut]
        [Authorize(Roles = "Usuario")]
        public IActionResult AtualizarUsuario(UsuarioRequisicaoDto usuario)
        {
            try
            {
                _usuarioService.AtualizarUsuario(usuario);
                return Ok("Usuario atualizado com sucesso");
            }
            catch (InserirDadosException ex)
            {
                _logger.LogError("Ocorreu um erro na atualização: " + ex.Message);
                return BadRequest("Erro ao atualizar usuario.");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro na atualização: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDto()
                {
                    Description = "Erro ao atualizar usuario.",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        //metodo deletar usuario
        //somente admim pode deletar
        [HttpDelete]
        public IActionResult DeletarUsuario(int idusuario)
        {
            try
            {
                _usuarioService.DeletarUsuario(idusuario);
                return Ok("Usuario deletado com sucesso");
            }
            catch (InserirDadosException ex)
            {
                _logger.LogError("Ocorreu um erro na exclusão: " + ex.Message);
                return BadRequest("Erro ao deletar usuario.");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro na exclusão: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDto()
                {
                    Description = "Erro ao deletar usuario.",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
