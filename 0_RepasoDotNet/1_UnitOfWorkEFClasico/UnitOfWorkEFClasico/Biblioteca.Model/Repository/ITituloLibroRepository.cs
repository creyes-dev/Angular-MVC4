using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Repository
{
    public interface ITituloLibroRepository
    {
        void Add(TituloLibro tituloLibro);
        void Remove(TituloLibro tituloLibro);
        void Save(TituloLibro tituloLibro);

        TituloLibro FindBy(string Id);
        IEnumerable<TituloLibro> FindAll();
    }
}
