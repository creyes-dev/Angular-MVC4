using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    // Unit of Work delega tareas de persistencia que forman parte de una transacción
    public interface IUnitOfWork
    {
        void RegistrarModificado(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void RegistrarNuevo(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void RegistrarRemovido(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void Commit();
    }
}
