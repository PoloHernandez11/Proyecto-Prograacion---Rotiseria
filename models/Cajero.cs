using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Cajero : Empleado
    {
        public Cajero(string nombre, string apellido, int dni,
                  string puesto, DateTime fechaIngreso, string turno, double salario)
        : base(nombre, apellido, dni, puesto, fechaIngreso, turno, salario)
        {
        }

        public double CobrarPedido(Pedido pedido)
        {
            return pedido.CalcularTotal();
        }
    }
}
