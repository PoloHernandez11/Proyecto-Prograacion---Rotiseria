using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Despacho
    {
        private TimeSpan Hora { get; set; }
        private double Costo { get; set; }

        public Despacho(TimeSpan hora, double costo)
        {
            this.Hora = hora;
            this.Costo = costo;
        }

        public void ElegirOpcion(Pedido pedido)
        {
            Console.WriteLine("---- Opciones de despacho ----");
            Console.WriteLine("1. Delivery");
            Console.WriteLine("2. Retiro en local");
            Console.WriteLine($"Hora estimada: {Hora} | Costo: ${Costo}");
            pedido.MostrarProductos();
        }
    }
}
