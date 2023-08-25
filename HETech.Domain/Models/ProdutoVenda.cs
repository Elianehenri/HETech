using System.ComponentModel.DataAnnotations.Schema;

namespace HETech.Domain.Models
{
    public class ProdutoVenda
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int VendaId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        [NotMapped]
        public decimal ValorTotal
        {
            get { return Quantidade * ValorUnitario; }
        }
        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }
    }
}
