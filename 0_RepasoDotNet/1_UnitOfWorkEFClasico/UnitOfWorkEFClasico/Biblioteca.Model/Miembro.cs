using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Infraestructura;

namespace Biblioteca.Model
{
    // Contiene logica para efectuar prestamos y devoluciones de libros. Un argumento valido a considerar es 
    // un miembro no toma prestado un libro por si mismo y que la propia biblioteca deberia efectuar la operacion
    // de prestamo, sin embargo, para mantener el codigo simple dejo esta funcionalidad asociada con un miembro
    public class Miembro : IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
        public virtual ICollection<Libro> Libro { get; set; }

        // Obtiene el prestamo relacionado al libro que se esta tratando de devolver. SI el prestamo existe, 
        // sera marcado como devuelto, y la propiedad IdMiembroPrestamo pasara a ser null. Si el libro no 
        // puede ser devuelto una excepcion es iniciada
        public void Devolver(Libro libro)
        {
            Prestamo loan = ObtenerPrestamoPendiente(libro);

            if (loan != null)
            {
                loan.MarcarComoDevuelto();
                libro.IdMiembroPrestamo = null;
            }
            else
                throw new ApplicationException(String.Format("No es posible devolver el libro '{0}'. El miembro '{1}' no tiene este libro para devolver.", libro.Id.ToString(), this.Id.ToString()));
        }

        private Prestamo ObtenerPrestamoPendiente(Libro libro)
        {
            return Prestamos.FirstOrDefault(l => (l.Libro.Id == libro.Id && l.NoHaDevuelto()));
        }
                
        // Establece si el libro que se intenta prestar se encuentra prestado 
        public bool PuedeSerPrestado(Libro libro)
        {
            return (libro.IdMiembroPrestamo == null);
        }

        // Este metodo primero especifica si un libro puede ser prestado. Si efectivamente se puede prestar 
        // un prestamo es instanciado utlizando el PrestamoFactory, de lo contrario se iniciara una excepción
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
                throw new ApplicationException(String.Format("No es posible prestar el libro '{0}'. El libro está prestado al miembro '{1}'", libro.Id.ToString(), libro.IdMiembroPrestamo.ToString())); 
            }
            return prestamo;
        }

    }
}
