using System;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using Moq;
using NUnit.Framework;
using JwtAuth.Web.API.JwtAuth;

namespace JwtAuth.Tests.MessageHandlers
{
    /// <summary>
    /// Clase en la que se efectúa pruebas que involucran la asociación de un objeto <see cref="ClaimsPrincipal" /> y un objeto <see cref="GenericPrincipal" />
    /// a los contextos Thread.CurrentPrincipal y HttpContext.Current.User
    /// </summary>
    [TestFixture]
    public class JwtAuthenticationMessageHandlerTests
    {

        private TextMessageWriter _textMessageWriter;
        private Mock<IJwtSecurityToken> _securityTokenMock;
        private Mock<IJwtSecurityTokenHandlerAdapter> _securityTokenHandlerAdapterMock;
        private Mock<IPrincipalTransformer> _principalTransformerMock;
        private JwtAuthenticationMessageHandlerTest _authenticationMessageHandler;

        /// <summary>
        /// Clase anidada que servirá para efectuar pruebas con el MessageHandler
        /// </summary>
        private class JwtAuthenticationMessageHandlerTest : JwtAuthenticationMessageHandler
        {
            private readonly IJwtSecurityTokenHandlerAdapter _handler; // Handler que valida el token
            private readonly IJwtSecurityToken _token; // Token que se extrae del Authorization header

            public JwtAuthenticationMessageHandlerTest(IJwtSecurityToken token, IJwtSecurityTokenHandlerAdapter handler)
            {
                _token = token;
                _handler = handler;
            }

            // El objeto utilizará el mismo método que maneja el mensaje http que el definido en la superclase
            public new Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                return base.SendAsync(request, cancellationToken);
            }

            // A diferencia del objeto original no se convertirá el contenido del token representado en un
            // string a un objeto IJwtSecurityToken sino que el objeto IJwtSecurityToken que devolverá 
            // es el Mock que se utiliza en la prueba 
            protected override IJwtSecurityToken CrearToken(string token)
            {
                return _token;
            }

            // A diferencia del objeto original se utilizará un Mock del TokenHandler que 
            // será responsable de validar el token
            protected override IJwtSecurityTokenHandlerAdapter CrearTokenHandler()
            {
                return _handler;
            }

            // No se pretende probar la extracción de los datos del token en un string debido a que
            // el ejemplo actual sirve para hacer pruebas con un Mock de IJwtSecurityToken
            protected override string ObtenerTokenDelHeader(HttpRequestMessage request)
            {
                return "Esto es un token";
            }

