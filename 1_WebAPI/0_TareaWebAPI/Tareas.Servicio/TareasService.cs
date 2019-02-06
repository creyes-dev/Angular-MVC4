using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Model;
using Tareas.Model.Repository;
using Tareas.Infraestructura.UnitOfWork;

namespace Tareas.Servicio
{
    public class TareasService
    {
        private IUsuarioRepository _usuarioRepository;
        private IUnitOfWork _unitOfWork;

        public TareasService(IUsuarioRepository usuarioRepository,
                             IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        // Crear un nuevo usuario
        public void RegistrarUsuario(string apellido, string nombre)
        {
            Usuario usuario = new Usuario();
            usuario.Apellido = apellido;
            usuario.Nombre = nombre;

            _usuarioRepository.Add(usuario);
            _unitOfWork.Commit();
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            IEnumerable<Usuario> usuarios;
            usuarios = _usuarioRepository.FindAll();
            return usuarios;
        }
        
        public Usuario ObtenerUsuario(string apellido, string nombre)
        {
            Usuario usuario = _usuarioRepository.FindBy(apellido, nombre);
            return usuario;
        }

    }
}
