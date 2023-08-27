using HETech.Domain.Dtos;
using HETech.Domain.Exceptions;
using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Interfaces.Services;
using HETech.Domain.Models;
using HETech.Domain.Security;
using HETech.Domain.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace HETech.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
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

                    //if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email) ||
            //    !Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") ||
            //    string.IsNullOrEmpty(senha) || string.IsNullOrWhiteSpace(senha))
            //{
            //    throw new InserirDadosException("Email ou senha inválidos");
            //}

            // Verificar se usuário existe no banco de dados
            Usuario usuario = _usuarioRepository.GetUsuarioPorLoginSenha(email.ToLower(), MD5Utils.GerarHashMD5(senha));
            return usuario;
            //if (usuario != null)
            //{
            //    return usuario;
            //}
            //else
            //{
            //    throw new InserirDadosException("Email ou senha inválidos");
            //}
        }


        public void Salvar(UsuarioRegistrarDto usuarioRegistrarDto)
        {
            //verificar  email, nome e senha vazio
            if (string.IsNullOrEmpty(usuarioRegistrarDto.Email) || string.IsNullOrWhiteSpace(usuarioRegistrarDto.Email) ||
                        !Regex.IsMatch(usuarioRegistrarDto.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            || string.IsNullOrEmpty(usuarioRegistrarDto.Name) || string.IsNullOrWhiteSpace(usuarioRegistrarDto.Name)
            || string.IsNullOrEmpty(usuarioRegistrarDto.Password) || string.IsNullOrWhiteSpace(usuarioRegistrarDto.Password))
            {
                throw new InserirDadosException("Email, nome e senha são invalidos");
            }
            //verificar se email  existe no banco de dados
            if (_usuarioRepository.VerificarEmail(usuarioRegistrarDto.Email))
            {
                throw new JaexisteException("Email já cadastrado");
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
