using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Infraestructura
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> entidadesAgregadas;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> entidadesConCambios;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> entidadesEliminadas;

        public UnitOfWork()
        {
            entidadesAgregadas = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            entidadesConCambios = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            entidadesEliminadas = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        public void RegistrarModificado(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!entidadesConCambios.ContainsKey(entity))
            {
                entidadesConCambios.Add(entity, unitofWorkRepository);
            }
        }

        public void RegistrarNuevo(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!entidadesAgregadas.ContainsKey(entity))
            {
                entidadesAgregadas.Add(entity, unitofWorkRepository);
            };
        }

        public void RegistrarRemovido(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!entidadesEliminadas.ContainsKey(entity))
            {
                entidadesEliminadas.Add(entity, unitofWorkRepository);
            }
        }

        // Commit de la transacción
        public void Commit()
        {
            // Usar la clase TransactionScope que nos asegura efectuar operaciones en 
            // una transacción atómica
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (IAggregateRoot entity in this.entidadesAgregadas.Keys)
                {
                    this.entidadesAgregadas[entity].PersistirCreacion(entity);
                }

                foreach (IAggregateRoot entity in this.entidadesConCambios.Keys)
                {
                    this.entidadesConCambios[entity].PersistirActualizacion(entity);
                }

                foreach (IAggregateRoot entity in this.entidadesEliminadas.Keys)
                {
                    this.entidadesEliminadas[entity].PersistirEliminacion(entity);
                }

                scope.Complete(); 
            }
        }

    }
}
