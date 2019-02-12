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
    public class CategoriasController : ApiController
    {
        private readonly TareasService _tareasService;

        public CategoriasController()
        {
            _tareasService = TareasServiceFactory.Crear();
        }

        // GET api/categorias
        public IEnumerable<Model.Categoria> Get()
        {
            return _tareasService.ObtenerCategorias();
        }
    }
}
