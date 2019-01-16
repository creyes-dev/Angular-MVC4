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
    public class PrestamoService
    {
        private IMiembroRepository _miembroRepository;
        private ILibroRepository _libroRepository;
        private IUnitOfWork _unitOfWork;

        public PrestamoService(ILibroRepository libroRepository,
                                IMiembroRepository miembroRepository,
                                IUnitOfWork unitOfWork)
        {
            _miembroRepository = miembroRepository;
            _libroRepository = libroRepository;
            _unitOfWork = unitOfWork;
        }



    }
}
