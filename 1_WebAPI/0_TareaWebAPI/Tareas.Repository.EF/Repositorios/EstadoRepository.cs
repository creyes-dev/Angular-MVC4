using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Infraestructura.UnitOfWork;
using Tareas.Model;
using Tareas.Model.Repository;

namespace Tareas.Repository.EF.Repositorios
{
    public class EstadoRepository : Repository<Model.Estado, byte>, IEstadoRepository
    {
        public EstadoRepository(IUnitOfWork uow) : base(uow) { }

        public override Model.Estado FindBy(byte Id)
        {
            return GetObjectSet().FirstOrDefault<Model.Estado>(e => e.Id == Id);
        }

        public override IQueryable<Model.Estado> GetObjectSet()
        {
            return DataContextFactory.ObtenerTareasDataContext().CreateObjectSet<Model.Estado>();
        }

        public override string GetEntitySetName()
        {
            return "Estados";
        }
    }
}
