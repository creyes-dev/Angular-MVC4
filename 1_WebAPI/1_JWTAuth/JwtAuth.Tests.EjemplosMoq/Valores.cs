using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuth.Tests.EjemplosMoq
{
    public interface IGeneradorValores
    {
        int SumarUno(int numero);
    }

    public class GeneradorValores : IGeneradorValores
    {
        public int SumarUno(int numero)
        {
            return numero + 1;
        }
    }

    public class Valores
    {
        IGeneradorValores _generadorValores;
        int _numero = 0;

        public Valores(IGeneradorValores generador)
        {
            _generadorValores = generador;
        }

        /// <summary>
        /// Obtiene el proximo numero entero en relación al ultimo obtenido, si es la primera vez que se llama al método devuelve el valor 1
        /// </summary>
        /// <returns>Devuelve el próximo número</returns>
        public int ObtenerProximoNumero()
        {
            _numero = _generadorValores.SumarUno(_numero);
            return _numero;
        }
    }

}
