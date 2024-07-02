using Aplicacion.Gestores;
using System;

namespace Aplicacion.Interfaz
{
    internal class PantallaGestionHabilitacionEstudiante
    {
        public static void MenuHabilitacionEstudiante()
        {
            GestionHabilitacionEstudiante gestionHabilitacionEstudiante = new GestionHabilitacionEstudiante();
            bool continuar = true;
            do
            {
                Console.Clear();
                int idEstudiante;
                string motivo;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Gestion de Estudiante");
                Console.WriteLine("1)Habilitar");
                Console.WriteLine("2)Deshabilitar");
                Console.WriteLine("3)Mostrar Estudiantes Habilitados");
                Console.WriteLine("4)Mostrar Estudiantes Deshabilitados");
                Console.WriteLine("5)Mostrar Estudiantes Reingresados/Rehabilitados");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        Console.WriteLine("Habilitar Estudiante");
                        Console.WriteLine("Que estudiante desea Habilitar?");
                        gestionHabilitacionEstudiante.EstudiantesDeshabilitados();
                        idEstudiante = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el motivo de la habilitacion:");
                        motivo = Console.ReadLine();
                        gestionHabilitacionEstudiante.Habilitar(motivo, idEstudiante);
                        Console.WriteLine("Estudiante habilitado correctamente");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Deshabilitar Estudiante");
                        Console.WriteLine("Que estudiante desea deshabilitar?");
                        gestionHabilitacionEstudiante.EstudiantesHabilitados();
                        idEstudiante = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el motivo de la deshabilitacion:");
                        motivo = Console.ReadLine();
                        gestionHabilitacionEstudiante.Deshabilitar(motivo, idEstudiante);
                        Console.WriteLine("Estudiante deshabilitado correctamente");
                        Console.ReadKey();
                        break;
                    case 3:
                        gestionHabilitacionEstudiante.EstudiantesHabilitados();
                        Console.ReadKey();
                        break;
                    case 4:
                        gestionHabilitacionEstudiante.EstudiantesDeshabilitados();
                        Console.ReadKey();
                        break;
                    case 5:
                        gestionHabilitacionEstudiante.EstudiantesReingresados();
                        Console.ReadKey();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.ResetColor();
            } while (continuar);
        }
    }
}
