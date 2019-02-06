using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Repository.EF.ContenedoresDataContext;

namespace Tareas.Repository.EF
{
    public class DataContextFactory
    {
        public static TareasDataContext ObtenerTareasDataContext()
        {
            IContenedorDataContext _contenedorDataContext = ContenedorDataContextFactory.CrearContenedorDataContext();

            TareasDataContext tareasDataContext = _contenedorDataContext.ObtenerDataContext();

            if (tareasDataContext == null)
            {
                tareasDataContext = new TareasDataContext();
            }

            return tareasDataContext;
        }

    }
}
