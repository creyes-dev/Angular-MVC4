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

        public virtual Miembro Miembro { get; set; }
        public virtual TituloLibro TituloLibro { get; set; }
        public virtual ICollection<Prestamo> Prestamo { get; set; }        
    }
}
