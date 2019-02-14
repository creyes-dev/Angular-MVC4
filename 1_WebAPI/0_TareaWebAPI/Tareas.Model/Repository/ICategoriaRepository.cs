using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Model.Repository
{
    public interface ICategoriaRepository
    {
        void Add(Categoria categoria);
        void Remove(Categoria categoria);
        void Save(Categoria categoria);

        IEnumerable<Categoria> FindAll();
        Categoria FindBy(byte Id);
    }
}
