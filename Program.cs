using Proyecto_Roticeria.controllers;
using Proyecto_Roticeria.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClienteController clienteController = new ClienteController();
            ProductoController productoController = new ProductoController();
            EmpleadoController empleadoController = new EmpleadoController();
            PedidoController pedidoController = new PedidoController();
            DespachoController despachoController = new DespachoController();

            DatosIniciales.Cargar(
                clienteController,
                productoController,
                empleadoController,
                pedidoController,
                despachoController
            );

            MenuView menuView = new MenuView(
                clienteController,
                productoController,
                empleadoController,
                pedidoController,
                despachoController
            );

            menuView.MostrarMenuPrincipal();
        }
    }
}
