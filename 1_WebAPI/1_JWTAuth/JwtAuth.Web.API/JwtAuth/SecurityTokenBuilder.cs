using System;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel.Security.Tokens;

namespace JwtAuth.Web.API.JwtAuth
{
    /// <summary>
    /// Clase que construye security tokens utilizando la clave compartida
    /// </summary>
    public class SecurityTokenBuilder
    {
        /// <summary>
        ///     Crear un nuevo <see cref="SecurityToken" /> utilizando un token creado de un array de bytes 
        /// </summary>
        public SecurityToken CreateFromKey(byte[] key)
        {
            return new BinarySecretSecurityToken(key);
        }

        /// <summary>
        ///     Crea un nuevo <see cref="SecurityToken" /> utilizando un token con clave compartida 
        ///     obtenido en un string encodeado en base64
        /// </summary>
        public SecurityToken CreateFromKey(string base64Key)
        {
            return CreateFromKey(Convert.FromBase64String(base64Key));
        }
    }
}