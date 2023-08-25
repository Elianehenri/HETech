using HETech.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HETech.Infra.DataBase.Context
{
    public class HETechDbContext : DbContext
    {
        //create constructor
        public HETechDbContext(DbContextOptions<HETechDbContext> options) : base(options)
        {
        }
        //create dbset
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdutoVenda> ProdutoVendas { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        //create method to configure the connection string
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    ////get the connection string from appsettings.json
        //    //var config = new ConfigurationBuilder()
        //    //    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
        //    //    .AddJsonFile("appsettings.json")
        //    //    .Build();

        //    ////define the database to use
        //    //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //}
        //create method to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //create the model for the database
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<ProdutoVenda>().ToTable("ProdutoVenda");
            modelBuilder.Entity<Venda>().ToTable("Venda");
        }
        




    }
}
