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
    public class UsuarioRepository : Repository<Model.Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWork uow) : base(uow) { }

        public override Model.Usuario FindBy(int Id)
        {
            return GetObjectSet().FirstOrDefault<Model.Usuario>(m => m.Id == Id);
        }

        public Model.Usuario FindBy(string apellido, string nombre)
        {
            return GetObjectSet().FirstOrDefault<Model.Usuario>(m => m.Apellido == apellido && m.Nombre == nombre);
        }

        public override IQueryable<Model.Usuario> GetObjectSet()
        {
            return DataContextFactory.ObtenerTareasDataContext().CreateObjectSet<Model.Usuario>();
        }

        public override string GetEntitySetName()
        {
            return "Usuarios";
        }
    }
}
