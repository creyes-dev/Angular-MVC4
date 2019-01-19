using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteca.Infraestructura;

namespace Biblioteca.Model
{
    public class Libro : IAggregateRoot
    {
        public Guid Id { get; set; }
        public Nullable<Guid> IdMiembroPrestamo { get; set; }
        public string IdTitulo { get; set; }

        // Miembro es null si el libro actualmente no se encuentra prestado, contiene el miembro a quien se le 
        // ha prestado el libro actualmente
        public virtual Miembro Miembro { get; set; }
        public virtual TituloLibro TituloLibro { get; set; }
        public virtual ICollection<Prestamo> Prestamo { get; set; }      
        // Notar que TituloLibro y Miembro son marcados como virtuales para 
        // habilitar dichas propiedades para que soporten LazyLoading. 
        // LazyLoading: Quien contiene los datos no contiene todos los datos pero sabe como conseguirlos
        // reduce el tiempo de carga de los objetos
    }
}
