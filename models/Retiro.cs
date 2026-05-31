        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Retiro: Despacho
    {
        public string TipoDespacho { get; private set; }

        public Retiro(TimeSpan hora, double costo, string tipoDespacho)
            : base(hora, costo)
        {
            this.TipoDespacho = tipoDespacho;
        }

        public void EstadoPedido(Pedido pedido)
        {
            Console.WriteLine($"Retiro en local | Tipo: {TipoDespacho}");
            pedido.MostrarProductos();
        }
    }
}
