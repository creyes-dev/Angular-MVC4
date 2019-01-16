using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;  
using System.Threading.Tasks;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(test));
            t1.Name = "HiloUno";
            t1.Start();            
            Console.WriteLine("Iniciado el hilo {0}", t1.Name);
        }

        static void test()
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
