//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteca.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Libro
    {
        public Libro()
        {
            this.Prestamos = new HashSet<Prestamo>();
            this.TitulosLibro = new HashSet<TituloLibro>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdMiembroPrestamoActual { get; set; }
    
        public virtual Miembro Miembro { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
        public virtual ICollection<TituloLibro> TitulosLibro { get; set; }
    }
}
