using Ejercicio5.Models;
using Ejercicio5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio5.Controllers
{
    public class HomeController : Controller
    {
        pixarContext context = new pixarContext();

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Seccion = "Inicio";
            return View();
        }

        [Route("Peliculas")]
        public IActionResult Peliculas()
        {
            ViewBag.Seccion = "Peliculas";
            var peliculas = context.Pelicula.Select(x => new PeliculasViewModel() { Id = x.Id, Nombre = x.Nombre }).OrderBy(x => x.Nombre);

            return View(peliculas);
        }

        [Route("Cortos")]
        public IActionResult Cortos()
        {
            ViewBag.Seccion = "Cortos";
            var categorias = context.Categoria.Include(x => x.Cortometraje).OrderBy(x => x.Nombre);

            return View(categorias);
        }
        [Route("/Pelicula/{id}")]
        public IActionResult Pelicula(string id)
        {
            var nombre = id.Replace("_", " ");

            var pelicula = context.Pelicula.Include(x => x.Apariciones).ThenInclude(x => x.IdPersonajeNavigation).FirstOrDefault(x => x.Nombre == nombre);


            if (pelicula == null)
            {
                return RedirectToAction("Peliculas");
            }
            else
            {
                return View(pelicula);
            }


        }
        [Route("Corto/{nombre}")]
        public IActionResult Corto(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return RedirectToAction("Cortos");

            var corto = context.Cortometraje.FirstOrDefault(x => x.Nombre == nombre.Replace("_", " "));

            if (corto == null)
                return RedirectToAction("Cortos");

            return View(corto);


        }

    }
}
