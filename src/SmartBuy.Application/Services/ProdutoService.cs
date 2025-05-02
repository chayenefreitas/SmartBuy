using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartBuy.Core.Entities;
using SmartBuy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Application.Services
{
    public class ProdutoService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProdutoService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Produto> CreateAsync(Produto produto)
        {
            if(produto.Preco <= 0 || produto.Estoque <= 0)
                throw new ArgumentException("Preço e estoque não podem ser negativos.");

            var categoria = new SelectList(_dbContext.Categorias, "IdCategoria", "Nome");
            if (categoria == null)
                throw new ArgumentException("Categoria não encontrada.");

            var vendedor = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var produtoTemp = new Produto
            {
                Nome = produto.Nome,

            };
        }
    }
}
