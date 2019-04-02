using System.Security.Claims;
using System.Security.Principal;

namespace JwtAuth.Web.API.JwtAuth
{
    /// <summary>
    /// Provee la funcionalidad que tranforma el estandard <see cref="ClaimsPrincipal" /> generado por el 
    /// en uno personalizado
    /// </summary>
    public interface IPrincipalTransformer
    {
        /// <summary>
        /// Transforma el estandard <see cref="ClaimsPrincipal" /> en uno personalizado
        /// </summary>
        /// <param name="principal">Objeto <see cref="ClaimsPrincipal" /> a transformar</param>
        /// <returns></returns>
        IPrincipal Transform(ClaimsPrincipal principal);
    }
}
