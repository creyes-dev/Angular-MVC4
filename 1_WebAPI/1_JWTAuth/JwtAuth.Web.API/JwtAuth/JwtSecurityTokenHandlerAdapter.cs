using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace JwtAuth.Web.API.JwtAuth
{
    /// <summary>
    ///     JWT security token handler.
    /// </summary>
    public class JwtSecurityTokenHandlerAdapter : IJwtSecurityTokenHandlerAdapter
    {
        private readonly JwtSecurityTokenHandler _securityTokenHandler;

        public JwtSecurityTokenHandlerAdapter()
        {
            _securityTokenHandler = new JwtSecurityTokenHandler();
        }

        /// <summary>
        ///     Valida el token especificado y devuelve una instancia del <see cref="ClaimsPrincipal" />.
        /// </summary>
        /// <param name="securityToken">Token a validar.</param>
        /// <param name="validationParameters">Parámetros procesados en la validación.</param>
        public ClaimsPrincipal ValidateToken(IJwtSecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            SecurityToken tokenValidado = null;
            return _securityTokenHandler.ValidateToken(securityToken.Datos, validationParameters, out tokenValidado);
        }

    }
}