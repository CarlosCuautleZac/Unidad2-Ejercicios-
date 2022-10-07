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
            var peliculas = context.Pelicula.Select(x => new PeliculasViewModel() { Id = x.Id, Nombre = x.Nombre }).OrderBy(x => x.Nombre);

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
            var nombre = id.Replace("_", " ");

            var pelicula = context.Pelicula.Where(x=>x.Nombre==nombre).Select(x => new PeliculaViewModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                NombreOriginal = x.NombreOriginal,
                Descripción = x.Descripción,
                FechaEstreno = x.FechaEstreno,
            }).FirstOrDefault();



            if (pelicula == null)
            {
                return RedirectToAction("Peliculas");
            }
            else
            {
                var personajes = context.Apariciones.Include(x => x.IdPersonajeNavigation).Where(x => x.IdPelicula == pelicula.Id);

                foreach (var personaje in personajes)
                {
                    Personaje p = new()
                    {
                        Id = personaje.IdPersonajeNavigation.Id,
                        Nombre = personaje.IdPersonajeNavigation.Nombre
                    };

                    if (pelicula.Personajes != null)
                        pelicula.Personajes.Add(p);
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
