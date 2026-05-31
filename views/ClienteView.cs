using Proyecto_Roticeria.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.views
{
    public class ClienteView
    {
        private ClienteController clienteController;

        public ClienteView(ClienteController clienteController)
        {
            this.clienteController = clienteController;
        }

        public void MostrarMenuClientes()
        {
            int opcion;

            do
            {
                string[] opciones =
                {
                    "1. Agregar cliente",
                    "2. Listar clientes",
                    "3. Buscar cliente por DNI",
                    "4. Buscar cliente por nombre",
                    "5. Buscar cliente por apellido",
                    "6. Eliminar cliente",
                    "0. Volver"
                };

                opcion = EstilosConsola.MostrarMenu("MENÚ CLIENTES", opciones);

                switch (opcion)
                {
                    case 1:
                        AgregarCliente();
                        break;

                    case 2:
                        ListarClientes();
                        break;

                    case 3:
                        BuscarClientePorDni();
                        break;

                    case 4:
                        BuscarClientePorNombre();
                        break;

                    case 5:
                        BuscarClientePorApellido();
                        break;

                    case 6:
                        EliminarCliente();
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

        private void AgregarCliente()
        {
            EstilosConsola.MostrarEncabezado("AGREGAR CLIENTE");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            int dni = LeerEntero("DNI: ");

            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            int telefono = LeerEntero("Teléfono: ");

            bool agregado = clienteController.AgregarCliente(
                nombre,
                apellido,
                dni,
                direccion,
                telefono
            );

            if (agregado)
            {
                EstilosConsola.MostrarExito("Cliente agregado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo agregar el cliente. Verifique los datos o revise si el DNI ya existe.");
            }
        }

        private void ListarClientes()
        {
            EstilosConsola.MostrarEncabezado("LISTA DE CLIENTES");

            List<Cliente> clientes = clienteController.ObtenerClientes();

            if (clientes.Count == 0)
            {
                EstilosConsola.MostrarError("No hay clientes cargados.");
                return;
            }

            foreach (Cliente cliente in clientes)
            {
                MostrarDatosCliente(cliente);
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
        }

        private void BuscarClientePorDni()
        {
            EstilosConsola.MostrarEncabezado("BUSCAR CLIENTE POR DNI");

            int dni = LeerEntero("Ingrese DNI: ");

            Cliente cliente = clienteController.BuscarClientePorDni(dni);

            if (cliente == null)
            {
                EstilosConsola.MostrarError("No se encontró un cliente con ese DNI.");
            }
            else
            {
                MostrarDatosCliente(cliente);
                Console.WriteLine("\nPresione una tecla para volver...");
                Console.ReadKey();
            }
        }

        private void BuscarClientePorNombre()
        {
            EstilosConsola.MostrarEncabezado("BUSCAR CLIENTE POR NOMBRE");

            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine();

            List<Cliente> clientesEncontrados = clienteController.BuscarClientePorNombre(nombre);

            if (clientesEncontrados.Count == 0)
            {
                EstilosConsola.MostrarError("No se encontraron clientes con ese nombre.");
                return;
            }

            foreach (Cliente cliente in clientesEncontrados)
            {
                MostrarDatosCliente(cliente);
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
        }

        private void BuscarClientePorApellido()
        {
            EstilosConsola.MostrarEncabezado("BUSCAR CLIENTE POR APELLIDO");

            Console.Write("Ingrese apellido: ");
            string apellido = Console.ReadLine();

            List<Cliente> clientesEncontrados = clienteController.BuscarClientePorApellido(apellido);

            if (clientesEncontrados.Count == 0)
            {
                EstilosConsola.MostrarError("No se encontraron clientes con ese apellido.");
                return;
            }

            foreach (Cliente cliente in clientesEncontrados)
            {
                MostrarDatosCliente(cliente);
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
        }

        private void EliminarCliente()
        {
            EstilosConsola.MostrarEncabezado("ELIMINAR CLIENTE");

            int dni = LeerEntero("Ingrese DNI del cliente a eliminar: ");

            bool eliminado = clienteController.EliminarCliente(dni);

            if (eliminado)
            {
                EstilosConsola.MostrarExito("Cliente eliminado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se encontró un cliente con ese DNI.");
            }
        }

        private void MostrarDatosCliente(Cliente cliente)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.ResetColor();

            Console.WriteLine($"Nombre: {cliente.Nombre}");
            Console.WriteLine($"Apellido: {cliente.Apellido}");
            Console.WriteLine($"DNI: {cliente.Dni}");
            Console.WriteLine($"Dirección: {cliente.Direccion}");
            Console.WriteLine($"Teléfono: {cliente.Telefono}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.ResetColor();
        }

        private int LeerEntero(string mensaje)
        {
            int numero;

            Console.Write(mensaje);

            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                EstilosConsola.MostrarError("Dato inválido. Ingrese solo números.");
                Console.Write(mensaje);
            }

            return numero;
        }
    }
}

