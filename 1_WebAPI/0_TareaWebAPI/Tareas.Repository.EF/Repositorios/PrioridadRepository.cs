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
    public class PrioridadRepository : Repository<Model.Prioridad, byte>, IPrioridadRepository
    {
        public PrioridadRepository(IUnitOfWork uow) : base(uow) { }

        public override Model.Prioridad FindBy(byte Id)
        {
            return GetObjectSet().FirstOrDefault<Model.Prioridad>(p => p.Id == Id);
        }

        public override IQueryable<Model.Prioridad> GetObjectSet()
        {
            return DataContextFactory.ObtenerTareasDataContext().CreateObjectSet<Model.Prioridad>().OrderBy(c => c.Ordinal);
        }

        public override string GetEntitySetName()
        {
            return "Prioridades";
        }
    }
}