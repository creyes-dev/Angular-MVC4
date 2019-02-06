using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Infraestructura.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegistrarModificado(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void RegistrarNuevo(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void RegistrarRemovido(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void Commit();
    }
}
