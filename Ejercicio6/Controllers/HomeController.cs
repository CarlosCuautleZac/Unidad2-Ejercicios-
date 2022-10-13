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
                Nombre = x.Nombre.Trim(),
                Informacion = x.Información
            }).OrderBy(x=>x.Nombre);

            

            return View(villancicos);
        }

        public IActionResult Villancico(string id)
        {


            var villancicoconespacios = id.Replace("-", " ");
            var villancico = context.Villancicos.Select(x=> new VillancicoViewModel()
            {
                Nombre=x.Nombre,
                Año=x.Anyo,
                Compositor=x.Compositor,
                VideoUrl=x.VideoUrl
            }).FirstOrDefault(x=>x.Nombre==villancicoconespacios);

            if (villancico == null)
                return RedirectToAction("Index");
            return View(villancico);
        }

        public IActionResult VillancicoLetra(string id)
        {
           


            return View();
        }
    }
}
