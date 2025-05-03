using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBuy.Infrastructure;

namespace SmartBuy.API.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ProdutosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProdutosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
