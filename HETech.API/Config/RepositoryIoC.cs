using HETech.Domain.Interfaces.Repositories;
using HETech.Domain.Interfaces.Services;
using HETech.Domain.Services;
using HETech.Infra.DataBase.Repository;

namespace HETech.API.Config
{
    public class RepositoryIoC
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<IUsuarioRepository, UsuarioRepository>();
           
            builder.AddScoped<ICategoriaRepository, CategoriaRepository>();
       
            builder.AddScoped<IProdutoRepository, ProdutoRepository>();
        
            builder.AddScoped<IProdutoVendaRepository, ProdutoVendaRepository>();
            
            builder.AddScoped<IVendaRepository, VendaRepository>();
           


        }
    }
}
