using HETech.Domain.Dtos;
using HETech.Domain.Exceptions;
using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Interfaces.Services;
using HETech.Domain.Models;
using HETech.Domain.Security;
using HETech.Domain.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;


namespace HETech.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ILogger<UsuarioService> _logger;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public UsuarioService(ILogger<UsuarioService> logger, IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public void AtualizarUsuario(UsuarioRequisicaoDto usuariodto)
        {
            var usuarioDb = _usuarioRepository.GetUsuarioPorId(usuariodto.Id);
                
            usuarioDb.Name = usuariodto.Name;
            usuarioDb.Email = usuariodto.Email;
            _usuarioRepository.AtualizarUsuario(usuarioDb);
        }

        public void DeletarUsuario(int idusuario)
        {

            var usuario = _usuarioRepository.GetUsuarioPorId(idusuario);
            _usuarioRepository.DeletarUsuario(usuario);

            
        }

        public List<Usuario> GetUsuarioNome(string nome)
        {
            //verificar se nome é vazio
            if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
            {
                throw new InserirDadosException("Nome inválido");
            }
            //verificar se nome existe no banco de dados
            List<Usuario> usuarios = _usuarioRepository.GetUsuarioNome(nome);
            if (usuarios.Count == 0)
            {
                throw new NaoExisteException("Nome não encontrado");
            }
           //retornar lista de usuarios de usuarioRespostaDto
           List<UsuarioRespostaDto> usuariosresposta = new List<UsuarioRespostaDto>();
            foreach (Usuario usuario in usuarios)
            {

                usuariosresposta.Add(new UsuarioRespostaDto
                {
                    Name = usuario.Name,
                    Email = usuario.Email,


                });
            }
                return usuarios;
            
        }


       
        public Usuario GetUsuarioPorId(int idusuario)
        {
            //verificar se id é vazio
            if (idusuario == 0)
            {
                throw new InserirDadosException("Id inválido");
            }
            //verificar se id existe no banco de dados
            Usuario usuario = _usuarioRepository.GetUsuarioPorId(idusuario);
            if (usuario == null)
            {
                throw new NaoExisteException("Id não encontrado");
            }
            //retornar usuario de usuarioRespostaDto
            UsuarioRespostaDto usuarioresposta = new UsuarioRespostaDto
            {
                Name = usuario.Name,
                Email = usuario.Email,
            };
           return usuario;

        }
        

        public Usuario GetUsuarioPorLoginSenha(string email, string senha)
        {

            //Verificar se usuário existe no banco de dados
            Usuario usuario = _usuarioRepository.GetUsuarioPorLoginSenha(email.ToLower(), MD5Utils.GerarHashMD5(senha));
            return usuario;
         
        }

        public LoginRespostaDto Login(LoginRequisicaoDto loginRequisicaoDto)
        {
            // Verificar se email e senha estão vazios ou inválidos
            if (string.IsNullOrEmpty(loginRequisicaoDto.Email) || string.IsNullOrWhiteSpace(loginRequisicaoDto.Email) ||
                !Regex.IsMatch(loginRequisicaoDto.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") ||
                string.IsNullOrEmpty(loginRequisicaoDto.Password) || string.IsNullOrWhiteSpace(loginRequisicaoDto.Password))
            {
                throw new InserirDadosException("Email ou senha inválidos");
            }

            // Verificar se o email existe no banco de dados e se as credenciais estão corretas
            Usuario usuario = _usuarioRepository.GetUsuarioPorLoginSenha(loginRequisicaoDto.Email.ToLower(), MD5Utils.GerarHashMD5(loginRequisicaoDto.Password));
            if (usuario != null)
            {

                return new LoginRespostaDto()
                {
                    Email = usuario.Email,
                    Name = usuario.Name,
                    Token = TokenService.GenerateToken(usuario, _configuration["JWT:SecretKey"])
                };
            }
            else
            {
                throw new NaoExisteException("Email ou senha inválidos");
            }

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
            //verificar se email existe no banco de dados
            return _usuarioRepository.VerificarEmail(email);

            
        }
    }
}
