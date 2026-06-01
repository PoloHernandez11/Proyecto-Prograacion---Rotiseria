using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Empleado : Persona
    {
        private string Puesto { get; set; }   
        private DateTime FechaIngreseo { get; set; }
        private string Turno { get; set; }
        private double Salario { get; set; }


        public Empleado(string nombre, string apellido, int dni, string puesto, DateTime fechaIngreso, string turno, double salario)
           : base(nombre, apellido, dni) 
        {
            this.Puesto = puesto;
            this.FechaIngreseo = fechaIngreso;
            this.Turno = turno;
            this.Salario = salario;
        }

        public void MostrarRol() 
        {
            Console.WriteLine($"Puesto: {Puesto} | Turno: {Turno} | Ingreso: {FechaIngreseo} | Salario: {Salario}");
        }
        
    }
}
