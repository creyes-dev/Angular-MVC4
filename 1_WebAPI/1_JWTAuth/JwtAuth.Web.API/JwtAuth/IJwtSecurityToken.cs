namespace JwtAuth.Web.API.JwtAuth
{
    /// <summary>
    /// Security Token JWT
    /// </summary>
    public interface IJwtSecurityToken
    {
        string AlgoritmoFirma { get; }
        string Datos { get; }
    }
}
