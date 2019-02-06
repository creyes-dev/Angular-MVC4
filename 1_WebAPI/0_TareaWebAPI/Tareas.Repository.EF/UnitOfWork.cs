using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Infraestructura;
using Tareas.Infraestructura.UnitOfWork;

namespace Tareas.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            // Persistir todas las operaciones de persistencia dentro de la transferencia
            DataContextFactory.ObtenerTareasDataContext().SaveChanges();
        }

        public void RegistrarModificado(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistirModificacion(entity);
        }

        public void RegistrarNuevo(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistirCreacion(entity);
        }

        public void RegistrarRemovido(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistirEliminacion(entity);
        }
    }
}
