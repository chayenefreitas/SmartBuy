using Microsoft.AspNetCore.Mvc;

namespace SmartBuy.API.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
