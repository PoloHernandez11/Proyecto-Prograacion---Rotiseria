using Proyecto_Roticeria.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.views
{
    public class DespachoView
    {
        private DespachoController despachoController;
        private PedidoController pedidoController;

        public DespachoView(DespachoController despachoController, PedidoController pedidoController)
        {
            this.despachoController = despachoController;
            this.pedidoController = pedidoController;
        }

        public void MostrarMenuDespachos()
        {
            int opcion;

            do
            {
                string[] opciones =
                {
                "1. Crear Delivery",
                "2. Crear retiro en local",
                "3. Listar despachos",
                "4. Listar deliveries",
                "5. Listar retiros",
                "6. Asignar delivery a pedido",
                "7. Asignar retiro a pedido",
                "8. Marcar pedido como despachado",
                "9. Eliminar despacho",
                "0. Volver"
                };

                opcion = EstilosConsola.MostrarMenu("MENÚ DESPACHOS", opciones);

                switch (opcion)
                {
                    case 1:
                        CrearDelivery();
                        break;

                    case 2:
                        CrearRetiro();
                        break;

                    case 3:
                        ListarDespachos();
                        break;

                    case 4:
                        ListarDeliveries();
                        break;

                    case 5:
                        ListarRetiros();
                        break;

                    case 6:
                        AsignarDeliveryAPedido();
                        break;

                    case 7:
                        AsignarRetiroAPedido();
                        break;

                    case 8:
                        MarcarPedidoComoDespachado();
                        break;

                    case 9:
                        EliminarDespacho();
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

        private void CrearDelivery()
        {
            EstilosConsola.MostrarEncabezado("CREAR DELIVERY");

            TimeSpan hora = LeerHora("Hora estimada de entrega (hh:mm): ");
            double costo = LeerDouble("Costo del delivery: ");

            Console.Write("Dirección de entrega: ");
            string direccion = Console.ReadLine();

            bool creado = despachoController.CrearDelivery(hora, costo, direccion);

            if (creado)
            {
                EstilosConsola.MostrarExito("Delivery creado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo crear el delivery. Revise los datos ingresados.");
            }
        }

        private void CrearRetiro()
        {
            EstilosConsola.MostrarEncabezado("CREAR RETIRO EN LOCAL");

            TimeSpan hora = LeerHora("Hora estimada de retiro (hh:mm): ");
            double costo = LeerDouble("Costo del retiro: ");

            Console.Write("Tipo de despacho: ");
            string tipoDespacho = Console.ReadLine();

            bool creado = despachoController.CrearRetiro(hora, costo, tipoDespacho);

            if (creado)
            {
                EstilosConsola.MostrarExito("Retiro creado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo crear el retiro. Revise los datos ingresados.");
            }
        }

        private void ListarDespachos()
        {
            EstilosConsola.MostrarEncabezado("LISTA DE DESPACHOS");

            List<Despacho> despachos = despachoController.ObtenerDespacho();

            if (despachos.Count == 0)
            {
                EstilosConsola.MostrarError("No hay despachos cargados.");
                return;
            }

            for (int i = 0; i < despachos.Count; i++)
            {
                MostrarDatosDespacho(despachos[i], i + 1);
            }

            EstilosConsola.Pausar();
        }

        private void ListarDeliveries()
        {
            EstilosConsola.MostrarEncabezado("LISTA DE DELIVERIES");

            List<Delivery> deliveries = despachoController.ObtenerDeliveries();

            if (deliveries.Count == 0)
            {
                EstilosConsola.MostrarError("No hay deliveries cargados.");
                return;
            }

            for (int i = 0; i < deliveries.Count; i++)
            {
                MostrarDatosDespacho(deliveries[i], i + 1);
            }

            EstilosConsola.Pausar();
        }

        private void ListarRetiros()
        {
            EstilosConsola.MostrarEncabezado("LISTA DE RETIROS");

            List<Retiro> retiros = despachoController.ObtenerRetiros();

            if (retiros.Count == 0)
            {
                EstilosConsola.MostrarError("No hay retiros cargados.");
                return;
            }

            for (int i = 0; i < retiros.Count; i++)
            {
                MostrarDatosDespacho(retiros[i], i + 1);
            }

            EstilosConsola.Pausar();
        }

        private void AsignarDeliveryAPedido()
        {
            EstilosConsola.MostrarEncabezado("ASIGNAR DELIVERY A PEDIDO");

            int numeroPedido = LeerEntero("Ingrese número de pedido: ");

            Pedido pedido = pedidoController.BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                EstilosConsola.MostrarError("No se encontró el pedido.");
                return;
            }

            bool asignado = despachoController.AsignarDeliveryAPedido(pedido);

            if (asignado)
            {
                EstilosConsola.MostrarExito("Delivery asignado correctamente al pedido.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo asignar el delivery.");
            }
        }

        private void AsignarRetiroAPedido()
        {
            EstilosConsola.MostrarEncabezado("ASIGNAR RETIRO A PEDIDO");

            int numeroPedido = LeerEntero("Ingrese número de pedido: ");

            Pedido pedido = pedidoController.BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                EstilosConsola.MostrarError("No se encontró el pedido.");
                return;
            }

            bool asignado = despachoController.AsignarRetiroAPedido(pedido);

            if (asignado)
            {
                EstilosConsola.MostrarExito("Retiro asignado correctamente al pedido.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo asignar el retiro.");
            }
        }

        private void MarcarPedidoComoDespachado()
        {
            EstilosConsola.MostrarEncabezado("MARCAR PEDIDO COMO DESPACHADO");

            int numeroPedido = LeerEntero("Ingrese número de pedido: ");

            Pedido pedido = pedidoController.BuscarPedidoPorNumero(numeroPedido);

            if (pedido == null)
            {
                EstilosConsola.MostrarError("No se encontró el pedido.");
                return;
            }

            bool actualizado = despachoController.MarcarPedidoComoDespachado(pedido);

            if (actualizado)
            {
                EstilosConsola.MostrarExito("Pedido marcado como despachado.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo actualizar el pedido.");
            }
        }

        private void EliminarDespacho()
        {
            EstilosConsola.MostrarEncabezado("ELIMINAR DESPACHO");

            int numeroDespacho = LeerEntero("Ingrese número de despacho: ");

            bool eliminado = despachoController.EliminarDespacho(numeroDespacho);

            if (eliminado)
            {
                EstilosConsola.MostrarExito("Despacho eliminado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se encontró el despacho.");
            }
        }

        private void MostrarDatosDespacho(Despacho despacho, int numero)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"N° despacho: {numero}");
            Console.WriteLine($"Hora: {despacho.Hora}");
            Console.WriteLine($"Costo: ${despacho.Costo}");
            Console.WriteLine(despacho.ObtenerDescripcion());
            Console.WriteLine("------------------------------");
        }

        private int LeerEntero(string mensaje)
        {
            int numero;

            Console.Write(mensaje);

            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                EstilosConsola.MostrarError("Dato inválido. Ingrese solo números.", false);
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
                EstilosConsola.MostrarError("Dato inválido. Ingrese un número válido.", false);
                Console.Write(mensaje);
            }

            return numero;
        }

        private TimeSpan LeerHora(string mensaje)
        {
            TimeSpan hora;

            Console.Write(mensaje);

            while (!TimeSpan.TryParse(Console.ReadLine(), out hora))
            {
                EstilosConsola.MostrarError("Hora inválida. Use formato hh:mm. Ejemplo: 21:30", false);
                Console.Write(mensaje);
            }

            return hora;
        }
    }
}
