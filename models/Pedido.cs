using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Pedido
    {
        public List<Producto> Productos { get; private set; }
        public string Cliente { get; private set; }
        public string Despacho { get; private set; }

        public Pedido(string cliente, string despacho)
        {
            Productos = new List<Producto>();
            Cliente = cliente;
            Despacho = despacho;
        }

        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
        }

        public bool EliminarProducto(Producto producto)
        {
            return Productos.Remove(producto);
        }

        public double CalcularTotal()
        {
            double total = 0;
            foreach (var producto in Productos)
            {
                total += producto.Precio;
            }
            return total;
        }

        public bool EstaDespachado()
        {
            return Despacho == "Despachado";
        }

        public void ActualizarDespacho(string nuevoEstado)
        {
            Despacho = nuevoEstado;
        }

        public override string ToString()
        {
            return $"Cliente: {Cliente} | Despacho: {Despacho} | Total: ${CalcularTotal()}";
        }
    }
}
