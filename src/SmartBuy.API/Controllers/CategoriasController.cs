using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBuy.Core.Entities;
using SmartBuy.Infrastructure;

namespace SmartBuy.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            if (_context.Categorias == null)
                return NotFound();

            return await _context.Categorias.ToListAsync();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            if (_context.Categorias == null)
                return NotFound();

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
                return NotFound();
            return categoria;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            if (_context.Categorias == null)
                return Problem("Erro ao criar uma categoria, contate o suporte!");

            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.IdCategoria }, categoria);

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria)
                return BadRequest();

            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                    return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            if (_context.Categorias == null)
                return NotFound();

            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null) return NotFound();

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return (_context.Categorias?.Any(e => e.IdCategoria == id)).GetValueOrDefault();
        }
    }
}
