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

        // POST api/categorias
        public HttpResponseMessage Post(Model.Categoria categoria)
        {
            _tareasService.RegistrarCategoria(categoria);
            var response = Request.CreateResponse(HttpStatusCode.Created, categoria);
            return response;
        }

        // PUT api/categorias/5
        public HttpResponseMessage Put(int id, Model.Categoria categoria)
        {
            if (id != categoria.Id) return Request.CreateResponse(HttpStatusCode.BadRequest);

            _tareasService.ModificarCategoria(categoria);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/categorias/5
        public HttpResponseMessage Delete(int id)
        {
            _tareasService.EliminarCategoria(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
