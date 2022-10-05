using System;
using System.Collections.Generic;

namespace Ejercicio5.Models
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Apariciones = new HashSet<Apariciones>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? NombreOriginal { get; set; }
        public string? Descripción { get; set; }
        public DateOnly? FechaEstreno { get; set; }

        public virtual ICollection<Apariciones> Apariciones { get; set; }
    }
}
