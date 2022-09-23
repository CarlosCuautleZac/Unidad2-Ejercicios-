using Ejercicio4.Models;
using Ejercicio4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4.Controllers
{
    public class HomeController : Controller
    {
        mapacurricularContext context = new();

        public IActionResult Index()
        {
            //Aqui podemos llenar un viewmodel para no gstar memoria y solo usar lo que necesitamos
            var carreras = context.Carreras.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
            {
                Nombre = x.Nombre,
                Plan=x.Plan
            } );
            return View(carreras);
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
