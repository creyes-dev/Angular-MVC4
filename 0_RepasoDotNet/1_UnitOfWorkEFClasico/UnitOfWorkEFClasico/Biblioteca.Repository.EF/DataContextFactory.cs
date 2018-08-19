using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteca.Repository.EF.ContenedoresDataContext;

namespace Biblioteca.Repository.EF
{
    /* 
     Esta clase expone un método por cada Contenedor de DataContext que puede crear. Para cada contenedor asociará 
     el contenedor de datacontext con el datacontext que corresponda, en este caso solo hay un solo datacontext
     que es usado para acceder a colecciones de objetos de negocio pertenecientes al módulo de la biblioteca */
    public static class DataContextFactory
    {
        public static BibliotecaDataContext ObtenerBibliotecaDataContext()
        {
            // ContenedorDataContextFactory creará el Contenedor de DataContext que sea apropiado 
            // dependiendo del tipo de cliente, esta clase se abstrae de dichos detalles
            IContenedorDataContext _contenedorDataContext = ContenedorDataContextFactory.CrearContenedorDataContext();

            // Intentar obtener el DataContext del contenedor de DataContext
            BibliotecaDataContext bibliotecaDataContext = _contenedorDataContext.ObtenerDataContext();
            if (bibliotecaDataContext == null)
            {
                // El contenedor no posee un DataContext, proceder a crear uno y asociarlo al contenedor
                bibliotecaDataContext = new BibliotecaDataContext();
                _contenedorDataContext.Almacenar(bibliotecaDataContext);
            }

            // Devolver el DatContext creado
            return bibliotecaDataContext;
        }       
    }
}
