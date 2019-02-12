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
    public class EstadosController : ApiController
    {
        private readonly TareasService _tareasService;

        public EstadosController()
        {
            _tareasService = TareasServiceFactory.Crear();
        }

        // GET api/estados
        public IEnumerable<Model.Estado> Get()
        {
            return _tareasService.ObtenerEstados();
        }
    }
}
