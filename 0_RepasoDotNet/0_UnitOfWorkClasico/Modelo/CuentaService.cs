using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura;

namespace Modelo
{
    public class CuentaService
    {
        private ICuentaRepository _cuentaRepository;
        private IUnitOfWork _unitOfWork;

        // Servicio que coordina la transferencia de fondos entre dos cuentas
        public CuentaService(ICuentaRepository cuentaRepository,
                             IUnitOfWork unitOfWork)
        {
            _cuentaRepository = cuentaRepository;
            _unitOfWork = unitOfWork;
        }

        public void TransferirFondos(Cuenta origen, Cuenta destino, decimal importe)
        {
            if (origen.balance >= importe)
            {
                origen.balance -= importe;
                destino.balance += importe;

                // Persistir los cambios en los importes
                _cuentaRepository.Guardar(origen);
                _cuentaRepository.Guardar(destino);

                // Finalmente ejecuta el método Commit de la instancia del Unit of Work 
                // para asegurarse que la transacción sea completada atómicamente
                _unitOfWork.Commit();
            }
        }

    }
}
