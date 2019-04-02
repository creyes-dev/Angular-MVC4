using System.Configuration;

namespace JwtAuth.Web.API.JwtAuth
{
    public class JwtAuthConfigurationSection : ConfigurationSection
    {
        public static readonly JwtAuthConfigurationSection Current =
            (JwtAuthConfigurationSection) ConfigurationManager.GetSection
                ("JwtAuth");

        [ConfigurationProperty("EnableAuthenticationMessageHandler", DefaultValue = "false")]
        public bool EnableAuthenticationMessageHandler
        {
            get { return (bool)base["EnableAuthenticationMessageHandler"]; }
            set { base["EnableAuthenticationMessageHandler"] = value; }
        }

        [ConfigurationProperty("AllowedAudience", DefaultValue = "")]
        public string AllowedAudience
        {
            get { return (string)base["AllowedAudience"]; }
            set { base["AllowedAudience"] = value; }
        }

        [ConfigurationProperty("AllowedAudiences", DefaultValue = "")]
        public string AllowedAudiences
        {
            get { return (string)base["AllowedAudiences"]; }
            set { base["AllowedAudiences"] = value; }
        }

        [ConfigurationProperty("Issuer", DefaultValue = "")]
        public string Issuer
        {
            get { return (string)base["Issuer"]; }
            set { base["Issuer"] = value; }
        }

        [ConfigurationProperty("SymmetricKey", DefaultValue = "")]
        public string SymmetricKey
        {
            get { return (string)base["SymmetricKey"]; }
            set { base["SymmetricKey"] = value; }
        }
    }
}