using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartBuy.Core.Entities;
using SmartBuy.Infrastructure;

namespace SmartBuy.Core.Configurations
{
    public static class DbMigrationHelpers
    {
        public static void UseDbMigrationHelpers(this WebApplication app)
        {
            DbMigrationHelpers.EnsureSeedData(app).Wait();
        }


        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (env.IsDevelopment() || env.IsStaging())
            {
                await context.Database.MigrateAsync();

                await EnsureSeedProducts(context);
            }
        }
        private static async Task EnsureSeedProducts(ApplicationDbContext context)
        {
            //await context.Categorias.AddAsync(new Categoria { Nome = "Livros", Descricao = "E-books" });

            //await context.SaveChangesAsync();
        }
    }
}
