using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Model;
using Biblioteca.Model.Repository;
using Biblioteca.Infraestructura.UnitOfOWork;

namespace Biblioteca
{
    public class BibliotecaService
    {
        private IUnitOfWork _uow;
        private ITituloLibroRepository _tituloLibroRepository;
        private ILibroRepository _libroRepository;
        private IMiembroRepository _miembroRepository;
        // Prestamo repository

        public BibliotecaService(ITituloLibroRepository tituloLibroRepository,
                                 ILibroRepository libroRepository,
                                 IMiembroRepository miembroRepository,
                                 IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _tituloLibroRepository = tituloLibroRepository;
            _miembroRepository = miembroRepository;
            _libroRepository = libroRepository;
            // Prestamo servicio new
        }

        // Crear un nuevo libro
        public void AgregarTituloLibro(string isbn, string titulo)
        {
            TituloLibro tituloLibro = new TituloLibro();
            tituloLibro.ISBN = isbn;
            tituloLibro.Titulo = titulo;

            _tituloLibroRepository.Add(tituloLibro);
            _uow.Commit();
        }

        // Crear un ejemplar de un libro
        public void AgregarLibro(string isbn)
        {
            TituloLibro tituloLibro = _tituloLibroRepository.FindBy(isbn);
            Libro libro = new Libro();
            libro.Titulo = tituloLibro;
            libro.Id = Guid.NewGuid();
            _libroRepository.Add(libro);
            _uow.Commit();
        }

        // Obtener todos los titulos de los libros
        public IList<TituloLibro> ObtenerTitulosLibros(string isbn = null)
        {
            IList<TituloLibro> titulos = new List<TituloLibro>();

            if (isbn != null)
            {
                IEnumerable<TituloLibro> titulosObtenidos;
                titulosObtenidos = _tituloLibroRepository.FindAll();
                titulos = titulosObtenidos.ToList<TituloLibro>();
            }
            else
            {
                TituloLibro tituloLibro = _tituloLibroRepository.FindBy(isbn);
                titulos.Add(tituloLibro);
            }
            return titulos;
        }

    }
}
