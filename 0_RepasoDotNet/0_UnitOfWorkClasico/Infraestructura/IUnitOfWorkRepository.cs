using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    // Referencia una entidad de negocio que está siendo parte de 
    // una transacción atómica
    public interface IUnitOfWorkRepository
    {
        void PersistirCreacion(IAggregateRoot entity);
        void PersistirActualizacion(IAggregateRoot entity);
        void PersistirEliminacion(IAggregateRoot entity);
    }
}
