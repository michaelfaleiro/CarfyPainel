using Api.Data.Mappings;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{

    public class DbApiContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrcamentoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}