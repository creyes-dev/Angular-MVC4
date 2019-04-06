using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuth.Tests.EjemplosMoq
{
    public interface ILog
    {
        void Log(string message);
    }

    public interface IHtmlValidator
    {
        bool IsValid(string html);
    }

    /// <summary>
    /// Clase responsable de validar que un html de un post del blog que se va a publicar sea correcto
    /// la clase graba en un log si la publicación se ha realizado con exito o hubo un error
    /// </summary>
    public class BlogService
    {
        IHtmlValidator _htmlValidator;
        ILog _log;

        public BlogService(IHtmlValidator htmlValidator, ILog log)
        {
            _htmlValidator = htmlValidator;
        }

        private void Log(string message)
        {
            if (_log != null)
                _log.Log(message);
        }

        /// <summary>
        /// Publicar un post que contiene el codigo html ingresado
        /// </summary>
        /// <param name="html">Codigo html del post</param>
        /// <returns>Devuelve un valor booleano que indica si el post ha podido ser publicado</returns>
        public bool PublicPost(string html)
        {
            if (_htmlValidator.IsValid(html))
            {
                Log("Post has published");

                return true;
            }
            else
            {
                Log("publish error, html not valid");

                throw new ArgumentException("html not valid");
            }
        }

    }
}
