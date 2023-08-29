
using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Models;
using HETech.Infra.DataBase.Context;

namespace HETech.Infra.DataBase.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly HETechDbContext _context;

        public VendaRepository(HETechDbContext context)
        {
            _context = context;
        }
        public void AdicionarVenda(Venda venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
        }

        public void Deletar(int vendaId)
        {
            var venda = ObterPorId(vendaId);
            _context.Vendas.Remove(venda);
            _context.SaveChanges();
        }

        public Venda ObterPorId(int vendaId)
        {
            return _context.Vendas.Find(vendaId);

        }

        public ProdutoVenda ObterProdutoVendaPorId(int produtovendaId)
        {
            return _context.ProdutoVendas.Find(produtovendaId);
        }

        public List<Venda> ObtertodasVendas()
        {
           return _context.Vendas.ToList();
        }
    }
}
