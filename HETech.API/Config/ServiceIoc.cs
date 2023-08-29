using HETech.Domain.Interfaces.Services;
using HETech.Domain.Services;

namespace HETech.API.Config
{
    public class ServiceIoc
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<IUsuarioService, UsuarioService>();
            builder.AddScoped<ICategoriaService, CategoriaService>();
            builder.AddScoped<IProdutoService, ProdutoService>();
            builder.AddScoped<IProdutoVendaService, ProdutoVendaService>();
            builder.AddScoped<IVendaService, VendaService>();
        }
    }
}
