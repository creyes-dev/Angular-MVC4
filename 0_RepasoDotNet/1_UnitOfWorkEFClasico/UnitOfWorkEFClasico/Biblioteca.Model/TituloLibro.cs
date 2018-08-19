﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Infraestructura;

namespace Biblioteca.Model
{
    public class TituloLibro : IAggregateRoot
    {
        public string ISBN { get; set; }

        public string Title { get; set; }     
    }
}
