using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Datos()
        {
            return View();
        }

        public IActionResult Reticula()
        {
            return View();
        }
    }
}
