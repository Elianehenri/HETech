

using HETech.Domain.Models;

namespace HETech.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        void Cadastrar(Categoria categoria);//admin POST => ok
        void Atualizar(Categoria categoria);//admin PUT => ok
        void Deletar(Categoria categoria);//admin DELETE => ok
        Categoria ObterPorId(int idcategoria);//GET => ok
        List<Categoria> ObterTodos();// GET => ok
        bool JaExisteCategoria(string nome);
        bool NaoExisteCategoria(int idcategoria);
    }
}
