//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteca.Repository.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Libro
    {
        public Libro()
        {
            this.Prestamo = new HashSet<Prestamo>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> IdMiembroPrestamo { get; set; }
        public string IdTitulo { get; set; }
    
        public virtual Miembro Miembro { get; set; }
        public virtual TituloLibro TituloLibro { get; set; }
        public virtual ICollection<Prestamo> Prestamo { get; set; }
    }
}
