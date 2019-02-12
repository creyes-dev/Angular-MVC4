using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Model.Repository
{
    public interface ICategoriaRepository
    {
        void Add(Categoria usuario);
        void Remove(Categoria usuario);
        void Save(Categoria usuario);

        IEnumerable<Categoria> FindAll();
        Categoria FindBy(byte Id);
    }
}
