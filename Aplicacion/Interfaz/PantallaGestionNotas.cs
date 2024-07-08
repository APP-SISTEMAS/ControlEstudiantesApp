﻿using Aplicacion.Gestores;
using System;

namespace Aplicacion.Interfaz
{
    internal class PantallaGestionNotas
    {
        public static GestionNotas notas = new GestionNotas();
        public static void MenuNota()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Gestion de Notas por clase");
                Console.WriteLine("1)Registrar");
                Console.WriteLine("2)Actualizar");
                Console.WriteLine("3)Gestion de Reportes de Notas");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
                switch (numeroOpcion)
                {
                    case 1:
                        break;
                    case 2:
                        Console.WriteLine("Actualizar Nota");
                        //notas.ActualizarNota();
                        break;
                    case 3:
                        PantallaReportes.MenuReporte();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.ResetColor();
            } while (continuar);
        }
    }
}
