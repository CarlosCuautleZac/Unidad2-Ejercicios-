using Ejercicio4.Models;
using Ejercicio4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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
                Plan = x.Plan
            });
            return View(carreras);
        }

        public IActionResult Datos(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectToAction("Index");

            string carrera = id.Replace("-", " ");

            var carreraelegida = context.Carreras.FirstOrDefault(x => x.Nombre == carrera);

            if (carreraelegida == null)
                return RedirectToAction("Index");

            return View(carreraelegida);
        }

        public IActionResult Reticula(string id)
        {
            if (string.IsNullOrWhiteSpace(id))//Si no me dicen el nombre de la carrera 
            {
                return RedirectToAction("Index");//Lo mandamos a index
            }

            id = id.Replace("-", " ");

            var carrera = context.Carreras.Include(x => x.Materia).FirstOrDefault(x => x.Nombre == id);

            if (carrera == null)
                return RedirectToAction("Index");//Si no existe lo mandamos a index

            ReticulaViewModel vm = new();
            vm.Carrera = carrera.Nombre;
            vm.Plan = carrera.Plan;
            vm.CreditosTotales = carrera.Materia.Sum(x => x.Creditos);

            for (int i = 0; i < 10; i++)
            {
                vm.Semestres[i] = carrera.Materia.Where(x => x.Semestre == i + 1).ToList();
            }

            //esta consulta funciona igual que el for de arriba

            //vm.Semestres = Enumerable.Range(0, 10).Select(x => carrera.Materia.Where(y=>y.Semestre==x+1).ToList()).ToArray();

            return View(vm);
        }
    }
}
