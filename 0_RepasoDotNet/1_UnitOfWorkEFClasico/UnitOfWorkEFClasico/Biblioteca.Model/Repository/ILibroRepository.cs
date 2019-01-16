using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Repository
{
    public interface ILibroRepository
    {
        void Add(Libro libro);
        void Remove(Libro libro);
        void Save(Libro libro);

        Libro FindBy(Guid Id);
    }
}
