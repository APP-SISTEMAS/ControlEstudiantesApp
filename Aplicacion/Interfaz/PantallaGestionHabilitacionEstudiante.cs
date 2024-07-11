using Aplicacion.Gestores;
using Aplicacion.Models;
using System;
using System.Collections.Generic;

namespace Aplicacion.Interfaz
{
    public class PantallaGestionHabilitacionEstudiante
    {

        public static GestionHabilitacionEstudiante gestionHabilitacionEstudiante = new GestionHabilitacionEstudiante();
        public static void MenuHabilitacionEstudiante()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                int idEstudiante;
                string motivo;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Gestion de Estudiante");
                Console.WriteLine("1)Habilitar Estudiante");
                Console.WriteLine("2)Deshabilitar Estudiante");
                Console.WriteLine("3)Mostrar Estudiantes Habilitados");
                Console.WriteLine("4)Mostrar Estudiantes Deshabilitados");
                Console.WriteLine("5)Mostrar Estudiantes Reingresados/Rehabilitados");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("HabilitarAsignatura Estudiante");                            
                            MostrarEstudiantesDeshabilitados();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Que estudiante1 desea HabilitarAsignatura?");
                            idEstudiante = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese el motivo de la habilitacion:");
                            motivo = Console.ReadLine();
                            gestionHabilitacionEstudiante.HabilitarEstudiante(motivo, idEstudiante);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Estudiante habilitado correctamente");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex.Message);
                            Console.ReadKey();
                        }                        
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case 2:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("DeshabilitarAsignatura Estudiante");
                            MostrarEstudiantesHabilitados();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Que estudiante1 desea deshabilitar?");
                            idEstudiante = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese el motivo de la deshabilitacion:");
                            motivo = Console.ReadLine();
                            gestionHabilitacionEstudiante.DeshabilitarEstudiante(motivo, idEstudiante);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Estudiante deshabilitado correctamente");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex.Message);
                            Console.ReadKey();
                        }
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case 3:
                        MostrarEstudiantesHabilitados();
                        Console.ReadKey();
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case 4:
                        MostrarEstudiantesDeshabilitados();
                        Console.ReadKey();
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case 5:
                        MostrarEstudiantesReingresados();
                        Console.ReadKey();
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.ResetColor();
                Console.Clear();
            } while (continuar);
            Console.Clear();
        }
        public static void MostrarEstudiantesHabilitados()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                List<Estudiante> listaEstudiantes = new List<Estudiante>();
                listaEstudiantes = gestionHabilitacionEstudiante.EstudiantesHabilitados();
                Console.Write("-------------------------------------------------");
                Console.WriteLine(string.Format("\n  {0,-2} |                {1,-25} |", "Id", "Estudiante"));
                Console.WriteLine("-------------------------------------------------");

                foreach (var estudiante1 in listaEstudiantes)
                {
                    Console.WriteLine(string.Format(" {0,-3} | {1,-40} |", estudiante1.Id, estudiante1.Nombre + " " + estudiante1.Apellido));
                }
                Console.WriteLine("-------------------------------------------------");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public static void MostrarEstudiantesDeshabilitados()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                List<Estudiante> listaEstudiantes = new List<Estudiante>();
                listaEstudiantes = gestionHabilitacionEstudiante.EstudiantesDeshabilitados();

                Console.Write("-----------------------------------------------------------------------------------------------------------");
                Console.WriteLine(string.Format("\n  {0,-2} |                {1,-25} |           {2,-45} |", "Id", "Estudiante", "Motivo"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

                foreach (var estudiante1 in listaEstudiantes)
                {
                    Console.WriteLine(string.Format(" {0,-3} | {1,-40} | {2,-55} |", estudiante1.Id, estudiante1.Nombre + " " + estudiante1.Apellido, estudiante1.Motivo));
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public static void MostrarEstudiantesReingresados()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                List<Estudiante> listaEstudiantes = new List<Estudiante>();
                listaEstudiantes = gestionHabilitacionEstudiante.EstudiantesReingresados();

                Console.Write("-----------------------------------------------------------------------------------------------------------");
                Console.WriteLine(string.Format("\n  {0,-2} |                {1,-25} |           {2,-45} |", "Id", "Estudiante", "Motivo"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

                foreach (var estudiante1 in listaEstudiantes)
                {
                    Console.WriteLine(string.Format(" {0,-3} | {1,-40} | {2,-55} |", estudiante1.Id, estudiante1.Nombre + " " + estudiante1.Apellido, estudiante1.Motivo));
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
