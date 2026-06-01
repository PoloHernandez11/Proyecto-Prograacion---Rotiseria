using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.controllers
{
    public class EmpleadoController
    {
        private List<Empleado> empleados;

        public EmpleadoController()
        {
            empleados = new List<Empleado>();
        }

        //datos de un cajero
        public bool AgregarCajero(string nombre, string apellido, int dni, DateTime fechaIngreso, string turno, double salario)
        {
            if (!ValidarDatosBasicos(nombre, apellido, dni, turno, salario))
            {
                return false;
            }

            if (ExisteEmpleado(dni))
            {
                return false;
            }

            Cajero cajero = new Cajero(nombre, apellido, dni, "Cajero", fechaIngreso, turno, salario);

            empleados.Add(cajero);
            return true;
        }

        //datos cocinero
        public bool AgregarCocinero(string nombre, string apellido, int dni, DateTime fechaIngreso, string turno, double salario, string especialidad)
        {
            if (!ValidarDatosBasicos(nombre, apellido, dni, turno, salario))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(especialidad))
            {
                return false;
            }

            Cocinero cocinero = new Cocinero(nombre, apellido, dni, "Cocinero", fechaIngreso, turno, salario, especialidad);

            empleados.Add(cocinero);
            return true;
        }

        //datos de un repartidor
        public bool AgregarRepartidor(string nombre, string apellido, int dni, DateTime fechaIngreso, string turno, double salario, string vehiculo)
        {
            if (!ValidarDatosBasicos(nombre, apellido, dni, turno, salario))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(vehiculo))
            {
                return false;
            }

            if (ExisteEmpleado(dni))
            {
                return false;
            }

            Repartidor repartidor = new Repartidor(nombre, apellido, dni, "Repartidor", fechaIngreso, turno, salario, vehiculo);

            empleados.Add(repartidor);
            return true;

        }

        //datos limpieza
        public bool AgregarLimpieza(string nombre, string apellido, int dni, DateTime fechaIngreso, string turno, double salario, string sector)
        {
            if (!ValidarDatosBasicos(nombre, apellido, dni, turno, salario))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(sector))
            {
                return false;
            }

            if (ExisteEmpleado(dni))
            {
                return false;
            }

            Limpieza limpieza = new Limpieza(nombre, apellido, dni, "Limpieza", fechaIngreso, turno, salario, sector);

            empleados.Add(limpieza);
            return true;
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return empleados;
        }

        public Empleado BuscarEmpleadoPorDni(int dni)
        {
            foreach (Empleado empleado in empleados)
            {
                if (empleado.Dni == dni)
                {
                    return empleado;
                }
            }
            return null;
        }

        public bool EliminarEmpleado(int dni)
        {
            Empleado empleadoEncontrado = BuscarEmpleadoPorDni(dni);
            
            if (empleadoEncontrado == null)
            {
                return false;
            }

            empleados.Remove(empleadoEncontrado);
            return true;
        }

        public List<Empleado> ObtenerPorPuesto(string puesto)
        {
            List<Empleado> empleadosPorPuesto = new List<Empleado>();

            foreach (Empleado empleado in empleados)
            {
                if (empleado.Puesto.ToLower() == puesto.ToLower())
                {
                    empleadosPorPuesto.Add(empleado);
                }
            }

            return empleadosPorPuesto;
        }

        public List<Cajero> ObtenerCajeros()
        {
            List<Cajero> cajeros = new List<Cajero>();

            foreach (Empleado empleado in empleados)
            {
                if (empleado is Cajero)
                {
                    cajeros.Add((Cajero)empleado);
                }
            }

            return cajeros;
        }

        public List<Cocinero> ObtenerCocineros()
        {
            List<Cocinero> cocineros = new List<Cocinero>();

            foreach (Empleado empleado in empleados)
            {
                if (empleado is Cocinero)
                {
                    cocineros.Add((Cocinero)empleado);
                }
            }
            return cocineros;
        }

        public List<Repartidor> ObtenerRepartidores()
        {
            List<Repartidor> repartidores = new List<Repartidor>();

            foreach (Empleado empleado in empleados)
            {
                if (empleado is Repartidor)
                {
                    repartidores.Add((Repartidor)empleado);
                }
            }

            return repartidores;
        }

        public List<Limpieza> ObtenerPersonalLimpieza()
        {
            List<Limpieza> limpieza = new List<Limpieza>();

            foreach (Empleado empleado in empleados)
            {
                if (empleado is Limpieza)
                {
                    limpieza.Add((Limpieza)empleado);
                }
            }

            return limpieza;
        }

        public double CalcularTotalSalarios()
        {
            double total = 0;

            foreach (Empleado empleado in empleados)
            {
                total += empleado.Salario;
            }

            return total;
        }

        //validacioness
        public bool ExisteEmpleado(int dni)
        {
            foreach (Empleado empleado in empleados)
            {
                if (empleado.Dni == dni)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidarDatosBasicos(string nombre, string apellido, int dni, string turno, double salario)
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

            if (string.IsNullOrWhiteSpace(turno))
            {
                return false;
            }

            if (salario < 0)
            {
                return false;
            }

            return true;
        }
    }
}
