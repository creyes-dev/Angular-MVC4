using System.IdentityModel.Tokens;
using System.Security.Claims;


namespace JwtAuth.Web.API.JwtAuth
{
    /// <summary>
    ///     JWT security token handler.
    /// </summary>
    public interface IJwtSecurityTokenHandlerAdapter
    {
        /// <summary>
        ///     Valida el token especificado y devuelve una instancia del <see cref="ClaimsPrincipal" />.
        /// </summary>
        /// <param name="securityToken">Token a validar.</param>
        /// <param name="validationParameters">Parámetros procesados en la validación.</param>
        ClaimsPrincipal ValidateToken(IJwtSecurityToken securityToken, TokenValidationParameters validationParameters);
    }
}