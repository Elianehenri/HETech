

using HETech.Domain.Dtos;
using HETech.Domain.Models;

namespace HETech.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {
        void Cadastrar(CategoriaCadastrarDto categoria);//admin POST => ok
        void Atualizar(CategoriaAtualizarDto categoriaatualizardto);//admin PUT => ok
        void Deletar(int idcategoria);//admin DELETE => ok
        Categoria ObterPorId(int idcategoria);//GET => ok
        List<Categoria> ObterTodos();// GET => ok
        bool JaExisteCategoria(string nome);
        bool NaoExisteCategoria(int idcategoria);
    }
}
