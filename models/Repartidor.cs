using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Repartidor : Empleado
    {
        public string Vehiculo { get; private set; }

        public Repartidor(string nombre, string apellido, int dni,
                          string puesto, DateTime fechaIngreso, string turno, double salario,
                          string vehiculo)
            : base(nombre, apellido, dni, puesto, fechaIngreso, turno, salario)
        {
            this.Vehiculo = vehiculo;
        }

        public string EntregarPedido(Pedido pedido)
        {
            return $"El repartidor {Nombre} {Apellido} está entregando el pedido en vehículo: {Vehiculo}. Pedido: {pedido}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Vehículo: {Vehiculo}";
        }
    }
}
