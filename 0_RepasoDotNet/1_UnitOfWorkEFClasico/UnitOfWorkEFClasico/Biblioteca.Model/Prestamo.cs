using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public class Prestamo
    {
        public Guid Id { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaEstipuladaDevolucion { get; set; }

        public DateTime? FechaDevolucion { get; set; }

        public virtual Libro Libro { get; set; }

        public Miembro Miembro { get; set; }

        public bool NoHaDevuelto()
        {
            return FechaDevolucion == null;
        }

        public void MarcarComoDevuelto()
        {
            FechaDevolucion = DateTime.Now;
        }
    }
}
