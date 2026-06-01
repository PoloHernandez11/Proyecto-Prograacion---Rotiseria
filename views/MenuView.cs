using Proyecto_Roticeria.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.views
{
    public class MenuView
    {
        private EmpleadoController empleadoController;
        private ClienteController clienteController;
        private ProductoController productoController;
        private PedidoController pedidoController;
        private DespachoController despachoController;

        private EmpleadoView empleadoView;
        private ClienteView clienteView;
        private ProductoView productoView;
        private PedidoView pedidoView;
        private DespachoView despachoView;

        public MenuView()
        {
            empleadoController = new EmpleadoController();
            clienteController = new ClienteController();
            productoController = new ProductoController();
            pedidoController = new PedidoController();
            despachoController = new DespachoController();

            CargarDatosIniciales();

            empleadoView = new EmpleadoView(empleadoController);
            clienteView = new ClienteView(clienteController);
            productoView = new ProductoView(productoController);

            pedidoView = new PedidoView(
                pedidoController,
                productoController,
                clienteController
            );

            despachoView = new DespachoView(
                despachoController,
                pedidoController
            );
        }

        private void CargarDatosIniciales()
        {
            // Clientes
            clienteController.AgregarCliente(
                "Juan",
                "Perez",
                12345678,
                "Av. Colon 1234",
                223456789
            );

            clienteController.AgregarCliente(
                "Maria",
                "Gomez",
                23456789,
                "San Martin 850",
                223555123
            );

            clienteController.AgregarCliente(
                "Carlos",
                "Lopez",
                34567890,
                "Independencia 2300",
                223777456
            );

            // Productos
            productoController.AgregarProducto("Empanada de carne", 1200);
            productoController.AgregarProducto("Empanada de pollo", 1200);
            productoController.AgregarProducto("Pizza muzzarella", 6500);
            productoController.AgregarProducto("Milanesa con papas", 7200);
            productoController.AgregarProducto("Tarta de jamon y queso", 3500);

            // Empleados
            empleadoController.AgregarCajero(
                "Laura",
                "Martinez",
                11111111,
                new DateTime(2024, 3, 10),
                "Mañana",
                350000
            );

            empleadoController.AgregarCocinero(
                "Roberto",
                "Fernandez",
                22222222,
                new DateTime(2023, 8, 15),
                "Tarde",
                420000,
                "Pizzero"
            );

            empleadoController.AgregarRepartidor(
                "Diego",
                "Ramirez",
                33333333,
                new DateTime(2024, 1, 20),
                "Noche",
                380000,
                "Moto"
            );

            empleadoController.AgregarLimpieza(
                "Ana",
                "Sosa",
                44444444,
                new DateTime(2025, 2, 5),
                "Mañana",
                300000,
                "Cocina"
            );

            // Pedidos
            pedidoController.CrearPedido("Juan Perez", "Pendiente");
            pedidoController.CrearPedido("María Gomez", "Delivery");

            Producto empanadaCarne = productoController.BuscarProductoPorNombre("Empanada de carne");
            Producto pizza = productoController.BuscarProductoPorNombre("Pizza muzzarella");
            Producto milanesa = productoController.BuscarProductoPorNombre("Milanesa con papas");

            pedidoController.AgregarProductoAPedido(1, empanadaCarne);
            pedidoController.AgregarProductoAPedido(1, pizza);

            pedidoController.AgregarProductoAPedido(2, milanesa);

            // Despachos
            despachoController.CrearDelivery(
                new TimeSpan(21, 30, 0),
                800,
                "San Martin 850"
            );

            despachoController.CrearRetiro(
                new TimeSpan(22, 00, 0),
                0,
                "Retiro por mostrador"
            );
        }
        public void MostrarMenuPrincipal()
        {
            int opcion;

            do
            {
                string[] opciones =
                {
                    "1. Gestión de clientes",
                    "2. Gestión de empleados",
                    "3. Gestión de productos",
                    "4. Gestión de pedidos",
                    "5. Gestión de despachos",
                    "0. Salir"
                };

                opcion = EstilosConsola.MostrarMenu("SISTEMA ROTISERÍA", opciones);

                switch (opcion)
                {
                    case 1:
                        clienteView.MostrarMenuClientes();
                        break;

                    case 2:
                        empleadoView.MostrarMenuEmpleados();
                        break;

                    case 3:
                        productoView.MostrarMenuProductos();
                        break;

                    case 4:
                        pedidoView.MostrarMenuPedidos();
                        break;

                    case 5:
                        despachoView.MostrarMenuDespachos();
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        EstilosConsola.MostrarError("Opción inválida.");
                        break;
                }

            } while (opcion != 0);
        } 
    }
}
