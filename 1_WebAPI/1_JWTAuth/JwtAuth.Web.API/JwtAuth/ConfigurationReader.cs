using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JwtAuth.Web.API.JwtAuth
{
    /// <summary>
    /// Clase utilizada para leer los valores de configuración en la sección JwtAuth en el archivo web.config
    /// </summary>
    public class ConfigurationReader
    {
        /// <summary>
        ///     Obtener un valor booleano que representa el valor de la propiedad 
        ///     AuthenticationMessageHandler que se encuentra en la sección JwtAuth en el archivo de configuración
        /// </summary>
        public bool EnableAuthenticationMessageHandler
        {
            get { return JwtAuthConfigurationSection.Current.EnableAuthenticationMessageHandler; }
        }

        /// <summary>
        ///     Obtener un valor booleano que representa el valor de la propiedad 
        ///     AllowedAudience que se encuentra en la sección JwtAuth en el archivo de configuración
        /// </summary>
        public string AllowedAudience
        {
            get { return JwtAuthConfigurationSection.Current.AllowedAudience; }
        }

        /// <summary>
        ///     Obtener un array que representa el valor de la propiedad 
        ///     AllowedAudiences que se encuentra en la sección JwtAuth en el archivo de configuración
        /// </summary>
        public string[] AllowedAudiences
        {
            get
            {
                return string.IsNullOrWhiteSpace(JwtAuthConfigurationSection.Current.AllowedAudiences)
                    ? new string[0]
                    : JwtAuthConfigurationSection.Current.AllowedAudiences.Split(new[] { ';', ',' });
            }
        }

        /// <summary>
        ///     Obtener un string que representa el valor de la propiedad 
        ///     Issuer que se encuentra en la sección JwtAuth en el archivo de configuración
        /// </summary>
        public string Issuer
        {
            get { return JwtAuthConfigurationSection.Current.Issuer; }
        }

        /// <summary>
        ///     Obtener un string que representa el valor de la propiedad 
        ///     SymmetricKey que se encuentra en la sección JwtAuth en el archivo de configuración
        /// </summary>
        public string SymmetricKey
        {
            get { return JwtAuthConfigurationSection.Current.SymmetricKey; }
        }

    }
}