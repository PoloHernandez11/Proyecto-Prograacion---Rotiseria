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
        public List<string> ListaProductos { get; set; }
        public string Cliente { get; set; }
        public string Despacho { get; set; }

        public Pedido()
        {
            ListaProductos = new List<string>();
        }

        // Agregar un producto a la lista
        public void AgregarProducto(string producto)
        {
            ListaProductos.Add(producto);
        }

        // Eliminar un producto por nombre
        public bool EliminarProducto(string producto)
        {
            return ListaProductos.Remove(producto);
        }

        // Ver si un producto está en el pedido
        public bool ContieneProducto(string producto)
        {
            return ListaProductos.Contains(producto);
        }

        // Cantidad total de productos
        public int CantidadProductos()
        {
            return ListaProductos.Count;
        }

        // Cambiar el estado de despacho
        public void ActualizarDespacho(string nuevoEstado)
        {
            Despacho = nuevoEstado;
        }

        // Verificar si ya fue despachado
        public bool EstaDespachado()
        {
            return Despacho == "Despachado";
        }

        // Limpiar todos los productos del pedido
        public void VaciarPedido()
        {
            ListaProductos.Clear();
        }

        // Resumen del pedido en texto
        public override string ToString()
        {
            return $"Cliente: {Cliente} | Despacho: {Despacho} | Productos: {CantidadProductos()}";
        }
    }
}
