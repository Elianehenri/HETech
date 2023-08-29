using HETech.Domain.Dtos;
using HETech.Domain.Exceptions;
using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Interfaces.Services;
using HETech.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HETech.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ProdutoService> _logger;
        private readonly IConfiguration _configuration;

        public ProdutoService(IProdutoRepository produtoRepository, ILogger<ProdutoService> logger, IConfiguration configuration)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
            _configuration = configuration;
        }

        public void Atualizar(ProdutoAtualizarDto produtoatualizar)
        {
            //obter o produto do banco
            Produto produto = _produtoRepository.ObterPorId(produtoatualizar.Id);

            //verificar se o produto existe
            if (produto == null)
            {
                throw new NaoExisteException("Produto não encontrado");
            }
            // nome não pode ser vazio
            if (string.IsNullOrWhiteSpace(produtoatualizar.Nome))
            {
                throw new InserirDadosException("Produto inválido");
            }
            //preço não pode ser negativo
            if (produtoatualizar.Preco <= 0)
            {
                throw new InserirDadosException("Preço inválido");
            }
            //quantidade não pode ser negativa
            if (produtoatualizar.Quantidade < 0)
            {
                throw new InserirDadosException("Quantidade inválida");
            }

            // Atualizar os dados do produto com base nos dados do objeto "produtodto"
            produto.Nome = produtoatualizar.Nome;
            produto.Descricao = produtoatualizar.Descricao;
            produto.Preco = produtoatualizar.Preco;
            produto.Quantidade = produtoatualizar.Quantidade;
            produto.CategoriaId = produtoatualizar.CategoriaId;

            // Salvar o produto no banco
            _produtoRepository.Atualizar(produto);

        }

        public void Cadastrar(ProdutoCadastrarDto produtoatualizar)
        {
            // Verificar se nome está vazio 
            if (string.IsNullOrWhiteSpace(produtoatualizar.Nome))
            {
                throw new InserirDadosException("Produto inválido");
            }

            // Verificar se o produto já existe no banco
            if (_produtoRepository.ProdutoComNomeJaExiste(produtoatualizar.Nome))
            {
                throw new JaexisteException("Produto já existe");
            }

            Produto produto = new Produto()
            {
                Nome = produtoatualizar.Nome,
                Descricao = produtoatualizar.Descricao,
                Preco = produtoatualizar.Preco,
                Quantidade = produtoatualizar.Quantidade,
                CategoriaId = produtoatualizar.CategoriaId
            };

            _produtoRepository.Cadastrar(produto);
        }

        
        public void Deletar(int idproduto)
        {
           
            Produto produto = _produtoRepository.ObterPorId(idproduto);
            if (produto != null)
            {
                //verificar se o produto existe
                if (produto == null)
                {
                    throw new NaoExisteException("Produto não encontrado");
                }
                _produtoRepository.Deletar(produto);

            }

        }

        public List<Produto> ObterPorCategoria(int categoriaId)
        {
           //listar produtos pro categorias
           return _produtoRepository.ObterPorCategoria(categoriaId);
        }

        public Produto ObterPorId(int idproduto)
        {
            return _produtoRepository.ObterPorId(idproduto);
        }

        public List<Produto> ObterTodos()
        {
            return _produtoRepository.ObterTodos();
        }

        public bool ProdutoComNomeJaExiste(string nome)
        {
            return _produtoRepository.ProdutoComNomeJaExiste(nome);


        }
    }
}
