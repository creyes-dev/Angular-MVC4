using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel;
using System.IdentityModel.Tokens;
// using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using log4net;

namespace JwtAuth.Web.API.JwtAuth
{

    /// <summary>
    ///     En la solicitud HTTP entrante se encuentra presente en el encabezado Authorization el token JWT que es validado 
    ///     utilizando el objeto TOKENHANDLER: TODO
    /// </summary>
    public class JwtAuthenticationMessageHandler : DelegatingHandler
    {
        private readonly ILog _logger = LogManager.GetLogger("JwtAuthForWebAPI");

        /// <summary>
        /// Se utiliza el esquema Bearer token
        /// </summary>
        public const string BearerScheme = "Bearer";

        /// <summary>
        /// Asignar u obtener el token para verificar que la firma del JWT entrante sea válida
        /// </summary>
        public SecurityToken SigningToken { get; set; }
        
        /// <summary>
        /// Audience permitida (usualmente un URL)
        /// </summary>
        public string AllowedAudience { get; set; }

        /// <summary>
        /// Listado de valores de Audience que serán permitidos (usualmente URL)
        /// en la validación de los Audiences de los JWT entrantes
        /// </summary>
        public IEnumerable<string> AllowedAudiences { get; set; }

        /// <summary>
        /// Referencia del emisor del token (usualmente un URL) que será permitido en la validación
        /// de los JWT entrantes
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Objeto responsable de transformar un objeto System.Security.Claims.ClaimsPrincipal 
        /// a un objeto IPrincipal personalizado
        /// </summary>
        public IPrincipalTransformer PrincipalTransformer { get; set; }

        public JwtAuthenticationMessageHandler()
        {
            AllowedAudience = "http://www.dominio.gov.ar/expedientes";
            Issuer = "http://www.dominio.gov.ar/expedientes-api";
        }

        protected virtual Task<HttpResponseMessage> BaseSendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }

        protected virtual string ObtenerTokenDelHeader(HttpRequestMessage request)
        {
            var authHeader = request.Headers.Authorization;
            if (authHeader == null) return null;

            if (authHeader.Scheme != BearerScheme)
            {
                _logger.DebugFormat(
                    "El esquema del Authorization Header es {0}; es requerido que {1} sea manejado como JWT.",
                    authHeader.Scheme,
                    BearerScheme);
            }
            else
            {
                return authHeader.Parameter;
            }

            return null;
        }

        /// <summary>
        /// SendAsync es disparado cuando este objeto recibe un HttpRequestMessage o un objeto HttpResponseMessage.
        /// La funcionalidad que presenta el siguiente bloque de código posee la finalidad de validar un JWT y
        /// obtener el objeto <see cref="IPrincipal" /> correspondiente a los datos presentes en el payload.
        /// </summary>
        /// <param name="request">Mensaje de solicitud HTTP que el objeto actual está encargado de manejar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Mensaje de respuesta HTTP que el objeto actual está encargado de manejar</returns>
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // 1. Obtener el token string del del Authorization header
            var tokenStringFromHeader = ObtenerTokenDelHeader(request);

            // 2. Validar que el token haya sido encotnrado en el Authentication header
            var tokenString = tokenStringFromHeader;
            
            if (string.IsNullOrEmpty(tokenString))
            {
                _logger.Debug("El token no fue encontrado en el Authorization Header");
                return BaseSendAsync(request, cancellationToken);
            }

            // 3. Obtener el objeto JWT desde el string del token 
            IJwtSecurityToken token;
            try
            {
                token = CrearToken(tokenString);
            }
            catch (Exception ex)
            {
                _logger.WarnFormat("Error convirtiendo al string del token a un objeto JWT: {0}", ex);
                return BaseSendAsync(request, cancellationToken);
            }

            // 4. Validar el algoritmo con el que se ha firmado el token

            /*
            if (SigningToken != null && token.AlgoritmoFirma != null)
            {
                if (token.AlgoritmoFirma.StartsWith("RS") && !(SigningToken is X509SecurityToken))
                {
                    _logger.DebugFormat("Incoming token signature is X509, but token handler's signing token is not.");
                    return BaseSendAsync(request, cancellationToken);
                }

                if (token.SignatureAlgorithm.StartsWith("HS") && !(SigningToken is BinarySecretSecurityToken))
                {
                    _logger.DebugFormat("Incoming token signature is SHA, but token handler's signing token is not.");
                    return BaseSendAsync(request, cancellationToken);
                }
            }*/

            // 5. Obtener el objeto Principal como resultado de la validación del token

            // TODO: No se
            var parameters = new TokenValidationParameters
            {
                ValidAudience = AllowedAudience,
                IssuerSigningToken = SigningToken,
                ValidIssuer = Issuer,
                ValidAudiences = AllowedAudiences
            };

            try
            {
                // Validar el token y obtener el objeto Principal
                var tokenHandler = CrearTokenHandler();
                IPrincipal principal = tokenHandler.ValidateToken(token, parameters);

                if (PrincipalTransformer != null)
                {
                    principal = PrincipalTransformer.Transform((ClaimsPrincipal)principal);
                    CheckPrincipal(principal, PrincipalTransformer.GetType());  // TODO: Autenticar??
                }

                // Asociar el objeto principal obtenido al contexto actual
                Thread.CurrentPrincipal = principal;
                _logger.DebugFormat("El objeto principal asociado al hilo es '{0}'", principal.Identity.Name);

                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }
            }
            catch (SecurityTokenExpiredException e)
            {
                _logger.ErrorFormat("El Security Token ha expirado: {0}", e);

                var response = new HttpResponseMessage((HttpStatusCode)440)
                {
                    Content = new StringContent("SecurityTokenExpiredException")
                };

                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
            catch (SecurityTokenSignatureKeyNotFoundException e)
            {
                _logger.ErrorFormat("Error ocurrido en la validación del JWT: {0}", e);

                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Error de confianza del certificado")
                };

                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
            catch (SecurityTokenInvalidAudienceException e)
            {
                _logger.ErrorFormat("Error ocurrido en la validación del JWT: {0}", e);

                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Error de Audience del token")
                };

                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
            catch (SecurityTokenValidationException e)
            {
                _logger.ErrorFormat("Error ocurrido en la validación del JWT: {0}", e);

                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Token inválido")
                };

                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
            catch (SignatureVerificationFailedException e)
            {
                _logger.ErrorFormat("Error ocurrido en la validación del JWT: {0}", e);

                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Invalid token signature")
                };

                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("Error ocurrido en la validación del JWT: {0}", e);
                throw;
            }

            return BaseSendAsync(request, cancellationToken);
        }

        protected virtual void CheckPrincipal(IPrincipal principal, Type transformerType)
        {
            if (principal == null)
            {
                throw new Exception("The principal object returned by the PrincipalTransformer (of type " +
                                    transformerType.FullName + ") cannot be null.");
            }

            if (principal.Identity == null)
            {
                throw new Exception("The principal object returned by the PrincipalTransformer (of type " +
                                    transformerType.FullName + ") must include a non-null Identity.");
            }
        }

        protected virtual IJwtSecurityToken CrearToken(string token)
        {
            return new JwtSecurityTokenAdapter(token);
        }

        protected virtual IJwtSecurityTokenHandlerAdapter CrearTokenHandler()
        {
            return new JwtSecurityTokenHandlerAdapter();
        }

    }
}
