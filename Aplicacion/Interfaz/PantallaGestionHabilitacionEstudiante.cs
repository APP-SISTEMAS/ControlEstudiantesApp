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
            try
            {
                bool continuar = true;
                var result = false;
                do
                {
                    Console.Clear();
                    int idEstudiante;
                    string motivo;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\tPantalla de Gestion de Habilitacion y Deshabilitacion de Estudiantes");
                    Console.WriteLine("==================================================================================");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n1)Habilitar Estudiante");
                    Console.WriteLine("2)Deshabilitar Estudiante");
                    Console.WriteLine("3)Mostrar Estudiantes Habilitados");
                    Console.WriteLine("4)Mostrar Estudiantes Deshabilitados");
                    Console.WriteLine("5)Mostrar Estudiantes Reingresados o Rehabilitados");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n==================================================================================");
                    Console.WriteLine("0)Salir a la pantalla anterior");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nSeleccione una opcion:");
                    int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                    switch (numeroOpcion)
                    {
                        case 1:
                            try
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Habilitar Estudiante");
                                Console.WriteLine("===========================");
                                MostrarEstudiantesDeshabilitados();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Que estudiante desea Habilitar?");
                                idEstudiante = Convert.ToInt32(Console.ReadLine());
                                result = gestionHabilitacionEstudiante.ExisteIdEstudianteInactivo(idEstudiante);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: El estudiante no existe o ya esta habilitado");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.WriteLine("Ingrese el motivo de la habilitacion:");
                                motivo = Console.ReadLine();
                                gestionHabilitacionEstudiante.HabilitarEstudiante(motivo, idEstudiante);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Estudiante habilitado correctamente");
                                Console.ReadKey();
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Ingrese un valor valido");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: " + ex.Message);
                                Console.ReadKey();
                            }
                            finally
                            {
                                Console.ResetColor();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            try
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Deshabilitar Estudiante");
                                MostrarEstudiantesHabilitados();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Que estudiante desea deshabilitar?");
                                idEstudiante = Convert.ToInt32(Console.ReadLine());
                                result = gestionHabilitacionEstudiante.ExisteIdEstudianteHabilitado(idEstudiante);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: El estudiante no existe o ya esta deshabilitado");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.WriteLine("Ingrese el motivo de la deshabilitacion:");
                                motivo = Console.ReadLine();
                                gestionHabilitacionEstudiante.DeshabilitarEstudiante(motivo, idEstudiante);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Estudiante deshabilitado correctamente");
                                Console.ReadKey();
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Ingrese un valor valido");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: " + ex.Message);
                                Console.ReadKey();
                            }
                            finally
                            {
                                Console.ResetColor();
                                Console.Clear();
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\tEstudiantes Habilitados");
                            Console.WriteLine("======================================");
                            MostrarEstudiantesHabilitados();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\tEstudiantes Deshabilitados");
                            Console.WriteLine("=========================================");
                            MostrarEstudiantesDeshabilitados();
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\tEstudiantes Reingresados o Rehabilitados");
                            Console.WriteLine("========================================================");
                            MostrarEstudiantesReingresados();
                            Console.ReadKey();
                            break;
                        case 0:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                } while (continuar);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Ingrese un valor valido");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
            }
            finally
            {
                Console.ResetColor();
                Console.Clear();
            }
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