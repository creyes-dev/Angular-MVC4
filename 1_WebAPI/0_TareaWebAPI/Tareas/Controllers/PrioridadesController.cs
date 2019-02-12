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
    public class PrioridadesController : ApiController
    {
        private readonly TareasService _tareasService;

        public PrioridadesController()
        {
            _tareasService = TareasServiceFactory.Crear();
        }

        // GET api/prioridades
        public IEnumerable<Model.Prioridad> Get()
        {
            return _tareasService.ObtenerPrioridades();
        }

    }
}
