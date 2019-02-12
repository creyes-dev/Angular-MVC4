using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Model.Repository
{
    public interface IPrioridadRepository
    {
        void Add(Prioridad usuario);
        void Remove(Prioridad usuario);
        void Save(Prioridad usuario);

        IEnumerable<Prioridad> FindAll();
        Prioridad FindBy(byte Id);
    }
}