            protected override Task<HttpResponseMessage> BaseSendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage());
            }

            public void ChequearPrincipal(IPrincipal principal, Type tipoTransformer)
            {
                CheckPrincipal(principal, tipoTransformer);
            }
        }

        [SetUp]
        public void SetUp()
        {
            _securityTokenMock = new Mock<IJwtSecurityToken>();
            _securityTokenHandlerAdapterMock = new Mock<IJwtSecurityTokenHandlerAdapter>();
            _principalTransformerMock = new Mock<IPrincipalTransformer>();

            _textMessageWriter = new TextMessageWriter();

            _authenticationMessageHandler = new JwtAuthenticationMessageHandlerTest(_securityTokenMock.Object, _securityTokenHandlerAdapterMock.Object);

            Thread.CurrentPrincipal = null;
            HttpContext.Current = new HttpContext(new HttpRequest("nombrearchivo", "http://www.w3c.com", null),
                new HttpResponse(_textMessageWriter));
        }

        [TearDown]
        public void TearDown()
        {
            _textMessageWriter.Dispose();
        }

        /// <summary>
        /// Probar que en la ejecución del JwtAuthenticationMessageHandler
        /// un objeto <see cref="ClaimsPrincipal" /> sea transformado a un objeto <see cref="IPrincipal" /> personalizado 
        /// y se asocie correctamente a Thread.CurrentPrincipal y HttpContext.Current.User
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task SendAsyncAsignacionPrincipal()
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer");

            var principal = new ClaimsPrincipal(new ClaimsIdentity());

            // Definir el comportamiento del método ValidateToken del Mock 
            // enviando por parametros el mock del token e ignorando los parámetros de validación
            _securityTokenHandlerAdapterMock.Setup(
                x => x.ValidateToken(_securityTokenMock.Object, It.IsAny<System.IdentityModel.Tokens.TokenValidationParameters>()))
                .Returns(principal);

            // Se ejecuta el MessageHandler sin asociar el objeto IPrincipalTransformer
            // entonces no se transformará el objeto ClaimsPrincipal al objeto IPrincipal, 
            // y en esta prueba se comprobara que el objeto que se termina asociando a a 
            // Thread.CurrentPrincipal y a HttpContext.Current.User no es un objeto IPrincipal personalizado
            // sino el objeto ClaimsPrincipal instanciado para efectuar esta prueba
            await _authenticationMessageHandler.SendAsync(requestMessage, CancellationToken.None);

            // Verificar que se haya asociado correctamente en los contextos actuales el objeto principal que instanciamos 
            Assert.AreSame(principal, Thread.CurrentPrincipal, "CurrentPrincipal Incorrecto");
            Assert.AreSame(principal, HttpContext.Current.User, "Usuario incorrecto en HttpContext");
        }

        /// <summary>
        /// Probar que en la ejecución del JwtAuthenticationMessageHandler
        /// un objeto <see cref="GenericPrincipal" /> se asocie correctamente a Thread.CurrentPrincipal y HttpContext.Current.User
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task SendAsyncPrincipalTransformado()
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer");

            var principal = new ClaimsPrincipal(new ClaimsIdentity());
            var principalTransformado = new GenericPrincipal(new ClaimsIdentity(), new[] { "user" });

            // Definir el comportamiento del método ValidateToken del Mock 
            // enviando por parametros el mock del token e ignorando los parámetros de validación
            _securityTokenHandlerAdapterMock.Setup(
                x => x.ValidateToken(_securityTokenMock.Object, It.IsAny<TokenValidationParameters>()))
                .Returns(principal);

            // Mock para que siempre se transforme cualquier objeto IPrincipal en el objeto principal personalizado que instanciamos
            _principalTransformerMock.Setup(x => x.Transform(principal)).Returns(principalTransformado);

            // Se asocia el Mock del IPrincipalTransformer para se obtenga siempre el objeto GenericPrincipal instanciado 
            _authenticationMessageHandler.PrincipalTransformer = _principalTransformerMock.Object;

            // Se ejecuta el MessageHandler obteniendo como objeto IPrincipal el GenericPrincipal instanciado
            await _authenticationMessageHandler.SendAsync(requestMessage, CancellationToken.None);

            Assert.AreSame(principalTransformado, Thread.CurrentPrincipal, "CurrentPrincipal Incorrecto");
            Assert.AreSame(principalTransformado, HttpContext.Current.User, "Usuario incorrecto en HttpContext");
        }

        /// <summary>
        /// Probar que el método utilizado por el MessageHandler para verificar si posee un 
        /// objeto IPrincipal asociado inicie una excepción si no se pudo transformar un token
        /// a un objeto IPrincipal
        /// </summary>
        [Test]
        public void CheckPrincipalOPrincipalNull()
        {
            Assert.Throws<Exception>(() => _authenticationMessageHandler.ChequearPrincipal(null, this.GetType()));
        }

        public class PrincipalTest : IPrincipal
        {
            private readonly StringCollection _roles = new StringCollection();
            public IIdentity Identity { get; private set; }

            public PrincipalTest(IIdentity identity, string[] roles)
            {
                Identity = identity;
                _roles.AddRange(roles);
            }

            public bool IsInRole(string role)
            {
                return _roles.Contains(role);
            }
        }

        /// <summary>
        /// Probar que el método utilizado por el MessageHandler para verificar si posee un 
        /// objeto IPrincipal asociado inicie una exepción si falta el objeto Identity asociado al IPrincipal
        /// </summary>
        [Test]
        public void CheckPrincipalPrincipalIdentityNull()
        {
            var principal = new PrincipalTest(null, new[] { "user" });
            Assert.Throws<Exception>(() => _authenticationMessageHandler.ChequearPrincipal(principal, GetType()));
        }

    }
}
