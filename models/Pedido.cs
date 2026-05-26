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
        private List<Producto> Productos { get; set; }
        public string Cliente { get; set; }
        public string Despacho { get; set; }

        public Pedido()
        {
            Productos = new List<Producto>();
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

        public void MostrarProductos()
        {
            Console.WriteLine("---- Productos del pedido ----");
            foreach (var producto in Productos)
            {
                producto.Mostrar();
            }
            Console.WriteLine($"Total: ${CalcularTotal()}");
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
