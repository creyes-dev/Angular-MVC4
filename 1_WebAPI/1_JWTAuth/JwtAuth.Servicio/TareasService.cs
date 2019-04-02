using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Tareas.Model;
//using Tareas.Model.Repository;
//using Tareas.Infraestructura.UnitOfWork;

namespace Tareas.Servicio
{
    public class TareasService
    {
        //private IEstadoRepository _estadoRepository;
        //private ICategoriaRepository _categoriaRepository;
        //private IPrioridadRepository _prioridadRepository;
        //private IUsuarioRepository _usuarioRepository;
        //private IUnitOfWork _unitOfWork;

        //public TareasService(IEstadoRepository estadoRepository,
        //                     ICategoriaRepository categoriaRepository,
        //                     IPrioridadRepository prioridadRepository,
        //                     IUsuarioRepository usuarioRepository,
        //                     IUnitOfWork unitOfWork)
        //{
        //    _estadoRepository = estadoRepository;
        //    _categoriaRepository = categoriaRepository;
        //    _prioridadRepository = prioridadRepository;
        //    _usuarioRepository = usuarioRepository;
        //    _unitOfWork = unitOfWork;
        //}
        
        //// Estados

        //public IEnumerable<Estado> ObtenerEstados()
        //{
        //    IEnumerable<Estado> estados;
        //    estados = _estadoRepository.FindAll();
        //    return estados;
        //}

        //// Categorias

        //public IEnumerable<Categoria> ObtenerCategorias()
        //{
        //    IEnumerable<Categoria> categorias;
        //    categorias = _categoriaRepository.FindAll();
        //    return categorias;
        //}

        //public void RegistrarCategoria(Model.Categoria categoria)
        //{
        //    _categoriaRepository.Add(categoria);
        //    _unitOfWork.Commit();
        //}

        //public void ModificarCategoria(Model.Categoria categoria)
        //{
        //    Model.Categoria categoriaModificar = _categoriaRepository.FindBy(categoria.Id);
        //    categoriaModificar.Nombre = categoria.Nombre;
        //    categoriaModificar.Descripcion = categoria.Descripcion;

        //    _categoriaRepository.Save(categoriaModificar);
        //    _unitOfWork.Commit();
        //}

        //public void EliminarCategoria(int id)
        //{
        //    byte idCategoria = (byte)id;

        //    Model.Categoria categoria = _categoriaRepository.FindBy(idCategoria);
        //    _categoriaRepository.Remove(categoria);
        //    _unitOfWork.Commit();
        //}

        //// Prioridades

        //public IEnumerable<Prioridad> ObtenerPrioridades()
        //{
        //    IEnumerable<Prioridad> prioridades;
        //    prioridades = _prioridadRepository.FindAll();
        //    return prioridades;
        //}

        //// Usuarios

        //// Crear un nuevo usuario
        //public void RegistrarUsuario(string apellido, string nombre)
        //{
        //    Usuario usuario = new Usuario();
        //    usuario.Apellido = apellido;
        //    usuario.Nombre = nombre;

        //    _usuarioRepository.Add(usuario);
        //    _unitOfWork.Commit();
        //}

        //public IEnumerable<Usuario> ObtenerUsuarios()
        //{
        //    IEnumerable<Usuario> usuarios;
        //    usuarios = _usuarioRepository.FindAll();
        //    return usuarios;
        //}
        
        //public Usuario ObtenerUsuario(string apellido, string nombre)
        //{
        //    Usuario usuario = _usuarioRepository.FindBy(apellido, nombre);
        //    return usuario;
        //}

    }
}
