using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Repository.EF.ContenedoresDataContext
{
    public interface IContenedorDataContext
    {
        TareasDataContext ObtenerDataContext();
        void Almacenar(TareasDataContext dataContext);
    }
}
