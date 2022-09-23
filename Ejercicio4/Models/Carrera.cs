using System;
using System.Collections.Generic;

namespace Ejercicio4.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Materia = new HashSet<Materia>();
        }

        public int Id { get; set; }
        public string Clave { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Plan { get; set; } = null!;
        public string Especialidad { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<Materia> Materia { get; set; }
    }
}
