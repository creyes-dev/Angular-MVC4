using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Model.Repository
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);
        void Remove(Usuario usuario);
        void Save(Usuario usuario);

        Usuario FindBy(int Id);
        Usuario FindBy(string apellido, string nombre);
        IEnumerable<Usuario> FindAll();
    }
}
