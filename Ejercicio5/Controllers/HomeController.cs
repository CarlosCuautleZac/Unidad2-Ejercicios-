using Microsoft.AspNetCore.Mvc;

namespace Ejercicio5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Peliculas()
        {
            return View();
        }

    }
}
