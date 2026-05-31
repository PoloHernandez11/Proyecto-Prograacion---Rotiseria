using Proyecto_Roticeria.controllers;
using Proyecto_Roticeria.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Roticeria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuView menuView = new MenuView();
            menuView.MostrarMenuPrincipal();
        }
    }
}
