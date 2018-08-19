using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteca.Infraestructura;
using Biblioteca.Infraestructura.UnitOfOWork;

namespace Biblioteca.Repository.EF
{
    /* La clase UnitOfWork delega todo el trabajo de persistencia a los IUnitOfWorkRepository que le llega
     * por parámetros, no hace mucho por si solo pero pero si hace el commit de todas las operaciones de persistencia 
     * que les delegó a los IUnitOfWorkRepository. Para que las operaciones sean persistidas se llama al método
     * SaveChanges de BibliotecaDataContext debido a que es subclase de ObjectContext */
    public class UnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            // Persistir todas las operaciones de persistencia dentro de la transferencia
            DataContextFactory.ObtenerBibliotecaDataContext().SaveChanges();
        }

        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistirModificacion(entity);
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistirCreacion(entity);
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistirEliminacion(entity);
        }
    }
}
