using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Models;
using HETech.Infra.DataBase.Context;


namespace HETech.Infra.DataBase.Repository
{
    public class ProdutoVendaRepository : IProdutoVendaRepository
    {

        private readonly HETechDbContext _context;

        public ProdutoVendaRepository(HETechDbContext context)
        {
            _context = context;
        }

        public void CadastrarProdutoVenda(int vendaId, ProdutoVenda produtovenda)
        {
            _context.ProdutoVendas.Add(produtovenda);
            _context.SaveChanges();

           
        }



    }
}
