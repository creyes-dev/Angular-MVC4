using System.Collections.Specialized;
using System.Security.Principal;

namespace JwtAuth.Web.API.Security
{
    public class PrincipalPersonalizado : IPrincipal
    {
        private readonly StringCollection _roles = new StringCollection();

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return _roles.Contains(role);
        }

        public PrincipalPersonalizado(IIdentity identity, string[] roles)
        {
            Identity = identity;
            _roles.AddRange(roles);
        }
        
    }
}