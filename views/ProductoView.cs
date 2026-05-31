using Proyecto_Roticeria.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.views
{
    public class ProductoView
    {
        private ProductoController productoController;

        public ProductoView(ProductoController productoController)
        {
            this.productoController = productoController;
        }

        public void MostrarMenuProductos()
        {
            int opcion;

            do
            {
                string[] opciones =
                {
                "1. Agregar producto",
                "2. Listar productos",
                "3. Buscar producto",
                "4. Eliminar producto",
                "5. Cambiar precio",
                "6. Mostrar producto más barato",
                "7. Mostrar producto más caro",
                "8. Ordenar productos por precio",
                "9. Calcular total de productos",
                "0. Volver"
                };

                opcion = EstilosConsola.MostrarMenu("MENÚ PRODUCTOS", opciones);

                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;

                    case 2:
                        ListarProductos();
                        break;

                    case 3:
                        BuscarProducto();
                        break;

                    case 4:
                        EliminarProducto();
                        break;

                    case 5:
                        CambiarPrecio();
                        break;

                    case 6:
                        MostrarProductoMasBarato();
                        break;

                    case 7:
                        MostrarProductoMasCaro();
                        break;

                    case 8:
                        OrdenarProductosPorPrecio();
                        break;

                    case 9:
                        CalcularTotalProductos();
                        break;

                    case 0:
                        Console.WriteLine("Volviendo al menú principal...");
                        break;

                    default:
                        EstilosConsola.MostrarError("Opción inválida.");
                        break;
                }

            } while (opcion != 0);
        }

        private void AgregarProducto()
        {
            EstilosConsola.MostrarEncabezado("AGREGAR PRODUCTO");

            string nombre = LeerTexto("Nombre del producto: ");
            double precio = LeerDouble("Precio: ");

            bool agregado = productoController.AgregarProducto(nombre, precio);

            if (agregado)
            {
                EstilosConsola.MostrarExito("Producto agregado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo agregar el producto. Verifique los datos o revise si el producto ya existe.");
            }
        }

        private void ListarProductos()
        {
            EstilosConsola.MostrarEncabezado("LISTA DE PRODUCTOS");

            List<Producto> productos = productoController.ObtenerProductos();

            if (productos.Count == 0)
            {
                EstilosConsola.MostrarError("No hay productos cargados.");
                return;
            }

            foreach (Producto producto in productos)
            {
                MostrarDatosProducto(producto);
            }

            EstilosConsola.Pausar();
        }

        private void BuscarProducto()
            {
            EstilosConsola.MostrarEncabezado("BUSCAR PRODUCTO");

            string nombre = LeerTexto("Ingrese nombre o parte del nombre del producto: ");

            List<Producto> productosEncontrados = productoController.BuscarProductosPorNombre(nombre);

            if (productosEncontrados.Count == 0)
            {
                EstilosConsola.MostrarError("No se encontraron productos con ese nombre.");
                return;
            }

            foreach (Producto producto in productosEncontrados)
            {
                MostrarDatosProducto(producto);
            }

            EstilosConsola.Pausar();
        }

        private void EliminarProducto()
        {
            EstilosConsola.MostrarEncabezado("ELIMINAR PRODUCTO");

            string nombre = LeerTexto("Ingrese nombre exacto del producto a eliminar: ");

            bool eliminado = productoController.EliminarProducto(nombre);

            if (eliminado)
            {
                EstilosConsola.MostrarExito("Producto eliminado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se encontró un producto con ese nombre.");
            }
        }

        private void CambiarPrecio()
        {
            EstilosConsola.MostrarEncabezado("CAMBIAR PRECIO");

            string nombre = LeerTexto("Ingrese nombre exacto del producto: ");

            Producto producto = productoController.BuscarProductoPorNombre(nombre);

            if (producto == null)
            {
                EstilosConsola.MostrarError("No se encontró un producto con ese nombre.");
                return;
            }

            Console.WriteLine("Producto encontrado:");
            MostrarDatosProducto(producto);

            Console.WriteLine("Seleccione el tipo de cambio:");
            Console.WriteLine("1. Aplicar descuento");
            Console.WriteLine("2. Aumentar precio");
            Console.WriteLine("0. Cancelar");

            int opcion = LeerEntero("Opción: ");

            if (opcion == 0)
            {
                Console.WriteLine("Operación cancelada.");
                EstilosConsola.Pausar();
                return;
            }

            double porcentaje = LeerDouble("Ingrese porcentaje: ");

            bool resultado = false;

            switch (opcion)
            {
                case 1:
                    resultado = productoController.AplicarDescuento(nombre, porcentaje);

                    if (resultado)
                    {
                        EstilosConsola.MostrarExito("Descuento aplicado correctamente.");
                    }
                    else
                    {
                        EstilosConsola.MostrarError("No se pudo aplicar el descuento. Verifique el porcentaje.");
                    }
                    break;

                case 2:
                    resultado = productoController.AumentarPrecio(nombre, porcentaje);

                    if (resultado)
                    {
                        EstilosConsola.MostrarExito("Precio aumentado correctamente.");
                    }
                    else
                    {
                        EstilosConsola.MostrarError("No se pudo aumentar el precio. Verifique el porcentaje.");
                    }
                    break;

                default:
                    EstilosConsola.MostrarError("Opción inválida.");
                    break;
            }
        }

        private void MostrarProductoMasBarato()
        {
            EstilosConsola.MostrarEncabezado("PRODUCTO MÁS BARATO");

            Producto producto = productoController.ObtenerProductoMasBarato();

            if (producto == null)
            {
                EstilosConsola.MostrarError("No hay productos cargados.");
            }
            else
            {
                MostrarDatosProducto(producto);
                EstilosConsola.Pausar();
            }
        }

        private void MostrarProductoMasCaro()
        {
            EstilosConsola.MostrarEncabezado("PRODUCTO MÁS CARO");

            Producto producto = productoController.ObtenerProductoMasCaro();

            if (producto == null)
            {
                EstilosConsola.MostrarError("No hay productos cargados.");
            }
            else
            {
                MostrarDatosProducto(producto);
                EstilosConsola.Pausar();
            }
        }

        private void OrdenarProductosPorPrecio()
        {
            EstilosConsola.MostrarEncabezado("PRODUCTOS ORDENADOS POR PRECIO");

            List<Producto> productosOrdenados = productoController.OrdenarPorPrecioAscendente();

            if (productosOrdenados.Count == 0)
            {
                EstilosConsola.MostrarError("No hay productos cargados.");
                return;
            }

            foreach (Producto producto in productosOrdenados)
            {
                MostrarDatosProducto(producto);
            }

            EstilosConsola.Pausar();
        }

        private void CalcularTotalProductos()
        {
            EstilosConsola.MostrarEncabezado("TOTAL DE PRODUCTOS");

            double total = productoController.CalcularTotalProductos();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"La suma de precios de todos los productos es: ${total}");
            Console.ResetColor();

            EstilosConsola.Pausar();
        }

        private void MostrarDatosProducto(Producto producto)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.ResetColor();

            Console.WriteLine($"Nombre: {producto.Nombre}");
            Console.WriteLine($"Precio: ${producto.Precio}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El dato no puede estar vacío.");
                    Console.ResetColor();
                }

            } while (string.IsNullOrWhiteSpace(texto));

            return texto;
        }

        private double LeerDouble(string mensaje)
        {
            double numero;

            Console.Write(mensaje);

            while (!double.TryParse(Console.ReadLine(), out numero))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dato inválido. Ingrese un número válido.");
                Console.ResetColor();

                Console.Write(mensaje);
            }

            return numero;
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
    }
}
