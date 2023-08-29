

namespace HETech.Domain.Dtos
{
    public class VendaDto
    {
        public int UsuarioId { get; set; }
        public DateTime DataVenda { get; set; }
        public List<ProdutoVendaDto> Produto { get; set; }

    }
}
