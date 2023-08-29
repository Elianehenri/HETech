

using HETech.Domain.Models;

namespace HETech.Domain.Interfaces.Services
{
    public interface IProdutoVendaService
    {
        void Cadastrar(int vendaId, ProdutoVenda produtovenda);
    }
}
