using HETech.Domain.Dtos;
using HETech.Domain.Exceptions;
using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Interfaces.Services;
using HETech.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HETech.Domain.Services
{

    public class CategoriaService : ICategoriaService
    {
        private readonly ILogger<CategoriaService> _logger;
        private readonly ICategoriaRepository _categoriaRepository;
       

        public CategoriaService(ILogger<CategoriaService> logger, ICategoriaRepository categoriaRepository )
        {
            _logger = logger;
            _categoriaRepository = categoriaRepository;
            
        }

      
      
        public void Cadastrar(CategoriaCadastrarDto categoriadto)
        {
            if (categoriadto == null || string.IsNullOrWhiteSpace(categoriadto.Nome))
            {
                throw new InserirDadosException("Categoria inválida");
            }

            // Verificar se a categoria já existe no banco
            if (_categoriaRepository.JaExisteCategoria(categoriadto.Nome))
            {
                throw new JaexisteException("Categoria já existe");
            }

            // Criar a categoria
            var categoria = new Categoria
            {
                Nome = categoriadto.Nome
            };

            // Salvar categoria no banco
            _categoriaRepository.Cadastrar(categoria);
        }

        public void Atualizar(CategoriaAtualizarDto categoriaatualizardto)
        {
            var categoria = _categoriaRepository.ObterPorId(categoriaatualizardto.Id);

            // Verificar se a categoria é nula ou se o nome é inválido
            if (categoria == null || string.IsNullOrWhiteSpace(categoria.Nome))
            {
                throw new InserirDadosException("Categoria inválida");
            }

            // Atualizar os dados da categoria com base nos dados do objeto "CategoriaCadastrarDto"
            categoria.Nome = categoriaatualizardto.Nome;

            // Atualizar categoria no banco
            _categoriaRepository.Atualizar(categoria);
        }


        public void Deletar(int idcategoria)
        {
            var categoria = _categoriaRepository.ObterPorId(idcategoria);

            // Verificar se a categoria existe
            if (categoria == null)
            {
                throw new NaoExisteException("Categoria não encontrada");
            }

            // Deletar categoria
            _categoriaRepository.Deletar(categoria);
        }


        public Categoria ObterPorId(int idcategoria)
        {
            // Verificar se a categoria existe no banco
            var categoria = _categoriaRepository.ObterPorId(idcategoria);

            if (!_categoriaRepository.NaoExisteCategoria(idcategoria))
            {
                throw new NaoExisteException("Categoria não encontrada");
            }

            return categoria;
        }



        public List<Categoria> ObterTodos()
        {
            return _categoriaRepository.ObterTodos();
        }

        public bool JaExisteCategoria(string nome)
        {
            return _categoriaRepository.JaExisteCategoria(nome);

        }

        public bool NaoExisteCategoria(int idcategoria)
        {
            return _categoriaRepository.NaoExisteCategoria(idcategoria);

        }
    }
}
