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

        public virtual TituloLibro Titulo { get; set; }

        public virtual Miembro PrestadoAlMiembro { get; set; }  
    }
}
