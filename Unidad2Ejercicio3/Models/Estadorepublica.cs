using System;
using System.Collections.Generic;

namespace Unidad2Ejercicio3.Models
{
    public partial class Estadorepublica
    {
        public Estadorepublica()
        {
            Presidentes = new HashSet<Presidente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Presidente> Presidentes { get; set; }
    }
}
