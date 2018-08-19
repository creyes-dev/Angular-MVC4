using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Infraestructura.UnitOfOWork;
using Biblioteca.Model;
using Biblioteca.Model.Repository;

namespace Biblioteca.Repository.EF.Repositorios
{
    public class MiembroRepository : Repository<Model.Miembro, Guid>, IMiembroRepository
    {
        public MiembroRepository(IUnitOfWork uow) : base(uow) { }

        public override Model.Miembro FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<Model.Miembro>(m => m.Id == Id);
        }

        public override IQueryable<Model.Miembro> GetObjectSet()
        {
            return DataContextFactory.ObtenerBibliotecaDataContext().CreateObjectSet<Model.Miembro>();
        }

        public override string GetEntitySetName()
        {
            return "Miembros";
        }

    }
}
