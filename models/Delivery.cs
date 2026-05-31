using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Delivery:Despacho
    {
        public string Direccion { get; private set; }

        public Delivery(TimeSpan hora, double costo, string direccion)
            : base(hora, costo)
        {
            this.Direccion = direccion;
        }

        public void EstadoPedido()
        {
            Console.WriteLine($"Entregando a: {Direccion}");
        }
    }
}
