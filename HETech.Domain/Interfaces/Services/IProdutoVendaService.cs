

using HETech.Domain.Dtos;


namespace HETech.Domain.Interfaces.Services
{
    public interface IProdutoVendaService
    {
        void CadastrarProdutoVenda(int vendaId, ProdutoVendaDto produtovenda);
    }
}
