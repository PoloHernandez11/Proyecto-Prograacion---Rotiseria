using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Persona
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public int Dni { get; private set; }


        public Persona(string nombre, string apellido, int dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }
        public override string ToString()
        {
            return $"{Nombre} {Apellido} | DNI: {Dni}";
        }
    }
}
