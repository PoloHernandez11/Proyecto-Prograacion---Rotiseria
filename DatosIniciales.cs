using Proyecto_Roticeria.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
        public static class DatosIniciales
        {
            public static void Cargar(
                ClienteController clienteController,
                ProductoController productoController,
                EmpleadoController empleadoController,
                PedidoController pedidoController,
                DespachoController despachoController)
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
        }
}

