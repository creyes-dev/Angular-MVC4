using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Repository.EF.ContenedoresDataContext
{
    public class HiloContenedorDataContext : IContenedorDataContext
    {
        private static readonly Hashtable _bibliotecaDataContext = new Hashtable();

        public BibliotecaDataContext ObtenerDataContext()
        {
            BibliotecaDataContext bibliotecaDataContext = null;
            if (_bibliotecaDataContext.Contains(ObtenerNombreHilo()))
            {
                bibliotecaDataContext = (BibliotecaDataContext)_bibliotecaDataContext[ObtenerNombreHilo()];
            }
            return bibliotecaDataContext;
        }

        public void Almacenar(BibliotecaDataContext bibliotecaDataContext)
        {
            if (_bibliotecaDataContext.Contains(ObtenerNombreHilo()))
            {
                _bibliotecaDataContext[ObtenerNombreHilo()] = bibliotecaDataContext;
            }
            else
            {
                _bibliotecaDataContext.Add(ObtenerNombreHilo(), bibliotecaDataContext);
            }
        }

        private static string ObtenerNombreHilo()
        {
            return Thread.CurrentThread.Name;
        }
    }
}
