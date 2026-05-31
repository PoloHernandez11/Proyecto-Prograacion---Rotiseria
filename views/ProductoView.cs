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
                    "3. Buscar producto por nombre exacto",
                    "4. Buscar productos por coincidencia",
                    "5. Eliminar producto",
                    "6. Aplicar descuento",
                    "7. Aumentar precio",
                    "8. Mostrar producto más barato",
                    "9. Mostrar producto más caro",
                    "10. Ordenar productos por precio",
                    "11. Calcular total de productos",
                    "0. Volver"
                };

                opcion = EstilosConsola.MostrarMenu("MENÚ PRODUCTOS", opciones);

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;

                    case 2:
                        ListarProductos();
                        break;

                    case 3:
                        BuscarProductoPorNombre();
                        break;

                    case 4:
                        BuscarProductosPorCoincidencia();
                        break;

                    case 5:
                        EliminarProducto();
                        break;

                    case 6:
                        AplicarDescuento();
                        break;

                    case 7:
                        AumentarPrecio();
                        break;

                    case 8:
                        MostrarProductoMasBarato();
                        break;

                    case 9:
                        MostrarProductoMasCaro();
                        break;

                    case 10:
                        OrdenarProductosPorPrecio();
                        break;

                    case 11:
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

        private void BuscarProductoPorNombre()
        {
            EstilosConsola.MostrarEncabezado("BUSCAR PRODUCTO POR NOMBRE EXACTO");

            string nombre = LeerTexto("Ingrese nombre exacto del producto: ");

            Producto producto = productoController.BuscarProductoPorNombre(nombre);

            if (producto == null)
            {
                EstilosConsola.MostrarError("No se encontró un producto con ese nombre.");
            }
            else
            {
                MostrarDatosProducto(producto);
                EstilosConsola.Pausar();
            }
        }

        private void BuscarProductosPorCoincidencia()
        {
            EstilosConsola.MostrarEncabezado("BUSCAR PRODUCTOS POR COINCIDENCIA");

            string nombre = LeerTexto("Ingrese parte del nombre del producto: ");

            List<Producto> productosEncontrados = productoController.BuscarProductosPorNombre(nombre);

            if (productosEncontrados.Count == 0)
            {
                EstilosConsola.MostrarError("No se encontraron productos.");
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

        private void AplicarDescuento()
        {
            EstilosConsola.MostrarEncabezado("APLICAR DESCUENTO");

            string nombre = LeerTexto("Ingrese nombre exacto del producto: ");
            double porcentaje = LeerDouble("Porcentaje de descuento: ");

            bool aplicado = productoController.AplicarDescuento(nombre, porcentaje);

            if (aplicado)
            {
                EstilosConsola.MostrarExito("Descuento aplicado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo aplicar el descuento. Verifique el nombre o el porcentaje.");
            }
        }

        private void AumentarPrecio()
        {
            EstilosConsola.MostrarEncabezado("AUMENTAR PRECIO");

            string nombre = LeerTexto("Ingrese nombre exacto del producto: ");
            double porcentaje = LeerDouble("Porcentaje de aumento: ");

            bool aumentado = productoController.AumentarPrecio(nombre, porcentaje);

            if (aumentado)
            {
                EstilosConsola.MostrarExito("Precio aumentado correctamente.");
            }
            else
            {
                EstilosConsola.MostrarError("No se pudo aumentar el precio. Verifique el nombre o el porcentaje.");
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
    }
}
