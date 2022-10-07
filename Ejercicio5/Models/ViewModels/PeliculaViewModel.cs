namespace Ejercicio5.Models.ViewModels
{
    public class PeliculaViewModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? NombreOriginal { get; set; }
        public string? Descripción { get; set; }
        public DateOnly? FechaEstreno { get; set; }

        public List<Personaje>? Personajes { get; set; }
        public PeliculaViewModel()
        {
            Personajes = new();
        }

}
}
