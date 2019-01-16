using System;
using System.Data;
using System.Data.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Repository.EF
{
    /*  Esta clase es la puerta de acceso al manejo de persistencia y recuperación
        de entidades de negocio dentro del módulo Biblioteca utilizando Entity Framework, 
        las clases que almacenan objetos de esta clase y de otras clases DataContext deberán implementar
        la interface IContenedorDataContext, dichas clases permitiran que las entidades de negocio 
        sean accesibles */

    public class BibliotecaDataContext : ObjectContext
    {
        private ObjectSet<Miembro> _miembros;
        private ObjectSet<Libro> _libros;
        private ObjectSet<TituloLibro> _titulosLibros;

        public BibliotecaDataContext()
            : base("name=BibliotecaEntities", "BibliotecaEntities")
        {
            _miembros = CreateObjectSet<Miembro>();
            _libros = CreateObjectSet<Libro>();
            _titulosLibros = CreateObjectSet<TituloLibro>();
            base.ContextOptions.LazyLoadingEnabled = true;
        }

        public ObjectSet<Miembro> Miembros
        {
            get { return _miembros; }
        }

        public ObjectSet<Libro> Libros
        {
            get { return _libros; }
        }

        public ObjectSet<TituloLibro> TitulosLibros
        {
            get { return _titulosLibros; }
        }

    }

}
