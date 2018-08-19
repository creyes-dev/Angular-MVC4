using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteca.Infraestructura;
using Biblioteca.Infraestructura.UnitOfOWork;
using System.Data.Objects;

namespace Biblioteca.Repository.EF.Repositorios
{
    public abstract class Repository<T, EntityKey> : IUnitOfWorkRepository where T : IAggregateRoot
    {
        private IUnitOfWork _uow;

        public Repository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(T entity)
        {
            _uow.RegistrarNuevo(entity, this);
        }

        public void Remove(T entity)
        {
            _uow.RegistrarRemovido(entity, this);
        }

        public void Save(T entity)
        {
            _uow.RegistrarModificado(entity, this);
        }

        public abstract IQueryable<T> GetObjectSet();

        public abstract string GetEntitySetName();

        public abstract T FindBy(EntityKey Id);

        public IEnumerable<T> FindAll()
        {
            return GetObjectSet().ToList<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            return GetObjectSet().Skip(index).Take(count).ToList<T>();
        }

        // Implementación de la interfaz IUnitOfWorkRepository
        public void PersistirCreacion(IAggregateRoot entity)
        {
            DataContextFactory.ObtenerBibliotecaDataContext().AddObject(GetEntitySetName(), entity);
        }

        public void PersistirModificacion(IAggregateRoot entity)
        {
            // No hacer nada mientras EF haga un seguimiento de los cambios de estado de los objetos
            // contenidos en colecciones del DataContext
        }

        public void PersistirEliminacion(IAggregateRoot entity)
        {
            DataContextFactory.ObtenerBibliotecaDataContext().DeleteObject(entity);
        }

    }
}
