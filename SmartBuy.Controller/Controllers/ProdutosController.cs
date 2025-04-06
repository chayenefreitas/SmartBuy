using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SmartBuy.Models;

namespace SmartBuy.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        public IActionResult Create()
        {
            //carregar o combobox de categorias
            CarregarCategorias();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create([FromForm] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
                return View(produto);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (_context.Produtos == null)
                return NotFound();

            var produto = _context.Produtos.FirstOrDefault(x => x.IdProduto == id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [Route("Produtos/editar/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            //carregar o combobox de categorias
            CarregarCategorias();
            var produto = await _context.Produtos.FindAsync(id);
            return View(produto);

        }

        [HttpPost("Produtos/editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduto, Nome, Descricao, Preco, Estoque, IdCategoria, Imagem")] Produto produto)
        {
            if (id != produto.IdProduto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
                return RedirectToActionPermanent(nameof(Index));
            }
            else return View(produto);
        }

        [Route("Produtos/excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Produtos == null)
                return NotFound();

            var produto = await _context.Produtos.Where(x => x.IdProduto == id).FirstOrDefaultAsync();

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [HttpPost("Produtos/excluir/{id:int}")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            if (_context.Produtos == null)
                return Problem("Produto é nulo");
            var produto = await _context.Produtos.FindAsync(id);

            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private void CarregarCategorias()
        {
            ViewBag.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nome");
        }
    }
}
