using HETech.Domain.Models;


namespace HETech.Domain.Interfaces.Repositories
{
    public interface IProdutoVendaRepository
    {
        void Cadastrar(int vendaId, ProdutoVenda produtovenda);
    }
}
