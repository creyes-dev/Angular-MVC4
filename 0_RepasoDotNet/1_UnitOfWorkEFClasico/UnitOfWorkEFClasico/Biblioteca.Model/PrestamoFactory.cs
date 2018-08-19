using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public static class PrestamoFactory
    {
        public static Prestamo CrearPrestamo(Libro libro, Miembro miembro)
        {
            Prestamo prestamo = new Prestamo();
            prestamo.Libro = libro;
            prestamo.Miembro = miembro;
            prestamo.FechaPrestamo = DateTime.Now;
            prestamo.FechaEstipuladaDevolucion = DateTime.Now.AddDays(7);
            return prestamo;
        }
    }
}
