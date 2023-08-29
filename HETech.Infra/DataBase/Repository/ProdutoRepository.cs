

using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Models;
using HETech.Infra.DataBase.Context;

namespace HETech.Infra.DataBase.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly HETechDbContext _context;

        public ProdutoRepository(HETechDbContext context)
        {
            _context = context;
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Deletar(Produto produto)
        {
           _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public List<Produto> ObterPorCategoria(int categoriaId )
        {
            return _context.Produtos.Where(x => x.CategoriaId == categoriaId).ToList();
        }

        public Produto ObterPorId(int idproduto)
        {
            return _context.Produtos.FirstOrDefault(x => x.Id == idproduto);
        }

        public List<Produto> ObterTodos()
        {
            return _context.Produtos.ToList();
        }

        public bool ProdutoComNomeJaExiste(string nome)
        {
            return _context.Produtos.Any(p => p.Nome == nome);
        }
    }
}
