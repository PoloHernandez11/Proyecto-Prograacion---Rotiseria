using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Persona
    {
        private string Nombre { get; set; }
        private string Apellido { get; set; }
        private int Dni { get; set; }


        public Persona(string nombre, string apellido, int dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }

        public void presentarse() 
        {
            Console.WriteLine($"Hola, mi nombre es {Nombre} {Apellido} y mi DNI es {Dni}.");
        }   


    }
}
