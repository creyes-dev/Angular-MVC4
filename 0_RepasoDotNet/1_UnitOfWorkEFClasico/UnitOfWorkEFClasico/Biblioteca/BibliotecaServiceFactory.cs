using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Biblioteca.Model;
using Biblioteca.Model.Repository;
using Biblioteca.Infraestructura.UnitOfOWork;

namespace Biblioteca
{
    public static class BibliotecaServiceFactory
    {
        public static BibliotecaService Crear()
        {
            IUnitOfWork uow;
            ILibroRepository libroRepository;
            ITituloLibroRepository tituloLibroRepository;
            IMiembroRepository miembroRepository;

            // Instanciar los UnitOfWork y los repositorios
            uow = new Repository.EF.UnitOfWork();
            libroRepository = new Repository.EF.Repositorios.LibroRepository(uow);
            tituloLibroRepository = new Repository.EF.Repositorios.TituloLibroRepository(uow);
            miembroRepository = new Repository.EF.Repositorios.MiembroRepository(uow);

            return new BibliotecaService(tituloLibroRepository, libroRepository, miembroRepository, uow);
        }
    }
}
