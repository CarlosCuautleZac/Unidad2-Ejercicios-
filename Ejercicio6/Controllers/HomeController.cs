using Ejercicio6.Models;
using Ejercicio6.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio6.Controllers
{
    public class HomeController : Controller
    {
        villancicosContext context = new();

        public IActionResult Index()
        {
            var villancicos = context.Villancicos.Select(x => new IndexViewModel
            {
                Nombre = x.Nombre,
                Informacion = x.Información
            }).OrderBy(x=>x.Nombre);

            

            return View(villancicos);
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
