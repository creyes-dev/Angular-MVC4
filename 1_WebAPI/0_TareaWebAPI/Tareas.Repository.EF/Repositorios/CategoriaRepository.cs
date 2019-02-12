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
    public class CategoriaRepository : Repository<Model.Categoria, byte>, ICategoriaRepository
    {
        public CategoriaRepository(IUnitOfWork uow) : base(uow) { }

        public override Model.Categoria FindBy(byte Id)
        {
            return GetObjectSet().FirstOrDefault<Model.Categoria>(c => c.Id == Id);
        }

        

        public override IQueryable<Model.Categoria> GetObjectSet()
        {
            return DataContextFactory.ObtenerTareasDataContext().CreateObjectSet<Model.Categoria>();
        }

        public override string GetEntitySetName()
        {
            return "Categorias";
        }
    }
}
