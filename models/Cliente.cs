using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Cliente : Persona
    {
        public string Direccion { get; private set; }
        public int Telefono { get; private set; }


        public Cliente(string nombre, string apellido, int dni, string direccion, int telefono)
            :base(nombre, apellido, dni)
        { 
            this.Telefono = telefono;
            this.Direccion = direccion;
        }


    }
}
