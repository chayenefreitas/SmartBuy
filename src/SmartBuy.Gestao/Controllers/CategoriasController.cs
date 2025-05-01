using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBuy.Core.Entities;
using SmartBuy.Infrastructure;

namespace SmartBuy.Gestao
{
    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Utilizado AllowAnonymous para permitir a visualização das categorias de forma anonima
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create([FromForm] Categoria categoria)
        {
            //verifica validade e salva a categoria em contexto
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
                return View(categoria);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (_context.Categorias == null)
                return NotFound();

            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [Route("Categorias/editar/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (_context.Categorias == null)
                return NotFound();

            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);

        }

        [HttpPost("Categorias/editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria, Nome, Descricao")] Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.IdCategoria))
                        return NotFound();
                    else
                        throw;
                }
                TempData["Sucesso"] = "Produto editado com sucesso!";

                return RedirectToActionPermanent(nameof(Index));
            }
            else return View(categoria);
        }

        [Route("Categorias/excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Categorias == null)
                return NotFound();

            var categoria = await _context.Categorias.Where(x => x.IdCategoria == id).FirstOrDefaultAsync();

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost("Categorias/excluir/{id:int}")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            if (_context.Categorias == null)
                return Problem("Categoria é nula");
            var categoria = await _context.Categorias.FindAsync(id);

            //verifica se a categoria não é nula e busca se não existe algum produto utilizando a categoria, proibindo a exclusão de categorias em uso
            if (categoria != null && !_context.Produtos.Any(x => x.IdCategoria == id))
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //Mensagem do alerta foi definida direto na view
                TempData["Alerta"] = "";
                return View(categoria);
            }
        }

        //verifica a existencia da categoria
        private bool CategoriaExists(int id)
        {
            return (_context.Categorias?.Any(x => x.IdCategoria == id)).GetValueOrDefault();
        }
    }
}
