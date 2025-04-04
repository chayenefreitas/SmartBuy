using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartBuy.Models;

namespace SmartBuy.Gestao.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vendedor>()
                .Property(p => p.Nome)
                .HasMaxLength(200);

            builder.Entity<Categoria>()
                .Property(p => p.Descricao)
                .HasMaxLength(150);

            builder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasPrecision(18, 4);

            builder.Entity<Produto>()
                .Property(p => p.Estoque)
                .HasPrecision(18, 4);

            builder.Entity<Produto>()
                .Property(p => p.Nome)
                .HasMaxLength(150);

            builder.Entity<Produto>()
                .Property(p => p.Descricao)
                .HasMaxLength(250);


            base.OnModelCreating(builder);
        }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
