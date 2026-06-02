        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    public class Retiro: Despacho
    {
        public string TipoDespacho { get; private set; }

        public Retiro(TimeSpan hora, double costo, string tipoDespacho)
            : base(hora, costo)
        {
            this.TipoDespacho = tipoDespacho;
        }

        public override string ObtenerDescripcion()
        {
            return $"Retiro en local | Tipo: {TipoDespacho} | Hora: {Hora} | Costo: ${Costo}";
        }
    }
}
