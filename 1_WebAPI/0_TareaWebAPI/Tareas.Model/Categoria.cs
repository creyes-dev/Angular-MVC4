using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Infraestructura;

namespace Tareas.Model
{
    public class Categoria : IAggregateRoot
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
