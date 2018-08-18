using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Repository.EF.ContenedoresDataContext
{
    public interface IContenedorDataContext
    {
        BibliotecaDataContext ObtenerDataContext();
        void Almacenar(BibliotecaDataContext dataContext);
    }
}
