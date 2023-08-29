

using HETech.Domain.Dtos;
using HETech.Domain.Models;

namespace HETech.Domain.Interfaces.Services
{
    public  interface IVendaService
    {
        void Deletar(int vendaId);//ok - venda
        void AdicionarVenda(int vendaId, VendaDto vendadto);//ok - venda- Post
        Venda ObterPorId(int vendaId);//ok - venda
            
        List<Venda> ObtertodasVendas();//ok - venda
    }
}
