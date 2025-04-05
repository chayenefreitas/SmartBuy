using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Descricao");
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
            {
                //recarrega as categorias
                ViewBag.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Descricao", produto.IdCategoria);
                return View(produto);
            }
            
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.IdProduto == id);
            return View(produto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            return View(produto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] Produto produto)
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

        public async Task<IActionResult> Delete(int id)
        {
            var produto = _context.Produtos.Where(x => x.IdProduto == id).FirstOrDefault();
            _context.Remove(produto);
            await _context.SaveChangesAsync();

            return RedirectToActionPermanent(nameof(Index));
        }

    }
}
