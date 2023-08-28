using HETech.Domain.Dtos;
using HETech.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETech.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        public Usuario GetUsuarioPorLoginSenha(string email, string senha);//ok - login
        public LoginRespostaDto Login(LoginRequisicaoDto loginRequisicaoDto);//login
        //UsuarioRespostaDto GetUsuarioPorId(int idusuario);//ok - usuario
        Usuario GetUsuarioPorId(int idusuario);//ok - usuario
        void AtualizarUsuario(UsuarioRequisicaoDto usuario);
        void Salvar(UsuarioRegistrarDto usuario);//ok - cadastro

        bool VerificarEmail(string email);//ok - cadastro

        List<Usuario> GetUsuarioNome(string nome);//ok - usuario

        void DeletarUsuario(int idusuario);
    }
}
