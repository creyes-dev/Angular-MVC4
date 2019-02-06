using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tareas.Repository.EF.ContenedoresDataContext
{
    public class ContenedorDataContextFactory
    {
        public static IContenedorDataContext _contenedorDataContext;
        public static IContenedorDataContext CrearContenedorDataContext()
        {
            if (_contenedorDataContext == null)
            {
                if (_contenedorDataContext == null)
                {
                    if (HttpContext.Current == null)
                        _contenedorDataContext = new HiloContenedorDataContext();
                    else
                        _contenedorDataContext = new HttpContenedorDataContext();
                }
            }
            return _contenedorDataContext;
        }
    }
}
