using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Empleado : Persona, IReportable
    {
        public string Puesto { get; private set; }
        public DateTime FechaIngreso { get; private set; }  // corregido el typo
        public string Turno { get; private set; }
        public double Salario { get; private set; }

        public Empleado(string nombre, string apellido, int dni,
                        string puesto, DateTime fechaIngreso, string turno, double salario)  // DateTime en vez de string
            : base(nombre, apellido, dni)
        {
            this.Puesto = puesto;
            this.FechaIngreso = fechaIngreso;  // corregido el typo
            this.Turno = turno;
            this.Salario = salario;
        }

        public void MostrarRol()
        {
            Console.WriteLine($"Puesto: {Puesto} | Turno: {Turno} | Ingreso: {FechaIngreso:dd/MM/yyyy} | Salario: {Salario}");
        }

        public void GenerarReporte() 
        {
            Console.WriteLine($"Empleado: {Nombre}, {Apellido}");   
        }

    }
}
