using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteca.Infraestructura.UnitOfOWork;
using Biblioteca.Model.Repository;
using Biblioteca.Model;

namespace Biblioteca.Repository.EF.Repositorios
{
    public class LibroRepository : Repository<Model.Libro, Guid>, ILibroRepository
    {
        public LibroRepository(IUnitOfWork uow) : base(uow) { }

        public override Model.Libro FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<Model.Libro>(b => b.Id == Id);
        }

        public override IQueryable<Model.Libro> GetObjectSet()
        {
            return DataContextFactory.ObtenerBibliotecaDataContext().CreateObjectSet<Model.Libro>();
        }

        public override string GetEntitySetName()
        {
            return "Libros";
        }

    }
}
