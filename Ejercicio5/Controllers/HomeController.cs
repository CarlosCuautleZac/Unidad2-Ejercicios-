using Ejercicio5.Models;
using Ejercicio5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio5.Controllers
{
    public class HomeController : Controller
    {
        pixarContext context = new pixarContext();

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Peliculas")]
        public IActionResult Peliculas()
        {
            var peliculas = context.Pelicula.Select(x=> new PeliculasViewModel() { Id = x.Id, Nombre=x.Nombre}).OrderBy(x => x.Nombre);

            return View(peliculas);
        }

        [Route("Cortos")]
        public IActionResult Cortos()
        {
            return View();
        }
        [Route("/Pelicula/{id}")]
        public IActionResult Pelicula(string id)
        {
            var pelicula = context.Pelicula.FirstOrDefault(x => x.Nombre==id.Replace("-"," "));

            if (pelicula == null)
            {
                RedirectToAction("Peliculas");
            }

            return View();
        }
        [Route("Corto/{id}")]
        public IActionResult Corto()
        {
            return View();
        }

    }
}
