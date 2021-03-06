﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    // La clase prestamo no posee reglas de negocio y validaciones para que el codigo sea mas simple
    public class Prestamo
    {
        public Guid Id { get; set; }

        // public string Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime FechaEstipuladaDevolucion { get; set; }
        public Guid IdLibro { get; set; }
        public Guid IdMiembro { get; set; }
        
        // Prpopiedad Libro es virtual para habilitar LazyLoading
        public virtual Libro Libro { get; set; }
        public virtual Miembro Miembro { get; set; }
        
        public bool NoHaDevuelto()
        {
            return FechaDevolucion == null;
        }

        public void MarcarComoDevuelto()
        {
            FechaDevolucion = DateTime.Now;
        }
    }
}
