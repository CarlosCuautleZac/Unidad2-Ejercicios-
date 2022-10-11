using Microsoft.AspNetCore.Mvc;

namespace Ejercicio6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Villancico()
        {
            return View();
        }

        public IActionResult VillancicoLetra()
        {
            return View();
        }
    }
}
