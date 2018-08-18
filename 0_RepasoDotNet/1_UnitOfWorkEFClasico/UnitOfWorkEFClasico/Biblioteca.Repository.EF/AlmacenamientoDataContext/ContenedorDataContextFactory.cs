using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Biblioteca.Repository.EF.AlmacenamientoDataContext
{

    /*  Esta clase crea un objeto de una clase específica que implementa la interfaz IContenedorDataContext
        dependiendo del tipo de contexto de datos que corresponda crear  
     */
    public class ContenedorDataContextFactory
    {
        public static IContenedorDataContext _contenedorDataContext;
        public static IContenedorDataContext CrearContenedorDataContext()
        {
            if (_contenedorDataContext == null)
            {
                if (HttpContext.Current == null)
                    _contenedorDataContext = new HiloContenedorDataContext();
                else
                    _contenedorDataContext = new HttpContenedorDataContext();
            }
            return _contenedorDataContext;
        }
    }
}
