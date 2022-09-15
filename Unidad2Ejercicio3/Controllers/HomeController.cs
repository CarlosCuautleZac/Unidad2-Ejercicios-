using Microsoft.AspNetCore.Mvc;

namespace Unidad2Ejercicio3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
