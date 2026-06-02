using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public abstract class Despacho
    {
        public TimeSpan Hora { get; private set; }
        public double Costo { get; private set; }

        public Despacho(TimeSpan hora, double costo)
        {
            this.Hora = hora;
            this.Costo = costo;
        }

        public abstract string ObtenerDescripcion();
    }
}
