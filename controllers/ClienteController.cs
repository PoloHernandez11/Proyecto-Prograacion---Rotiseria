using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.controllers
{
    public class ClienteController
    {
        private List<Cliente> clientes;

        public ClienteController()
        {
            clientes = new List<Cliente>();
        }

        public bool AgregarCliente(string nombre, string apellido, int dni, string direccion, int telefono)
        {
            if (!ValidarDatosBasicos(nombre, apellido, dni, direccion, telefono))
            {
                return false;
            }

            if (ExisteCliente(dni))
            {
                return false;
            }

            Cliente cliente = new Cliente(nombre, apellido, dni, direccion, telefono);

            clientes.Add(cliente);
            return true;
        }

        public List<Cliente> ObtenerClientes()
        {
            return clientes;
        }

        public Cliente BuscarClientePorDni(int dni)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Dni == dni)
                {
                    return cliente;
                }
            }

            return null;
        }
        
        public bool EliminarCliente(int dni)
        {
            Cliente clienteEncontrado = BuscarClientePorDni(dni);

            if (clienteEncontrado == null)
            {
                return false;
            }

            clientes.Remove(clienteEncontrado);
            return true;
        }

        public List<Cliente> BuscarCliente(string texto)
        {
            List<Cliente> clientesEncontrados = new List<Cliente>();

            foreach (Cliente cliente in clientes)
            {
                if (cliente.Nombre.ToLower().Contains(texto.ToLower()) ||
                    cliente.Apellido.ToLower().Contains(texto.ToLower()))
                {
                    clientesEncontrados.Add(cliente);
                }
            }

            return clientesEncontrados;
        }


        //validaciones
        public bool ExisteCliente(int dni)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Dni == dni)
                {
                    return true;
                }
            }

            return false;
        }

        private bool ValidarDatosBasicos(string nombre, string apellido, int dni, string direccion, int telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                return false;
            }

            if (dni <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(direccion))
            {
                return false;
            }

            if (telefono <= 0)
            {
                return false;
            }

            return true;
        }

    }
}
