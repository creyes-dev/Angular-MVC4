using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tareas.Infraestructura;
using Tareas.Servicio;
using Tareas.Model;

namespace Tareas.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly TareasService _tareasService;

        public UsuariosController()
        {
            _tareasService = TareasServiceFactory.Crear();
        }

        // GET api/values
        public IEnumerable<Model.Usuario> Get()
        {
            return _tareasService.ObtenerUsuarios();
        }

    }
}
