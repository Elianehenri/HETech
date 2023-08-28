using HETech.Domain.Dtos;
using HETech.Domain.Exceptions;
using HETech.Domain.Interfaces.Services;
using HETech.Domain.Security;
using HETech.Infra.DataBase.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HETech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        //controller de log
        private readonly ILogger<AuthController> _logger;
        private readonly IUsuarioService _usuarioService;

        public AuthController(ILogger<AuthController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public ActionResult Post([FromBody] UsuarioRegistrarDto usuarioRegistrarDto)
        {

            try
            {
                _usuarioService.Salvar(usuarioRegistrarDto);
                return Ok("Cadastrado com sucesso");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro no registro: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDto()
                {
                    Description = "Ocorreu um erro ao fazer o registro",
                    Status = StatusCodes.Status500InternalServerError
                });
            }

        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult Login([FromBody] LoginRequisicaoDto loginRequisicaoDto)
        {

            try
            {
                if (loginRequisicaoDto == null)
                {
                    return BadRequest("Dados de login inválidos.");
                }

                var usuario = _usuarioService.Login(loginRequisicaoDto);
                return Ok(usuario);
            }
            catch (InserirDadosException ex)
            {
                _logger.LogError("Ocorreu um erro no login: " + ex.Message);
                return BadRequest("Email ou senha inválidos.");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro no registro: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDto()
                {
                    Description = "Ocorreu um erro ao fazer o registro",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }


        

        }
}
