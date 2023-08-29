using HETech.Domain.Dtos;
using HETech.Domain.Exceptions;
using HETech.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HETech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;


        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;

        }

        //somente admin pode cadastrar produto
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Cadastrar(ProdutoCadastrarDto produtodto)
        {
            try
            {
                _produtoService.Cadastrar(produtodto);
                return Ok("Produto cadastrado com sucesso!");
            }
            catch (InserirDadosException e)
            {
                return BadRequest("Dados inválidos: " + e.Message);
            }
            catch (JaexisteException e)
            {
                return BadRequest("Produto já existe: " + e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        //atualizar produto , somente admin pode atualizar
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Atualizar([FromBody] ProdutoAtualizarDto produtodto)
        {
            try
            {
                _produtoService.Atualizar(produtodto);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (InserirDadosException e)
            {
                return BadRequest("Dados inválidos: " + e.Message);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        //deletar produto , somente admin pode deletar
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _produtoService.Deletar(id);
                return Ok("Produto deletado com sucesso!");
            }
            catch (NaoExisteException e)
            {
                return BadRequest("Produto não encontrado: " + e.Message);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        //buscar produtos por categorias, todos podem buscar
        [HttpGet]
        [Route("obterPorCategoria")]
        [AllowAnonymous]
        public IActionResult ObterPorCategoria(int idcategoria)
        {
            try
            {
                var produtos = _produtoService.ObterPorCategoria(idcategoria);
                return Ok(produtos);
            }
            catch (NaoExisteException e)
            {
                return BadRequest("Categoria não encontrada: " + e.Message);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor");
            }

        }

        //buscar produto por id, todos podem buscar
        [HttpGet]
        [Route("obterPorId")]
        [AllowAnonymous]
        public IActionResult ObterPorId(int idproduto)
        {
            try
            {
                var produto = _produtoService.ObterPorId(idproduto);
                return Ok(produto);
            }
            catch (NaoExisteException e)
            {
                return BadRequest("Produto não encontrado: " + e.Message);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        //ObterTodos os produtos, todos podem buscar
        [HttpGet]
        [Route("obterTodos")]
        [AllowAnonymous]
        public IActionResult ObterTodos()
        {
            try
            {
                var produtos = _produtoService.ObterTodos();
                return Ok(produtos);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }
    }
}
