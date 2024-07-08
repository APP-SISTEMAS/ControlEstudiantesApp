using Aplicacion.Gestores;
using System;
using Aplicacion.Models;
using Aplicacion.Interfaz;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaz
{
    internal class PantallaReportes
    {
        public static GestionNotas notas = new GestionNotas();
        public static PantallaGestionAsignatura asignaturas = new PantallaGestionAsignatura();
        public static PantallaGestionEstudiante estudiantes = new PantallaGestionEstudiante();
        public static PantallaGestionNotas notas1 = new PantallaGestionNotas();
        public static void MenuReporte()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Gestion de Reportes de Notas");
                Console.WriteLine("1)Consolidado de Notas Generales");
                Console.WriteLine("2)Mostrar notas por estudiante");
                Console.WriteLine("3)Mostrar notas por clase");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
                switch (numeroOpcion)
                {
                    case 1:
                        Console.WriteLine("Registrar Nota");
                        //notas.Registrar();
                        break;
                    case 2:
                        Console.WriteLine("Actualizar Nota");
                        //notas.ActualizarNota();
                        break;
                    case 3:
                        Console.WriteLine("Mostrar notas por estudiante");
                        //notas.MostrarNotasGeneralesPorEstudiante();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            } while (continuar);
            Console.ResetColor();
        }
    }
}
