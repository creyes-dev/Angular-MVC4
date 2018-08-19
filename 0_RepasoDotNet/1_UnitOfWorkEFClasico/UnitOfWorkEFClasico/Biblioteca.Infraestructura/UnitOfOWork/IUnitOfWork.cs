using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Infraestructura.UnitOfOWork
{
    public interface IUnitOfWork
    {
        void RegistrarModificado(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void RegistrarNuevo(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void RegistrarRemovido(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void Commit();
    }
}
