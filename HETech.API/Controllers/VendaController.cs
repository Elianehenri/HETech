using HETech.Domain.Dtos;
using HETech.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HETech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }


        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Post(int vendaId, [FromBody] VendaDto vendadto)
        {
            try
            {
                _vendaService.AdicionarVenda(vendaId, vendadto);
                return Ok("Venda cadastrada com sucesso");

            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int vendaId)
        {
            try
            {
                _vendaService.Deletar(vendaId);
                return Ok("Venda excluída com sucesso");
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
      

        //criar metodo para ObtertodasVendas, somente admin
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("todasvendas")]
        public IActionResult ObterTodasVendas()
        { 
            try
            {
                var vendas = _vendaService.ObtertodasVendas();
                return Ok(vendas);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        }
}
