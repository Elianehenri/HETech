

namespace HETech.Domain.Dtos
{
    public class ProdutoCadastrarDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }

    }
}
