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

            var pelicula = context.Pelicula.Include(x => x.Apariciones).Select(x => new PeliculaViewModel()
            {
                Id = x.Id,
                Nombre=x.Nombre,
                NombreOriginal = x.NombreOriginal,
                Descripción =  x.Descripción,
                FechaEstreno = x.FechaEstreno,
            }).FirstOrDefault();



            if (pelicula == null)
            {
                return RedirectToAction("Peliculas");
            }
            else
            {
                var personajes = context.Personaje.Include(x => x.Apariciones).Where(x => x.Id == pelicula.Id);

                foreach (var personaje in personajes)
                {
                    pelicula.Personajes.Add(personaje);
                }

                return View(pelicula);
            }

            
        }
        [Route("Corto/{id}")]
        public IActionResult Corto()
        {
            return View();
        }

    }
}
