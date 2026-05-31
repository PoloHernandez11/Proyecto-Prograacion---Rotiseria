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
