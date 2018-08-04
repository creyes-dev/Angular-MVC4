using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    // Interfaz del repositorio que permitirá la persistencia de aggregate roots Cuenta
    public interface ICuentaRepository
    {
        void Guardar(Cuenta cuenta);
        void Modificar(Cuenta cuenta);
        void Remover(Cuenta cuenta);
    }
}
