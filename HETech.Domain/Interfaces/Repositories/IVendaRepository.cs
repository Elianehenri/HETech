
using HETech.Domain.Models;

namespace HETech.Domain.Interfaces.Repositories
{
   public  interface IVendaRepository
    {
        void Deletar(int vendaId);//ok - venda
        void AdicionarVenda(Venda venda);//ok - venda
        Venda ObterPorId(int vendaId);//ok - venda
        
        List<Venda> ObtertodasVendas();//ok - venda
    }
}
