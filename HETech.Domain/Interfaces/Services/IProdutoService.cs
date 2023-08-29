

using HETech.Domain.Dtos;
using HETech.Domain.Models;

namespace HETech.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        void Cadastrar(ProdutoCadastrarDto produtocadastrar);//admin => ok POST  
        void Atualizar(ProdutoAtualizarDto produtoatualizar);//admin => ok PUT
        void Deletar(int idproduto);// admin => ok DELETE
        Produto ObterPorId(int idproduto); // => ok GET
        List<Produto> ObterTodos();// => ok GET
        List<Produto> ObterPorCategoria(int categoriaId );// => ok GET
        bool ProdutoComNomeJaExiste(string nome);// => ok POST
    }
}
