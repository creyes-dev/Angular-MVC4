using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Infraestructura.UnitOfWork;
using Tareas.Model;
using Tareas.Model.Repository;
using Tareas.Repository.EF;
using Tareas.Repository.EF.Repositorios;


namespace Tareas.Servicio
{
    public class TareasServiceFactory
    {
        public static TareasService Crear()
        {
            IUnitOfWork uow;
            IUsuarioRepository usuarioRepository;

            uow = new UnitOfWork();
            usuarioRepository = new UsuarioRepository(uow);

            return new TareasService(usuarioRepository, uow);
        }
    }
}
