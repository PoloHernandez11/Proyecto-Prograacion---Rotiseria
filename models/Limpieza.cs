using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Limpieza : Empleado
    {
        private string Sector { get; set; }

        public Limpieza(string nombre, string apellido, int dni,
                        string puesto, DateTime fechaIngreso, string turno, double salario,
                        string sector)
            : base(nombre, apellido, dni, puesto, fechaIngreso, turno, salario)
        {
            this.Sector = sector;
        }

        public void LimpiarSector()
        {
            Console.WriteLine($"Limpiando el sector: {Sector}");
        }
    }
}
