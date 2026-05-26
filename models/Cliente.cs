using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Cliente : Persona
    {
        private string Direccion { get; set; }
        private int Telefono { get; set; }


        public Cliente(string nombre, string apellido, int dni, string direccion, int telefono)
            :base(nombre, apellido, dni)
        { 
            this.Telefono = telefono;
            this.Direccion = direccion;
        }


    }
}
