using HETech.Domain.Dtos;
using HETech.Domain.Interfaces.Services;
using HETech.Domain.Security;
using HETech.Infra.DataBase.Context;
using Microsoft.AspNetCore.Mvc;

namespace HETech.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        //criar usuario com base no usuario service
        public ActionResult Post([FromBody] UsuarioRegistrarDto usuarioRegistrarDto)
        {
            _usuarioService.Salvar(usuarioRegistrarDto);
            return Ok();
        }

       
    }
}
