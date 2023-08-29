

using HETech.Domain.Dtos;
using HETech.Domain.Exceptions;
using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Interfaces.Services;
using HETech.Domain.Models;

namespace HETech.Domain.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProdutoVendaRepository _produtoVendaRepository;

        public VendaService(IVendaRepository vendaRepository, IUsuarioRepository usuarioRepository, IProdutoVendaRepository produtoVendaRepository)
        {
            _vendaRepository = vendaRepository;
            _usuarioRepository = usuarioRepository;
            _produtoVendaRepository = produtoVendaRepository;
        }

        public void AdicionarVenda(int vendaId, VendaDto vendadto)
        {
            var usuario = _usuarioRepository.GetUsuarioPorId(vendadto.UsuarioId);

            // Verifica se o usuário logado corresponde ao ID do usuário informado na solicitação
            if (vendadto.UsuarioId != usuario.Id)
            {
                throw new Exception("Não permitido");
            }

            // Criar a venda com o id do usuário e data da venda
            var venda = new Venda
            {
                UsuarioId = vendadto.UsuarioId,
                DataVenda = DateTime.Now,
            };

            // Adicionar a venda ao repositório
            _vendaRepository.AdicionarVenda(venda);

            // Criar e adicionar produtos à venda
            foreach (var item in vendadto.Produto)
            {
                var produtovenda = new ProdutoVenda
                {
                    VendaId = venda.Id,          // Relacionar o produto à venda criada
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.ValorUnitario
                };
                _produtoVendaRepository.CadastrarProdutoVenda(vendaId, produtovenda);
            }
        }



        public void Deletar(int vendaId)
        {
            // Verifica se a venda existe
            var venda = _vendaRepository.ObterPorId(vendaId);
            if (venda == null)
            {
                throw new NaoExisteException("Venda nao encontrada");

            }
            _vendaRepository.Deletar(vendaId);


           
        }

        public Venda ObterPorId(int vendaId)
        {
            return _vendaRepository.ObterPorId(vendaId);

        }


       

        public List<Venda> ObtertodasVendas()
        {
            return _vendaRepository.ObtertodasVendas();
        }

       
    }
}
