using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteca.Infraestructura.UnitOfOWork;
using Biblioteca.Model;
using Biblioteca.Model.Repository;

namespace Biblioteca.Repository.EF.Repositorios
{
    public class TituloLibroRepository : Repository<Model.TituloLibro, string>, ITituloLibroRepository
    {
        public TituloLibroRepository(IUnitOfWork uow) : base(uow) { }

        public override Model.TituloLibro FindBy(string Id)
        {
            return GetObjectSet().FirstOrDefault<Model.TituloLibro>(b => b.ISBN == Id);
        }

        public override IQueryable<Model.TituloLibro> GetObjectSet()
        {
            return DataContextFactory.ObtenerBibliotecaDataContext().CreateObjectSet<Model.TituloLibro>();
        }

        public override string GetEntitySetName()
        {
            return "TitulosLibros";
        }

    }
}
