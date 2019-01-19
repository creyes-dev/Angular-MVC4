using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Infraestructura
{
    // IAggregateRoot interface into the root
    // of the Infrastructure project because it’s not intrinsically
    // tied with the Unit of Work operations.
    public interface IAggregateRoot
    {
    }
}
