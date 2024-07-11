using Aplicacion.Gestores;
using System;
namespace Aplicacion.Interfaz
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Control de Centro Educativo";
            GestionEstudiante gestionEstudiante = new GestionEstudiante();
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Aplicacion Control de Centro Educativo");
                Console.WriteLine("==================================");
                Console.WriteLine("1)Gestion de Estudiante");
                Console.WriteLine("2)Gestion de Asignaturas");
                Console.WriteLine("3)Gestion de Registro de Notas y Reportes de Notas");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        Console.Clear();
                        PantallaGestionEstudiante.MenuEstudiante();
                        break;
                    case 2:
                        Console.Clear();
                        PantallaGestionAsignatura.MenuAsignatura();
                        break;
                    case 3:
                        Console.Clear();
                        PantallaGestionNotas.MenuNota();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            } while (continuar);
            Console.ResetColor();
        }
    }
}
