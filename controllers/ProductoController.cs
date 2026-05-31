using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.controllers
{
    public class ProductoController
    {
        private List<Producto> productos;

        public ProductoController()
        {
            productos = new List<Producto>();
        }

        public bool AgregarProducto(string nombre, double precio)
        {
            if (!ValidarDatosProducto(nombre, precio))
            {
                return false;
            }

            if ( ExisteProducto(nombre))
            {
                return false;
            }

            Producto producto = new Producto(nombre, precio);

            if (!producto.EsValido())
            {
                return false;
            }

            productos.Add(producto);
            return true;
        }

        public List<Producto> ObtenerProductos()
        {
            return productos;
        }

        public Producto BuscarProductoPorNombre(string nombre)
        {
            foreach (Producto producto in productos)
            {
                if (producto.Nombre.ToLower() == nombre.ToLower())
                {
                    return producto;
                }
            }

            return null;
        }

        public List<Producto> BuscarProductosPorNombre(string nombre)
        {
            List<Producto> productosEncontrados = new List<Producto>();

            foreach (Producto producto in productos)
            {
                if (producto.Nombre.ToLower().Contains(nombre.ToLower()))
                {
                    productosEncontrados.Add(producto);
                }
            }

            return productosEncontrados;
        }

        public bool EliminarProducto(string nombre)
        {
            Producto productoEncontrado = BuscarProductoPorNombre(nombre);

            if (productoEncontrado == null)
            {
                return false;
            }

            productos.Remove(productoEncontrado);
            return true;
        }

        public bool AplicarDescuento(string nombre, double porcentaje)
        {
            Producto producto = BuscarProductoPorNombre(nombre);

            if (producto == null)
            {
                return false;
            }

            if (porcentaje <= 0 || porcentaje >= 100)
            {
                return false;
            }

            producto.AplicarDescuento(porcentaje);
            return true;
        }

        public bool AumentarPrecio(string nombre, double porcentaje)
        {
            Producto producto = BuscarProductoPorNombre(nombre);

            if (producto == null)
            {
                return false;
            }

            if (porcentaje <= 0)
            {
                return false;
            }

            producto.AumentarPrecio(porcentaje);
            return true;
        }

        public Producto ObtenerProductoMasBarato()
        {
            if (productos.Count == 0)
            {
                return null;
            }

            Producto masBarato = productos[0];

            foreach (Producto producto in productos)
            {
                if (producto.EsMasBaratoQue(masBarato))
                {
                    masBarato = producto;
                }
            }

            return masBarato;
        }

        public Producto ObtenerProductoMasCaro()
        {
            if (productos.Count == 0)
            {
                return null;
            }

            Producto masCaro = productos[0];

            foreach (Producto producto in productos)
            {
                if (producto.Precio > masCaro.Precio)
                {
                    masCaro = producto;
                }
            }

            return masCaro;
        }

        public List<Producto> OrdenarPorPrecioAscendente()
        {
            List<Producto> productosOrdenados = new List<Producto>(productos);
            //burbujeo
            for (int i = 0; i < productosOrdenados.Count - 1; i++)
            {
                for (int j = 0; j < productosOrdenados.Count - 1 - i; j++)
                {
                    if (productosOrdenados[j].Precio > productosOrdenados[j + 1].Precio)
                    {
                        Producto aux = productosOrdenados[j];
                        productosOrdenados[j] = productosOrdenados[j + 1];
                        productosOrdenados[j + 1] = aux;
                    }

                }
            }

            return productosOrdenados;
        }

        public double CalcularTotalProductos()
        {
            double total = 0;

            foreach (Producto producto in productos)
            {
                total += producto.Precio;
            }

            return total;
        }

        //validaciones
        public bool ExisteProducto(string nombre)
        {
            foreach (Producto producto in productos)
            {
                if (producto.Nombre.ToLower() == nombre.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private bool ValidarDatosProducto(string nombre, double precio)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            if (precio < 0)
            {
                return false;
            }

            return true;
        }
    }
}
