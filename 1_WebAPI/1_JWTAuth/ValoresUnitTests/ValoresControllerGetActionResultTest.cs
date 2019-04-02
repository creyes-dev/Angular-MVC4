using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using JwtAuth.Web.API.Controllers;
using NUnit.Framework;

namespace JwtAuth.Tests.Controllers
{
    [TestFixture]
    public class ValoresControllerGetActionResultTest
    {
        ValoresController valoresController;
        string resultado;

        [SetUp]
        public void Setup()
        {
            valoresController = new ValoresController();
            resultado = valoresController.Get();
        }

        [Test]
        public void ObtenerValoresRetornados()
        {
            Assert.IsTrue(resultado == "hola mundo");    
        }

    }
}
