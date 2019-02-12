using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Model.Repository
{
    public interface IEstadoRepository
    {
        void Add(Estado estado);
        void Remove(Estado estado);
        void Save(Estado estado);

        IEnumerable<Estado> FindAll();
        Estado FindBy(byte Id);
    }
}
