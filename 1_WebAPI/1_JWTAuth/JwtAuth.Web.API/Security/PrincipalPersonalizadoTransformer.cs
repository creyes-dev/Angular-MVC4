using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using JwtAuth.Web.API.JwtAuth;

namespace JwtAuth.Web.API.Security
{
    public class PrincipalPersonalizadoTransformer : IPrincipalTransformer
    {
        public IPrincipal Transform(ClaimsPrincipal principal)
        {
            var roles = principal
                .FindAll(ClaimTypes.Role)
                .Select(x => x.Value)
                .ToArray();

            return new PrincipalPersonalizado(principal.Identity, roles);
        }

    }
}