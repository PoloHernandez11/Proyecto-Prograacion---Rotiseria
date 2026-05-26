using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Cocinero : Empleado
    {
        private string Especialidad { get; set; }

        public Cocinero(string nombre, string apellido, int dni,
                        string puesto, DateTime fechaIngreso, string turno, double salario,
                        string especialidad)
            : base(nombre, apellido, dni, puesto, fechaIngreso, turno, salario)
        {
            this.Especialidad = especialidad;
        }

        public void PrepararPedido(Pedido pedido)
        {
            Console.WriteLine($"El cocinero especialista en {Especialidad} está preparando el pedido:");
            pedido.MostrarProductos();
        }
    }
}
