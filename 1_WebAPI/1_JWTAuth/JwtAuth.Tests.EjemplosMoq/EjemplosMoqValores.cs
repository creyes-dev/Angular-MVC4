using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace JwtAuth.Tests.EjemplosMoq
{
    [TestFixture]
    public class EjemplosMoqValores
    {
        private Mock<IGeneradorValores> _generadorValoresMock;

        [SetUp]
        public void Setup()
        {
            _generadorValoresMock = new Mock<IGeneradorValores>();
        }

        [Test]
        public void EjemploMoqValoresObtenerUltimoNumeroPosible()
        {
            // Configuramos el mock para que devuelva el resultado de una suma con los valores especificos que queremos probar 
            _generadorValoresMock.Setup(g => g.SumarUno(It.IsAny<int>())).Returns<int>((resultado) => 2147483646 + 1);

            // El objetivo de la prueba actual es verificar que el método ObtenerSiguienteNumero pueda devolver el número que 
            // devuelve el mock a pesar que no sea el numero entero que le sigue al que envio
            int valorObtenido = 0;
            Valores valores = new Valores(_generadorValoresMock.Object);
            valorObtenido = valores.ObtenerProximoNumero();

            Assert.AreEqual(2147483647, valorObtenido);
        }        
    }
}
