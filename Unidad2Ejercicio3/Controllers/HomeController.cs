using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Biografia(string id)
        {
            //Si esta nulo el string que nos lleve al index
            if (string.IsNullOrWhiteSpace(id))
                return RedirectToAction("Index");

            //Debemos remplazar los guines del url a espacios en blanco para poder buscar 
            //Al objeto en la base de datos
            id = id.Replace("-", " ");

            //Carga explicita
            var presidente = 
                context.Presidentes.Include
                (x => x.IdPartidoPoliticoNavigation).
                Include(x => x.IdEstadoRepublicaNavigation)
                .FirstOrDefault(x => x.Nombre == id);

            //Si es presidente no es null que nos lleve a la pagina biografia
            if (presidente != null)
                return View(presidente);
            else
                return RedirectToAction("Index");
        }
    }
}
