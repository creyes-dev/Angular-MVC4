using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Biblioteca.Repository.EF.AlmacenamientoDataContext
{
    /*  Esta clase almacena colecciones de objetos de entidades de negocio 
        en un objeto HttpContext para que sean obtenidas por un cliente en un entorno web, 
        debido a que las colecciones se almacenan en un objeto HttpContext.Current.Items
        los mismos estarán disponibles para una solicitud http específica, pero no estarán
        disponibles para una sesión debido a que no se almacenan en Current.Session */

    public class HttpContenedorDataContext : IContenedorDataContext
    {
        private string _dataContextKey = "DataContext";

        public BibliotecaDataContext ObtenerDataContext()
        {
            BibliotecaDataContext bibliotecaDataContext = null;

            if (HttpContext.Current.Items.Contains(_dataContextKey))
            {
                bibliotecaDataContext = (BibliotecaDataContext)HttpContext.Current.Items[_dataContextKey];
            }

            return bibliotecaDataContext;           
        }

        public void Almacenar(BibliotecaDataContext bibliotecaDataContext)
        {
            if (HttpContext.Current.Items.Contains(_dataContextKey))
            {
                HttpContext.Current.Items[_dataContextKey] = bibliotecaDataContext;
            }
            else
            {
                HttpContext.Current.Items.Add(_dataContextKey, bibliotecaDataContext);
            }
        }

    }
}
