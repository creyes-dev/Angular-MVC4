//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tareas.Repository.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Tareas = new HashSet<Tarea>();
        }
    
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
