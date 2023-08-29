using HETech.Domain.Dtos;
using HETech.Domain.Exceptions;
using HETech.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HETech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaService _categoriaService;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaService categoriaService, ILogger<CategoriaController> logger)
        {
            _categoriaService = categoriaService;
            _logger = logger;
        }

        [HttpPost]
        [Route("cadastrar")]
        [Authorize(Roles = "Admin")]



        public IActionResult Post([FromBody] CategoriaCadastrarDto categoriadto)
        {
            try
            {
                if (_categoriaService.JaExisteCategoria(categoriadto.Nome))
                {
                    return BadRequest("Categoria já existe");
                }

                _categoriaService.Cadastrar(categoriadto);
                return Ok("Cadastrado com sucesso");
            }
            catch (InserirDadosException e)
            {
                return BadRequest("Dados inválidos: " + e.Message);
            }
            catch (JaexisteException e)
            {
                return BadRequest("Categoria já existe: " + e.Message);
            }
            catch (Exception e)
            {
                
                _logger.LogError("Ocorreu um erro ao cadastrar a categoria: " + e.Message);
                return StatusCode(500, "Erro interno no servidor");
            }
        }


        //metodo atualizar atualizar categoria
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Atualizar([FromBody] CategoriaAtualizarDto categoriadto)
        {
            try
            {
                _categoriaService.Atualizar(categoriadto);
                return Ok("Atualizado com sucesso");
            }
            catch (InserirDadosException e)
            {
                return BadRequest("Dados inválidos: " + e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro ao atualizar a categoria: " + e.Message);
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult Deletar(int idcategoria)
        {
            try
            {
                _categoriaService.Deletar(idcategoria);
                return Ok("Deletado com sucesso");
            }
            catch (NaoExisteException e)
            {
                return NotFound("Categoria não encontrada: " + e.Message);
            }
            catch (Exception e)
            {  
                _logger.LogError("Ocorreu um erro ao deletar a categoria: " + e.Message);
                return StatusCode(500, "Erro interno no servidor");
            }
        }


        [HttpGet]
        [Route("obterPorId")]
        public IActionResult ObterPorId(int idcategoria)
        {
            try
            {
                // Verificar se a categoria existe no banco
                if (!_categoriaService.NaoExisteCategoria(idcategoria))
                {
                    return BadRequest("Categoria não existe");
                }

                var categoria = _categoriaService.ObterPorId(idcategoria);
                return Ok(categoria);
            }
            catch (NaoExisteException e)
            {
                return NotFound("Categoria não encontrada: " + e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro ao obter a categoria por ID: " + e.Message);
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        //metodo obter todas as categorias
        [HttpGet]
        [Route("obterTodos")]
        public IActionResult ObterTodos()
        { 
            var categorias = _categoriaService.ObterTodos();
            return Ok(categorias);
        
        }

        }
}

