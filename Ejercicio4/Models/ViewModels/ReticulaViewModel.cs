namespace Ejercicio4.Models.ViewModels
{
    public class ReticulaViewModel
    {
        public string Carrera { get; set; } = "";
        public string Plan { get; set; } = "";
        public int CreditosTotales { get; set; }

        public IEnumerable<Materia>[] Semestres { get; set; }

        public ReticulaViewModel()
        {
            Semestres = new IEnumerable<Materia>[8];
        }

    }
}
