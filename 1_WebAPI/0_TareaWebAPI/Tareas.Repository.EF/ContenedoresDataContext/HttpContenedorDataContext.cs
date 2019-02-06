using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Tareas.Repository.EF.ContenedoresDataContext
{
    public class HttpContenedorDataContext : IContenedorDataContext
    {
        private string _dataContextKey = "DataContext";

        public TareasDataContext ObtenerDataContext()
        {
            TareasDataContext tareasDataContext = null;

            if (HttpContext.Current.Items.Contains(_dataContextKey))
            {
                tareasDataContext = (TareasDataContext)HttpContext.Current.Items[_dataContextKey];
            }
            return tareasDataContext;
        }

        public void Almacenar(TareasDataContext tareasDataContext)
        {
            if (HttpContext.Current.Items.Contains(_dataContextKey))
            {
                HttpContext.Current.Items[_dataContextKey] = tareasDataContext;
            }
            else
            {
                HttpContext.Current.Items.Add(_dataContextKey, tareasDataContext);
            }
        }

    }
}
