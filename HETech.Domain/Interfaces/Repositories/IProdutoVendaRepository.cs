using HETech.Domain.Models;


namespace HETech.Domain.Interfaces.Repositories
{
    public interface IProdutoVendaRepository
    {
       
        void CadastrarProdutoVenda(int vendaId, ProdutoVenda produtovenda);
        
    }
}
