using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace Tareas.Repository.EF.ContenedoresDataContext
{
    public class HiloContenedorDataContext : IContenedorDataContext
    {
        private static readonly Hashtable _tareasDataContext = new Hashtable();

        public TareasDataContext ObtenerDataContext()
        {
            TareasDataContext bibliotecaDataContext = null;
            if (_tareasDataContext.Contains(ObtenerNombreHilo()))
            {
                bibliotecaDataContext = (TareasDataContext)_tareasDataContext[ObtenerNombreHilo()];
            }
            return bibliotecaDataContext;
        }

        public void Almacenar(TareasDataContext tareasDataContext)
        {
            if (_tareasDataContext.Contains(ObtenerNombreHilo()))
            {
                _tareasDataContext[ObtenerNombreHilo()] = tareasDataContext;
            }
            else
            {
                _tareasDataContext.Add(ObtenerNombreHilo(), tareasDataContext);
            }
        }

        private static string ObtenerNombreHilo()
        {
            return Thread.CurrentThread.Name;
        }
    }
}
