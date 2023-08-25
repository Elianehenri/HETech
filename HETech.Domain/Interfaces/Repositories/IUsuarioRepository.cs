using HETech.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETech.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioPorLoginSenha(string email, string senha);//ok - login
        Usuario GetUsuarioPorId(int idusuario);//ok - usuario

        void AtualizarUsuario(Usuario usuario);
        void Salvar(Usuario usuario);//ok - cadastro

        bool VerificarEmail(string email);//ok - cadastro

        List<Usuario> GetUsuarioNome(string nome);//ok - usuario

        void DeletarUsuario(int idusuario);
    }
}
