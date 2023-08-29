using HETech.Domain.Models;



namespace HETech.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);//admin => ok POST  
        void Atualizar(Produto produto);//admin => ok PUT
        void Deletar(Produto produto);// admin => ok DELETE
        Produto ObterPorId(int idproduto); // => ok GET
        List<Produto> ObterTodos();// => ok GET
        List<Produto> ObterPorCategoria(int categoriaId );// => ok GET
        bool ProdutoComNomeJaExiste(string nome);// => ok POST
    }
}
