

using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Models;
using HETech.Infra.DataBase.Context;

namespace HETech.Infra.DataBase.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly HETechDbContext _context;

        public CategoriaRepository(HETechDbContext context)
        {
            _context = context;
        }

        public void Atualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void Deletar(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            
        }

        public bool JaExisteCategoria(string nome)
        {
            return _context.Categorias.Any(c => c.Nome == nome);
            
        }

        public bool NaoExisteCategoria(int idcategoria)
        {
            return _context.Categorias.Any(c => c.Id == idcategoria);
            
        }

        public Categoria ObterPorId(int idcategoria)
        {
            return _context.Categorias.FirstOrDefault(c => c.Id == idcategoria);
        }

        public List<Categoria> ObterTodos()
        {
            return _context.Categorias.ToList();
        }
    }
}
