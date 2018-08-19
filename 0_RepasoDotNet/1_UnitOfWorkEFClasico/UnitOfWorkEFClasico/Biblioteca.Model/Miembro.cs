using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Infraestructura;

namespace Biblioteca.Model
{
    public class Miembro : IAggregateRoot
    {
        public Guid Id { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public virtual IList<Prestamo> Prestamos { get; set; }

        public void Devolver(Libro libro)
        {
            Prestamo loan = ObtenerPrestamoPendiente(libro);

            if (loan != null)
            {
                loan.MarcarComoDevuelto();
                libro.PrestadoAlMiembro = null;
            }
            else
                throw new ApplicationException(String.Format("No es posible devolver el libro '{0}'. El miembro '{1}' no tiene este libro para devolver.", libro.Id.ToString(), this.Id.ToString()));
        }

        private Prestamo ObtenerPrestamoPendiente(Libro libro)
        {
            return Prestamos.FirstOrDefault(l => (l.Libro.Id == libro.Id && l.NoHaDevuelto()));
        }

        public bool PuedeSerPrestado(Libro libro)
        {
            return (libro.PrestadoAlMiembro == null);
        }

        public Prestamo TomarPrestado(Libro libro)
        {
            Prestamo prestamo = default(Prestamo);
            if (PuedeSerPrestado(libro))
            {
                prestamo = PrestamoFactory.CrearPrestamo(libro, this);
                Prestamos.Add(prestamo);
            }
            else
            {
                throw new ApplicationException(String.Format("No es posible prestar el libro '{0}'. El libro está prestado al miembro '{1}'", libro.Id.ToString(), libro.PrestadoAlMiembro.Id.ToString())); 
            }
            return prestamo;
        }

    }
}
