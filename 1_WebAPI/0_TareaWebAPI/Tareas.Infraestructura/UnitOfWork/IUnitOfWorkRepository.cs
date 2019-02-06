using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Infraestructura.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        void PersistirCreacion(IAggregateRoot entity);
        void PersistirModificacion(IAggregateRoot entity);
        void PersistirEliminacion(IAggregateRoot entity);
    }
}
