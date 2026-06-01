using Proyecto_Roticeria.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.views
{
    public class PedidoView
    {
        private PedidoController pedidoController;
        private ProductoController productoController;
        private ClienteController clienteController;

        public PedidoView(PedidoController pedidoController, ProductoController productoController, ClienteController clienteController)
        {
            this.pedidoController = pedidoController;
            this.productoController = productoController;
            this.clienteController = clienteController;
        }

        public void MostrarMenuPedidos()
        {
            int opcion;

            do
            {
                string[] opciones =
                {
                "1. Crear pedido",
                "2. Agregar producto a pedido",
                "3. Eliminar producto de pedido",
                "4. Listar pedidos",
                "5. Buscar pedido por número",
                "6. Calcular total de pedido",
                "7. Actualizar estado de despacho",
                "8. Eliminar pedido",
                "9. Recaudacion del dia",
                "0. Volver"
                };

                opcion = EstilosConsola.MostrarMenu("MENU PEDIDOS", opciones);

                switch (opcion)
                {
                    case 1:
                        CrearPedido();
                        break;

                    case 2:
                        AgregarProductoAPedido();
                        break;

                    case 3:
                        EliminarProductoDelPedido();
                        break;

                    case 4:
                        ListarPedidos();
                        break;

                    case 5:
                        BuscarPedidoPorNumero();
                        break;

                    case 6:
                        CalcularTotalPedido();
                        break;

                    case 7:
                        ActualizarEstadoDespacho();
                        break;

                    case 8:
                        EliminarPedido();
                        break;

                    case 9:
                        CalcularTotalTodosLosPedidos();
                        break;

                    case 0:
                        Console.WriteLine("Volviendo al menú principal...");
                        break;

                    default:
                        EstilosConsola.MostrarError("Opción inválida.");
                        break;
                }

                Console.WriteLine();

            } while (opcion != 0);
        }

        private void CrearPedido()
        {
            EstilosConsola.MostrarEncabezado("CREAR PEDIDO");

            int dniCliente = LeerEntero("Ingrese DNI del cliente: ");

            Cliente cliente = clienteController.BuscarClientePorDni(dniCliente);

            if (cliente == null)
            {
                EstilosConsola.MostrarError("No existe un cliente con ese DNI.");
                EstilosConsola.MostrarError("Primero debe cargar el cliente desde el menú Clientes.");
                return;
            }

            string nombreCliente = cliente.Nombre + " " + cliente.Apellido;

            Console.WriteLine("Seleccione estado inicial del despacho:");
            Console.WriteLine("1. Pendiente");
            Console.WriteLine("2. Delivery");
            Console.WriteLine("3. Retiro en local");

            int opcionDespacho = LeerEntero("Opción: ");

            string despacho;

            switch (opcionDespacho)
            {
                case 1:
                    despacho = "Pendiente";
                    break;

                case 2:
                    despacho = "Delivery";
                    break;

                case 3:
                    despacho = "Retiro en local";
                    break;

                default:
                    Console.WriteLine("Opción inválida. Se asignará como Pendiente.");
                    despacho = "Pendiente";
                    break;
            }

            bool creado = pedidoController.CrearPedido(nombreCliente, despacho);

            if (creado)
            {
                EstilosConsola.MostrarExito("Pedido creado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo crear el pedido.");
            }
        }

        private void AgregarProductoAPedido()
        {
            EstilosConsola.MostrarEncabezado("AGREGAR PRODUCTO A PEDIDO");

            int numeroPedido = LeerEntero("Ingrese número de pedido: ");

            Pedido pedido = pedidoController.BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                EstilosConsola.MostrarError("No se encontró el pedido.");
                return;
            }

            Console.WriteLine("Productos disponibles:");
            ListarProductosDisponibles();

            Console.Write("Ingrese nombre exacto del producto: ");
            string nombreProducto = Console.ReadLine();

            Producto producto = productoController.BuscarProductoPorNombre(nombreProducto);

            if (producto == null)
            {
                EstilosConsola.MostrarError("No se encontró un producto con ese nombre.");
                return;
            }

            bool agregado = pedidoController.AgregarProductoAPedido(numeroPedido, producto);

            if (agregado)
            {
                EstilosConsola.MostrarExito("Producto agregado al pedido correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo agregar el producto al pedido.");
            }
        }

        private void EliminarProductoDelPedido()
        {
            EstilosConsola.MostrarEncabezado("ELIMINAR PRODUCTO DE PEDIDO");

            int numeroPedido = LeerEntero("Ingrese número de pedido: ");

            Pedido pedido = pedidoController.BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                EstilosConsola.MostrarError("No se encontró el pedido.");
                return;
            }

            pedido.MostrarProductos();

            Console.Write("Ingrese nombre exacto del producto a eliminar: ");
            string nombreProducto = Console.ReadLine();

            Producto producto = productoController.BuscarProductoPorNombre(nombreProducto);

            if (producto == null)
            {
                EstilosConsola.MostrarError("No se encontró un producto con ese nombre.");
                return;
            }

            bool eliminado = pedidoController.EliminarProductoDelPedido(numeroPedido, producto);

            if (eliminado)
            {
                EstilosConsola.MostrarExito("Producto eliminado del pedido correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo eliminar el producto. Verifique que el producto esté en el pedido.");
            }
        }

        private void ListarPedidos()
        {
            EstilosConsola.MostrarEncabezado("LISTA DE PEDIDOS");

            List<Pedido> pedidos = pedidoController.ObtenerPedidos();

            if (pedidos.Count == 0)
            {
                EstilosConsola.MostrarError("No hay pedidos cargados.");
                return;
            }

            for (int i = 0; i < pedidos.Count; i++)
            {
                MostrarDatosPedido(pedidos[i], i + 1);
            }

            EstilosConsola.Pausar();
        }

        private void BuscarPedidoPorNumero()
        {
            EstilosConsola.MostrarEncabezado("BUSCAR PEDIDO POR NÚMERO");

            int numeroPedido = LeerEntero("Ingrese número de pedido: ");

            Pedido pedido = pedidoController.BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                EstilosConsola.MostrarError("No se encontró el pedido.");
                return;
            }

            MostrarDatosPedido(pedido, numeroPedido);
        }

        private void CalcularTotalPedido()
        {
            Console.WriteLine("===== CALCULAR TOTAL DE PEDIDO =====");

            int numeroPedido = LeerEntero("Ingrese número de pedido: ");

            Pedido pedido = pedidoController.BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                Console.WriteLine("No se encontró el pedido.");
                return;
            }

            double total = pedidoController.CalcularTotalPedido(numeroPedido);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total del pedido N° {numeroPedido}: ${total}");
            Console.ResetColor();

            EstilosConsola.Pausar();
        }

        private void ActualizarEstadoDespacho()
        {
            EstilosConsola.MostrarEncabezado("ACTUALIZAR ESTADO DE DESPACHO");

            int numeroPedido = LeerEntero("Ingrese número de pedido: ");

            Pedido pedido = pedidoController.BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                EstilosConsola.MostrarError("No se encontró el pedido.");
                return;
            }

            Console.WriteLine("Seleccione nuevo estado:");
            Console.WriteLine("1. Pendiente");
            Console.WriteLine("2. Delivery");
            Console.WriteLine("3. Retiro en local");
            Console.WriteLine("4. Despachado");

            int opcion = LeerEntero("Opción: ");

            string nuevoEstado;

            switch (opcion)
            {
                case 1:
                    nuevoEstado = "Pendiente";
                    break;

                case 2:
                    nuevoEstado = "Delivery";
                    break;

                case 3:
                    nuevoEstado = "Retiro en local";
                    break;

                case 4:
                    nuevoEstado = "Despachado";
                    break;

                default:
                    EstilosConsola.MostrarError("Opción inválida.");
                    return;
            }

            bool actualizado = pedidoController.ActualizarDespachoPedido(numeroPedido, nuevoEstado);

            if (actualizado)
            {
                EstilosConsola.MostrarExito("Estado de despacho actualizado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo actualizar el estado.");
            }
        }

        private void EliminarPedido()
        {
            EstilosConsola.MostrarEncabezado("ELIMINAR PEDIDO");

            int numeroPedido = LeerEntero("Ingrese número de pedido a eliminar: ");

            bool eliminado = pedidoController.EliminarPedido(numeroPedido);

            if (eliminado)
            {
                EstilosConsola.MostrarExito("Pedido eliminado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se encontró el pedido.");
            }
        }

        private void CalcularTotalTodosLosPedidos()
        {
            EstilosConsola.MostrarEncabezado("RECAUDACION DEL DIA");

            double total = pedidoController.CalcularTotalDeTodosLosPedidos();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total acumulado de todos los pedidos: ${total}");
            Console.ResetColor();

            EstilosConsola.Pausar();
        }

        private void MostrarDatosPedido(Pedido pedido, int numeroPedido)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.ResetColor();

            Console.WriteLine($"Pedido N°: {numeroPedido}");
            Console.WriteLine($"Cliente: {pedido.Cliente}");
            Console.WriteLine($"Despacho: {pedido.Despacho}");
            Console.WriteLine($"Total: ${pedido.CalcularTotal()}");
            Console.WriteLine("Productos:");
            pedido.MostrarProductos();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.ResetColor();
        }

        private void ListarProductosDisponibles()
        {
            List<Producto> productos = productoController.ObtenerProductos();

            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos cargados.");
                return;
            }

            foreach (Producto producto in productos)
            {
                Console.WriteLine(producto.ToString());
            }
        }

        private int LeerEntero(string mensaje)
        {
            int numero;

            Console.Write(mensaje);

            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dato inválido. Ingrese solo números.");
                Console.ResetColor();

                Console.Write(mensaje);
            }

            return numero;
        }
    }
}
