using Proyecto_Roticeria.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.views
{
    public class EmpleadoView
    {
        private EmpleadoController empleadoController;

        public EmpleadoView(EmpleadoController empleadoController)
        {
            this.empleadoController = empleadoController;
        }

        public void MostrarMenuEmpleados()
        {
            int opcion;

            do
            {
                string[] opciones =
                {
                "1. Agregar cajero",
                "2. Agregar cocinero",
                "3. Agregar repartidor",
                "4. Agregar personal de limpieza",
                "5. Listar empleados",
                "6. Buscar empleado por DNI",
                "7. Eliminar empleado",
                "8. Listar empleados por puesto",
                "9. Calcular total de salarios",
                "0. Volver"
                };


                opcion = EstilosConsola.MostrarMenu("MENU EMPLEADOS", opciones);

                switch (opcion)
                {
                    case 1:
                        AgregarCajero();
                        break;

                    case 2:
                        AgregarCocinero();
                        break;

                    case 3:
                        AgregarRepartidor();
                        break;

                    case 4:
                        AgregarLimpieza();
                        break;

                    case 5:
                        ListarEmpleados();
                        break;

                    case 6:
                        BuscarEmpleadoPorDni();
                        break;

                    case 7:
                        EliminarEmpleado();
                        break;

                    case 8:
                        ListarEmpleadosPorPuesto();
                        break;

                    case 9:
                        CalcularTotalSalarios();
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

        private void AgregarCajero()
        {
            EstilosConsola.MostrarEncabezado("AGREGAR CAJERO");

            string nombre = LeerTexto("Nombre: ");
            string apellido = LeerTexto("Apellido: ");
            int dni = LeerEntero("DNI: ");
            DateTime fechaIngreso = LeerFecha("Fecha de ingreso (dd/mm/aaaa): ");
            string turno = LeerTexto("Turno: ");
            double salario = LeerDouble("Salario: ");

            bool agregado = empleadoController.AgregarCajero(
                nombre,
                apellido,
                dni,
                fechaIngreso,
                turno,
                salario
            );

            if (agregado)
            {
                EstilosConsola.MostrarExito("Cajero agregado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo agregar el cajero. Verifique los datos o revise si el DNI ya existe.");
            }
        }

        private void AgregarCocinero()
        {
            EstilosConsola.MostrarEncabezado("AGREGAR COCINERO");

            string nombre = LeerTexto("Nombre: ");
            string apellido = LeerTexto("Apellido: ");
            int dni = LeerEntero("DNI: ");
            DateTime fechaIngreso = LeerFecha("Fecha de ingreso (dd/mm/aaaa): ");
            string turno = LeerTexto("Turno: ");
            double salario = LeerDouble("Salario: ");
            string especialidad = LeerTexto("Especialidad: ");

            bool agregado = empleadoController.AgregarCocinero(
                nombre,
                apellido,
                dni,
                fechaIngreso,
                turno,
                salario,
                especialidad
            );

            if (agregado)
            {
                EstilosConsola.MostrarExito("Cocinero agregado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo agregar el cocinero. Verifique los datos o revise si el DNI ya existe.");
            }
        }

        private void AgregarRepartidor()
        {
            EstilosConsola.MostrarEncabezado("AGREGAR REPARTIDOR");

            string nombre = LeerTexto("Nombre: ");
            string apellido = LeerTexto("Apellido: ");
            int dni = LeerEntero("DNI: ");
            DateTime fechaIngreso = LeerFecha("Fecha de ingreso (dd/mm/aaaa): ");
            string turno = LeerTexto("Turno: ");
            double salario = LeerDouble("Salario: ");
            string vehiculo = LeerTexto("Vehículo: ");

            bool agregado = empleadoController.AgregarRepartidor(
                nombre,
                apellido,
                dni,
                fechaIngreso,
                turno,
                salario,
                vehiculo
            );

            if (agregado)
            {
                EstilosConsola.MostrarExito("Repartidor agregado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo agregar el repartidor. Verifique los datos o revise si el DNI ya existe.");
            }
        }

        private void AgregarLimpieza()
        {
            EstilosConsola.MostrarEncabezado("AGREGAR PERSONAL DE LIMPIEZA");

            string nombre = LeerTexto("Nombre: ");
            string apellido = LeerTexto("Apellido: ");
            int dni = LeerEntero("DNI: ");
            DateTime fechaIngreso = LeerFecha("Fecha de ingreso (dd/mm/aaaa): ");
            string turno = LeerTexto("Turno: ");
            double salario = LeerDouble("Salario: ");
            string sector = LeerTexto("Sector: ");

            bool agregado = empleadoController.AgregarLimpieza(
                nombre,
                apellido,
                dni,
                fechaIngreso,
                turno,
                salario,
                sector
            );

            if (agregado)
            {
                EstilosConsola.MostrarExito("Personal de limpieza agregado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo agregar el personal de limpieza. Verifique los datos o revise si el DNI ya existe.");
            }
        }

        private void ListarEmpleados()
        {
            EstilosConsola.MostrarEncabezado("LISTA DE EMPLEADOS");

            List<Empleado> empleados = empleadoController.ObtenerEmpleados();

            if (empleados.Count == 0)
            {
                EstilosConsola.MostrarError("No hay empleados cargados.");
                return;
            }

            foreach (Empleado empleado in empleados)
            {
                MostrarDatosEmpleado(empleado);
            }

            EstilosConsola.Pausar();
        }

        private void BuscarEmpleadoPorDni()
        {
            EstilosConsola.MostrarEncabezado("BUSCAR EMPLEADO POR DNI");

            int dni = LeerEntero("Ingrese DNI: ");

            Empleado empleado = empleadoController.BuscarEmpleadoPorDni(dni);

            if (empleado == null)
            {
                EstilosConsola.MostrarError("No se encontró un empleado con ese DNI.");
            }
            else
            {
                MostrarDatosEmpleado(empleado);
            }
        }

        private void EliminarEmpleado()
        {
            EstilosConsola.MostrarEncabezado("ELIMINAR EMPLEADO");

            int dni = LeerEntero("Ingrese DNI del empleado a eliminar: ");

            bool eliminado = empleadoController.EliminarEmpleado(dni);

            if (eliminado)
            {
                EstilosConsola.MostrarExito("Empleado eliminado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se encontró un empleado con ese DNI.");
            }
        }

        private void ListarEmpleadosPorPuesto()
        {
            EstilosConsola.MostrarEncabezado("LISTAR EMPLEADOS POR PUESTO");

            Console.WriteLine("Puestos disponibles:");
            Console.WriteLine("- Cajero");
            Console.WriteLine("- Cocinero");
            Console.WriteLine("- Repartidor");
            Console.WriteLine("- Limpieza");

            string puesto = LeerTexto("Ingrese puesto: ");

            List<Empleado> empleados = empleadoController.ObtenerPorPuesto(puesto);

            if (empleados.Count == 0)
            {
                EstilosConsola.MostrarError("No se encontraron empleados con ese puesto.");
                return;
            }

            foreach (Empleado empleado in empleados)
            {
                MostrarDatosEmpleado(empleado);
            }

            EstilosConsola.Pausar();
        }

        private void CalcularTotalSalarios()
        {
            EstilosConsola.MostrarEncabezado("TOTAL DE SALARIOS");

            double total = empleadoController.CalcularTotalSalarios();

            Console.WriteLine($"Total a pagar en salarios: ${total}");

            EstilosConsola.Pausar();
        }

        private void MostrarDatosEmpleado(Empleado empleado)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(empleado.ToString());
            Console.WriteLine("------------------------------");
        }

        private string LeerTexto(string mensaje)
        {
            string texto;

            do
            {
                Console.Write(mensaje);
                texto = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(texto))
                {
                    EstilosConsola.MostrarError("El dato no puede estar vacío.");
                }

            } while (string.IsNullOrWhiteSpace(texto));

            return texto;
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

        private double LeerDouble(string mensaje)
        {
            double numero;

            Console.Write(mensaje);

            while (!double.TryParse(Console.ReadLine(), out numero))
            {
                EstilosConsola.MostrarError("Dato inválido. Ingrese un número válido.");
                Console.Write(mensaje);
            }

            return numero;
        }

        private DateTime LeerFecha(string mensaje)
        {
            DateTime fecha;

            Console.Write(mensaje);

            while (!DateTime.TryParse(Console.ReadLine(), out fecha))
            {
                EstilosConsola.MostrarError("Fecha inválida. Ejemplo correcto: 25/05/2026");
                Console.Write(mensaje);
            }

            return fecha;
        }
    }
}
