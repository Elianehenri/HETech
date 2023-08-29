

using HETech.Domain.Models;

namespace HETech.Domain.Interfaces.Services
{
    public  interface IVendaService
    {
        void Deletar(int vendaId);//ok - venda
        void AdicionarVenda(Venda venda);//ok - venda
        Venda ObterPorId(int vendaId);//ok - venda
        ProdutoVenda ObterProdutoVendaPorId(int produtovendaId);//ok - venda
        List<Venda> ObtertodasVendas();//ok - venda
    }
}
