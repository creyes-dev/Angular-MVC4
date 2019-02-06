using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Model
{
    public class Tarea
    {
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
        public virtual ICollection<Categoria> Categoria { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
