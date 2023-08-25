using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Models;
using HETech.Infra.DataBase.Context;

namespace HETech.Infra.DataBase.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HETechDbContext _context;

        public UsuarioRepository(HETechDbContext context)
        {
            _context = context;
        }

        //atualiza o usuario Put
        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            
        }

        //excluir um usuario
        public void DeletarUsuario(int idusuario)
        {
            _context.Usuarios.Remove(_context.Usuarios.Find(idusuario));
            _context.SaveChanges();
        }

        //faça a busca por nome
        public List<Usuario> GetUsuarioNome(string nome)
        {
            return _context.Usuarios.Where(u => u.Name.Contains(nome)).ToList();
        }

        //busca o usuario por id
        public Usuario GetUsuarioPorId(int idusuario)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == idusuario);
        }

        //busca o usuario por email e senha
        public Usuario GetUsuarioPorLoginSenha(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Password == senha);
        }
        
        //cadastra o usuario Post
        public void Salvar(Usuario usuario)
        {
           _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        //faz a verificação do email
        public bool VerificarEmail(string email)
        {
           return _context.Usuarios.Any(u => u.Email == email);
        }
    }
}
