using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETech.Domain.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataVenda { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ProdutoVenda> Produtos { get; set; }

    }
}
