using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Repartidor : Empleado
    {
        private string Vehiculo { get; set; }

        public Repartidor(string nombre, string apellido, int dni,
                          string puesto, DateTime fechaIngreso, string turno, double salario,
                          string vehiculo)
            : base(nombre, apellido, dni, puesto, fechaIngreso, turno, salario)
        {
            this.Vehiculo = vehiculo;
        }

        public void RealizarDelivery(Delivery delivery)
        {
            Console.WriteLine($"Repartidor en {Vehiculo} realizando entrega:");
            delivery.EstadoPedido();
        }
    }
}
