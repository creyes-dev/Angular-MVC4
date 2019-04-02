using System.IdentityModel.Tokens;

namespace JwtAuth.Web.API.JwtAuth
{
    /// <summary>
    /// Security Token JWT obtenible del Authorization Header 
    /// de un mensaje http
    /// </summary>
    public class JwtSecurityTokenAdapter : IJwtSecurityToken
    {
        private readonly JwtSecurityToken _jwt;

        public JwtSecurityTokenAdapter(string token)
        {
            _jwt = new JwtSecurityToken(token);
        }

        public string AlgoritmoFirma
        {
            get { return _jwt.SignatureAlgorithm; }
        }

        public string Datos
        {
            get { return _jwt.RawData; }
        }
    }
}