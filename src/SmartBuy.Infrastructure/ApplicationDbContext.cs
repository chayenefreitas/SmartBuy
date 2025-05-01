using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartBuy.Core.Entities;

namespace SmartBuy.Infrastructure
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
                .HasKey(p => p.IdVendedor);

            builder.Entity<Vendedor>()
                .Property(p => p.Senha)
                .IsRequired(false);

            builder.Entity<Categoria>()
                .Property(p => p.Nome)
                .HasMaxLength(150);

            builder.Entity<Categoria>()
               .Property(p => p.Descricao)
               .HasMaxLength(250)
               .IsRequired(false);

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

            builder.Entity<Produto>()
                .Property(p => p.Imagem)
                .IsRequired(false);


            base.OnModelCreating(builder);
        }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
