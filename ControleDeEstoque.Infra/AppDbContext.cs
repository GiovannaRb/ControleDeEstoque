using ControleDeEstoque.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dados iniciais para teste
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Informática" },
                new Categoria { Id = 2, Nome = "Escritório" }
            );
        }
    }
}
