using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.controllers
{
    public class DespachoController
    {
        private List<Despacho> despachos;

        public DespachoController()
        {
            despachos = new List<Despacho>();
        }

        public bool CrearDelivery(TimeSpan hora, double costo, string direccion)
        {
            if (!ValidarDatosDespacho(hora, costo))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(direccion))
            {
                return false;
            }

            Delivery delivery = new Delivery(hora, costo, direccion);

            despachos.Add(delivery);
            return true;
        }

        public bool CrearRetiro(TimeSpan hora, double costo, string TipoDespacho)
        {
            if (!ValidarDatosDespacho(hora, costo))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(TipoDespacho))
            {
                return false;
            }

            Retiro retiro = new Retiro(hora, costo, TipoDespacho);

            despachos.Add(retiro);
            return true;
        }

        public List<Despacho> ObtenerDespacho()
        {
            return despachos;
        }

        public Despacho BuscarDespachoPorNumero(int numeroDespacho)
        {
            if (numeroDespacho <= 0 || numeroDespacho > despachos.Count)
            {
                return null;
            }

            return despachos[numeroDespacho - 1];
        }

        public bool EliminarDespacho(int numeroDespacho)
        {
            Despacho despacho = BuscarDespachoPorNumero(numeroDespacho);
            
            if (despacho == null)
            {
                return false;
            }

            despachos.Remove(despacho);
            return true;
        }

        public List<Delivery> ObtenerDeliveries()
        {
            List<Delivery> deliveries = new List<Delivery>();

            foreach (Despacho despacho in despachos)
            {
                if (despacho is Delivery)
                {
                    deliveries.Add((Delivery)despacho);
                }
            }

            return deliveries;
        }

        public List<Retiro> ObtenerRetiros()
        {
            List<Retiro> retiros = new List<Retiro>();

            foreach (Despacho despacho in despachos)
            {
                if (despacho is Retiro)
                {
                    retiros.Add((Retiro)despacho);
                }
            }

            return retiros;
        }

        public bool AsignarDeliveryAPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                return false;
            }

            pedido.ActualizarDespacho("Delivery");
            return true;
        }

        public bool AsignarRetiroAPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                return false;
            }

            pedido.ActualizarDespacho("Retiro en local");
            return true;
        }

        public bool MarcarPedidoComoDespachado(Pedido pedido)
        {
            if (pedido == null)
            {
                return false;
            }

            pedido.ActualizarDespacho("Despachado");
            return true;
        }

        public bool MarcarPedidoComoPendiente(Pedido pedido)
        {
            if (pedido == null)
            {
                return false;
            }

            pedido.ActualizarDespacho("Pendiente");
            return true;
        }

        //validaciones
        private bool ValidarDatosDespacho(TimeSpan hora, double costo)
        {
            if (hora < TimeSpan.Zero)
            {
                return false;
            }

            if (costo < 0)
            {
                return false;
            }

            return true;
        }
    }
}
