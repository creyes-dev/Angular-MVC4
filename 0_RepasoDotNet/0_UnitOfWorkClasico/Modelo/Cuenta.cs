using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura;
namespace Modelo
{
    public class Cuenta : IAggregateRoot 
    {
        public decimal balance { get; set; }
    }
}
