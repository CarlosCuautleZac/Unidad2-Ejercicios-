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

        public IActionResult Cortos()
        {
            return View();
        }

        public IActionResult Pelicula()
        {
            return View();
        }

        public IActionResult Corto()
        {
            return View();
        }

    }
}
