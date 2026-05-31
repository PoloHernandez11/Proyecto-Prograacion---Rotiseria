using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria.views
{
    public static class EstilosConsola
    {
        public static int MostrarMenu(string titulo, string[] opciones)
        {
            Console.Clear();

            char esquinSupIzq = '╔';
            char esquinSupDer = '╗';
            char esquinInfIzq = '╚';
            char esquinInfDer = '╝';
            char bordeHorizontal = '═';
            char bordeVertical = '║';
            char bordeHoriCenIzq = '╠';
            char bordeHoriCenDer = '╣';

            int ancho = Math.Max(titulo.Length, opciones.Max(o => o.Length)) + 6;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(esquinSupIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinSupDer);

            Console.Write(bordeVertical);
            string tituloCentrado = titulo.PadLeft((ancho + titulo.Length) / 2).PadRight(ancho);
            Console.Write($"{tituloCentrado}");
            Console.WriteLine(bordeVertical);

            Console.Write(bordeHoriCenIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(bordeHoriCenDer);

            for (int i = 0; i < opciones.Length; i++)
            {
                Console.Write(bordeVertical);
                if (opciones[i].Trim().StartsWith("0"))
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write($" {opciones[i].PadRight(ancho - 1)}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);
            }

            Console.Write(esquinInfIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinInfDer);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Seleccione una opción: ");
            Console.ResetColor();

            int opcion;

            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción inválida. Ingrese un número.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Seleccione una opción: ");
                Console.ResetColor();
            }

            return opcion;
        }

        public static void MostrarEncabezado(string titulo)
        {
            Console.Clear();
            char esquinSupIzq = '╔';
            char esquinSupDer = '╗';
            char esquinInfIzq = '╚';
            char esquinInfDer = '╝';
            char bordeHorizontal = '═';
            char bordeVertical = '║';
            int ancho = titulo.Length + 10;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(esquinSupIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinSupDer);

            Console.Write(bordeVertical);
            string tituloCentrado = titulo.PadLeft((ancho + titulo.Length) / 2).PadRight(ancho);
            Console.Write(tituloCentrado);
            Console.WriteLine(bordeVertical);

            Console.Write(esquinInfIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinInfDer);
            Console.ResetColor();
        }

        public static void MostrarError(string mensaje, bool pausar = true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n>> {mensaje}");
            Console.ResetColor();

            if (pausar)
            {
                Console.ReadKey(true);
            }
        }

        public static void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{mensaje}");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void Pausar()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
