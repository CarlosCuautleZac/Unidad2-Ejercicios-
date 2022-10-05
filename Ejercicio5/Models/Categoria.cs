using System;
using System.Collections.Generic;

namespace Ejercicio5.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Cortometraje = new HashSet<Cortometraje>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Cortometraje> Cortometraje { get; set; }
    }
}
