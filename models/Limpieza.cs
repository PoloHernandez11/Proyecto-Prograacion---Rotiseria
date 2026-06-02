using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Limpieza : Empleado
    {
        public string Sector { get; private set; }

        public Limpieza(string nombre, string apellido, int dni,
                        string puesto, DateTime fechaIngreso, string turno, double salario,
                        string sector)
            : base(nombre, apellido, dni, puesto, fechaIngreso, turno, salario)
        {
            this.Sector = sector;
        }

        public string LimpiarSector()
        {
            return $"El empleado de limpieza {Nombre} {Apellido} está limpiando el sector: {Sector}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Sector: {Sector}";
        }
    }
}
