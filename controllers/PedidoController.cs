using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.controllers
{
    public class PedidoController
    {
        private List<Pedido> pedidos;

        public PedidoController()
        {
            pedidos = new List<Pedido>();
        }
            
        public bool CrearPedido(string cliente, string despacho)
        {
            if (!ValidarDatosPedido(cliente, despacho))
            {
                return false;
            }

            Pedido pedido = new Pedido(cliente, despacho);
            
            pedidos.Add(pedido);
            return true;
        }

        public List<Pedido> ObtenerPedidos()
        {
            return pedidos;
        }

        public Pedido BuscarPedidoPorNumero(int numeroPedido)
        {
            if (numeroPedido <= 0 || numeroPedido > pedidos.Count)
            {
                return null;
            }

            return pedidos[numeroPedido - 1];
        }

        public bool AgregarProductoAPedido(int numeroPedido, Producto producto)
        {
            Pedido pedido = BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                return false;
            }

            if (producto == null)
            {
                return false;
            }

            if (!producto.EsValido())
            {
                return false;
            }

            pedido.AgregarProducto(producto);
            return true;
        }

        public bool EliminarProductoDelPedido(int numeroPedido, Producto producto)
        {
            Pedido pedido = BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                return false;
            }

            if (producto == null)
            {
                return false;
            }

            return pedido.EliminarProducto(producto);
        }

        public double CalcularTotalPedido(int numeroPedido)
        {
            Pedido pedido = BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                return 0;
            }

            return pedido.CalcularTotal();
        }

        public bool ActualizarDespachoPedido(int numeroPedido, string nuevoEstado)
        {
            Pedido pedido = BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(nuevoEstado))
            {
                return false;
            }

            pedido.ActualizarDespacho(nuevoEstado);
            return true;
        }

        public bool PedidoEstaDespachado(int numeroPedido)
        {
            Pedido pedido = BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                return false;
            }

            return pedido.EstaDespachado();
        }

        public bool EliminarPedido(int numeroPedido)
        {
            Pedido pedido = BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                return false;
            }

            pedidos.Remove(pedido);
            return true;
        }

        public string ObtenerResumenPedido(int numeroPedido)
        {
            Pedido pedido = BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                return "Pedido no encontrado.";
            }

            return pedido.ToString();
        }

        public double CalcularTotalDeTodosLosPedidos()
        {
            double total = 0;

            foreach (Pedido pedido in pedidos)
            {
                total += pedido.CalcularTotal();
            }

            return total;
        }

        //validaciones

        private bool ValidarDatosPedido(string cliente, string despacho)
        {
            if (string.IsNullOrWhiteSpace(cliente))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(despacho))
            {
                return false;
            }

            return true;
        }
    }
}
