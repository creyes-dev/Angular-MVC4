using System;
using System.Data;
using System.Data.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Repository.EF
{
    public class TareasDataContext : ObjectContext
    {
        private ObjectSet<Model.Usuario> _usuarios;
        private ObjectSet<Model.Categoria> _categorias;

        public TareasDataContext()
            : base("name=TareasEntities", "TareasEntities")
        {
            _usuarios = CreateObjectSet<Model.Usuario>();
            _categorias = CreateObjectSet<Model.Categoria>();
        }

        public ObjectSet<Model.Usuario> Usuarios
        {
            get { return _usuarios; }
        }

        public ObjectSet<Model.Categoria> Categorias
        {
            get { return _categorias; }
        }
    }
}
