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
    
    public partial class Prioridad
    {
        public Prioridad()
        {
            this.Tareas = new HashSet<Tarea>();
        }
    
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public short Ordinal { get; set; }
    
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
