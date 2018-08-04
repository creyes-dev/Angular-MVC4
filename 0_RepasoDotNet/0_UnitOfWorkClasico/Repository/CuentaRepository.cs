using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura;
using Modelo;

//The AccountRepository implements both the Model.IAccountRepository and the Infrastructre
//.IUnitOfWorkRepository interfaces. The implementation of the IAccountRepository methods
//simply delegates work to the Unit of Work, passing the entity to be persisted along with a reference
//to the Repository, which of course implements the IUnitOfWorkRepository. As seen previously
//when the Unit of Work’s Commit method is called, the Unit of Work refers to the Repository’s implementation
//of the IUnitOfWorkRepository contract to perform the real persistence requirements.

namespace Repository
{
    // La implementación del repositorio de cuentas implementa las interfaces del repositorio de cuenta
    // y la del repositorio que usa un Unit of Work
    public class CuentaRepository : ICuentaRepository, IUnitOfWorkRepository
    {
        private IUnitOfWork _unitOfWork;

        // Notar que en el constructor del repositorio se inyecta un Unit of Work 
        // esto permitirá que varios repository compartan el mismo Unit of Work,
        // lo cual permitirá que una transacción comprenda operaciones de distintos
        // repositorios
        public CuentaRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /*  Los métodos Guardar, Modificar y Eliminar implementan la interfaz ICuentaRepository
            simplemente delegan el trabajo de registrar las operaciones de persistencia en el Unit of Work
            pasándole una referencia de la entidad con los datos requeridos junto a una referencia del
            propio objeto CuentaRepository que por supuesto implementará la interfaz IUnitOfWorkRepository */

        public void Guardar(Cuenta cuenta)
        {
            _unitOfWork.RegistrarNuevo(cuenta, this);
        }

        public void Modificar(Cuenta cuenta)
        {
            _unitOfWork.RegistrarModificado(cuenta, this);
        }

        public void Remover(Cuenta cuenta)
        {
            _unitOfWork.RegistrarRemovido(cuenta, this);
        }

        /*   Los métodos PersistirCreacion, PersistirActualizacion y PersistirEliminacion
             implementan la interfaz de IUnitOfWorkRepository que son aquellos métodos que
             realmente realizan las tareas de persistencia en la base de datos */
        public void PersistirCreacion(IAggregateRoot entity)
        {
            // Código para persistir la creación en la base de datos
        }

        public void PersistirActualizacion(IAggregateRoot entity)
        {
            // Código para persistir la modificación en la base de datos
        }

        public void PersistirEliminacion(IAggregateRoot entity)
        {
            // Código para persistir la eliminación en la base de datos
        }

    }
}
