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
    
    public partial class Tarea
    {
        public Tarea()
        {
            this.Usuario = new HashSet<Usuario>();
            this.Categoria = new HashSet<Categoria>();
        }
    
        public System.Guid Id { get; set; }
        public string Asunto { get; set; }
        public System.DateTime FechaDesde { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public Nullable<System.DateTime> FechaCompletada { get; set; }
        public byte IdEstado { get; set; }
        public byte IdPrioridad { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual Prioridad Prioridad { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Categoria> Categoria { get; set; }
    }
}
