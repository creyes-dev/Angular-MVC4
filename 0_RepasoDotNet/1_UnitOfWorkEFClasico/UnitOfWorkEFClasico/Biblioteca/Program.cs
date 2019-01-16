using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            BibliotecaService bibliotecaService = BibliotecaServiceFactory.Crear();
            
            // Crear un nuevo libro
            bibliotecaService.AgregarTituloLibro("978-0321832054", "Ruby on Rails Tutorial: Learn Web Development with Rails (2nd Edition)");
            
            // Cargar un nuevo ejemplar
            bibliotecaService.AgregarLibro("978-0321832054");
            // Cargar un nuevo ejemplar
            bibliotecaService.AgregarLibro("978-0321832054");
        }
    }
}
