using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Infraestructura;

namespace Tareas.Model
{
    public class Usuario : IAggregateRoot
    {
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
