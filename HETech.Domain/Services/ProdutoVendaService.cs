using HETech.Domain.Dtos;
using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Interfaces.Services;
using HETech.Domain.Models;

namespace HETech.Domain.Services
{
    public class ProdutoVendaService : IProdutoVendaService
    {
        private readonly IProdutoVendaRepository _produtoVendaRepository;

        public ProdutoVendaService(IProdutoVendaRepository produtoVendaRepository)
        {
            _produtoVendaRepository = produtoVendaRepository;
        }

 
        public void CadastrarProdutoVenda(int vendaId, ProdutoVendaDto produtovenda)
        {
            var produtoVenda = new ProdutoVenda
            {
                ProdutoId = produtovenda.ProdutoId,
                VendaId = vendaId,
                Quantidade = produtovenda.Quantidade,
                ValorUnitario = produtovenda.ValorUnitario
            };

            _produtoVendaRepository.CadastrarProdutoVenda( vendaId,produtoVenda);
            
        }
    }
}
