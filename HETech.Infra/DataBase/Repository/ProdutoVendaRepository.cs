using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Models;
using HETech.Infra.DataBase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETech.Infra.DataBase.Repository
{
    public class ProdutoVendaRepository : IProdutoVendaRepository
    {

        private readonly HETechDbContext _context;

        public ProdutoVendaRepository(HETechDbContext context)
        {
            _context = context;
        }

        public void Cadastrar(int vendaId, ProdutoVenda produtovenda)
        {
            _context.ProdutoVendas.Add(produtovenda);
            _context.SaveChanges();
        }
    }
}
