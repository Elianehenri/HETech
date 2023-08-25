using HETech.Domain.Dtos;
using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Interfaces.Services;
using HETech.Domain.Models;
using HETech.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETech.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public void AtualizarUsuario(UsuarioRequisicaoDto usuariodto)
        {
            var usuarioDb = _usuarioRepository.GetUsuarioPorId(usuariodto.Id);
            usuarioDb.Id = usuariodto.Id;
            _usuarioRepository.AtualizarUsuario(usuarioDb);
        }

        public void DeletarUsuario(int idusuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsuarioNome(string nome)
        {
            throw new NotImplementedException();
        }

        public UsuarioRespostaDto GetUsuarioPorId(int idusuario)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioPorLoginSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Salvar(UsuarioRegistrarDto usuarioRegistrarDto)
        {
            //verificar se existe email, nome e senha
            if (string.IsNullOrEmpty(usuarioRegistrarDto.Email) || string.IsNullOrEmpty(usuarioRegistrarDto.Name) || string.IsNullOrEmpty(usuarioRegistrarDto.Password))
            {
                throw new Exception("Email, nome e senha são obrigatórios");
            }

          

            //inserir usuario
            var usuario = new Usuario();
            usuario.Name = usuarioRegistrarDto.Name;
            //nao deixar email em maiusculo
            usuario.Email = usuarioRegistrarDto.Email.ToLower();
            usuario.Password = MD5Utils.GerarHashMD5(usuarioRegistrarDto.Password);
            usuario.Role = (Enums.Permissoes)usuarioRegistrarDto.Role;

            //salvar no banco
            _usuarioRepository.Salvar(usuario);
            
           



        }

        public bool VerificarEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
