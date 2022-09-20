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

        public IActionResult Biografia(int id)
        {

            //Carga explicita
            var presidente = context.Presidentes.Include(x => x.IdPartidoPoliticoNavigation).Include(x => x.IdEstadoRepublicaNavigation).FirstOrDefault(x=>x.Id==id);



            return View(presidente);
        }
    }
}
