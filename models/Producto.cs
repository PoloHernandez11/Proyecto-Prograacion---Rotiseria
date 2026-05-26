using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Producto
    {
        // Atributos privados
        private double _precio;
        private string _nombre;

        // Constructor
        public Producto(string nombre, double precio)
        {
            _nombre = nombre;
            _precio = precio;
        }

        public double Precio
        {
            get { return _precio; }
            set
            {
                if (value >= 0)
                    _precio = value;
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _nombre = value;
            }
        }

        // Aplicar un descuento en porcentaje
        public void AplicarDescuento(double porcentaje)
        {
            if (porcentaje > 0 && porcentaje < 100)
                _precio -= _precio * (porcentaje / 100);
        }

        // Aumentar el precio en porcentaje
        public void AumentarPrecio(double porcentaje)
        {
            if (porcentaje > 0)
                _precio += _precio * (porcentaje / 100);
        }

        // Verificar si el producto tiene nombre válido
        public bool EsValido()
        {
            return !string.IsNullOrEmpty(_nombre) && _precio >= 0;
        }

        // Comparar precio con otro producto
        public bool EsMasBaratoQue(Producto otro)
        {
            return _precio < otro._precio;
        }

        // Resumen del producto
        public override string ToString()
        {
            return $"Producto: {_nombre} | Precio: ${_precio:F2}";
        }

        public void Mostrar()
        {
            Console.WriteLine($"Producto: {Nombre} - Precio: ${Precio}");
        }
    }
}
