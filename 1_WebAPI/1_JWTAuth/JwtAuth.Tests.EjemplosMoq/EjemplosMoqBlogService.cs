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
    public class EjemplosMoqBlogService
    {
        [Test]
        public void EjemploMoqBlogServiceInicioExcepcionArgumento()
        {
            var mockLog = new Mock<ILog>();

            // para facilitar el debugging cuando se llame al método log, escribimos en el output
            mockLog.Setup(l => l.Log(It.IsAny<string>())).Callback<string>(param => System.Diagnostics.Debug.Write(param));

            var mockHtmlValidator = new Mock<IHtmlValidator>();

            // al validar html queremos comprobar como se comporta el blog si no es valido
            // el mock de HtmlValidator devolvera falso para cualquier html que le llegue por parametro
            mockHtmlValidator.Setup(v => v.IsValid(It.IsAny<string>())).Returns(false);

            BlogService blog = new BlogService(mockHtmlValidator.Object, mockLog.Object);

            bool testOK = false;

            try
            {
                // cualquier parametro, no importa porque htmlValidator devolvera falso para cualquier html enviado
                blog.PublicPost("html no valido");
            }
            catch (ArgumentException ex)
            {
                //el test es correcto
                testOK = true;
            }

            Assert.IsTrue(testOK);
        }

        [Test]
        public void EjemploMoqBlogServicePublicacionOk()
        {
            var mockLog = new Mock<ILog>();

            // para facilitar el debugging cuando se llame al método log, escribimos en el output
            mockLog.Setup(l => l.Log(It.IsAny<string>())).Callback<string>(param => System.Diagnostics.Debug.Write(param));

            var mockHtmlValidator = new Mock<IHtmlValidator>();

            // al validar html queremos comprobar como se comporta el blog si es valido
            // el mock de HtmlValidator devolvera verdadero para cualquier html que le llegue por parametro
            mockHtmlValidator.Setup(v => v.IsValid(It.IsAny<string>())).Returns(true);

            BlogService blog = new BlogService(mockHtmlValidator.Object, mockLog.Object);
 
            bool testOK = true;

            try
            {
                blog.PublicPost("html valido");
            }
            catch (ArgumentException ex)
            {
                //el test es correcto
                testOK = false;
            }

            //se comprueba que se invoca el método IsValid
            mockHtmlValidator.Verify(validator => validator.IsValid(It.IsAny<string>()));

            Assert.IsTrue(testOK);
        }

    }
}
