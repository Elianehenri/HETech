

namespace HETech.Domain.Dtos
{
    public class ProdutoVendaDto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int VendaId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal
        {
            get { return Quantidade * ValorUnitario; }
        }
    }
}
