using Microsoft.AspNetCore.Mvc;
using Unidad2Ejercicio3.Models;

namespace Unidad2Ejercicio3.Controllers
{
    public class HomeController : Controller
    {
        PresidentesContext context = new();
        public IActionResult Index()
        {
            

            var presientes = context.Presidentes.OrderBy(x => x.InicioGobierno);


            return View(presientes);
        }

        public IActionResult Biografia(Presidente presidente)
        {

            return View(presidente);
        }
    }
}
