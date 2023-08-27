using HETech.Domain.Dtos;
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
        private readonly IConfiguration _configuration;
        private readonly HETechDbContext _context;
        private readonly IUsuarioService _usuarioService;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration, HETechDbContext context, IUsuarioService usuarioService)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
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
            {       //verificar se esta preenchido correto
                if (!String.IsNullOrEmpty(loginRequisicaoDto.Password) && !String.IsNullOrEmpty(loginRequisicaoDto.Email) &&
                    //com espaço em branco
                    !String.IsNullOrWhiteSpace(loginRequisicaoDto.Password) && !String.IsNullOrWhiteSpace(loginRequisicaoDto.Email))
                {

                    //verificar se usuario e senha existe no banco de dados
                    var usuario = _usuarioService.GetUsuarioPorLoginSenha(loginRequisicaoDto.Email, loginRequisicaoDto.Password);

                    if (usuario != null)
                    {

                        return Ok(new LoginRespostaDto()
                        {
                            Email = usuario.Email,
                            Name = usuario.Name,
                            Token = TokenService.GenerateToken(usuario, _configuration["JWT:SecretKey"])
                        });

                    }
                    else
                    {
                        return BadRequest(new ErrorResponseDto()
                        {
                            Description = "Email ou senha inválido!",
                            Status = StatusCodes.Status400BadRequest
                        });
                    }
                }
                else
                {
                    return BadRequest(new ErrorResponseDto()
                    {
                        Description = "Usuário não preencheu os campos de login corretamente",
                        Status = StatusCodes.Status400BadRequest
                    });
                }
            }

            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro no login: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDto()
                {
                    Description = "Ocorreu um erro ao fazer o login",
                    Status = StatusCodes.Status500InternalServerError
                });
            }

            


        }

    }
}
