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
                        Console.WriteLine("Que estudiante1 desea Habilitar?");
                        MostrarEstudiantesDeshabilitados();
                        idEstudiante = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el motivo de la habilitacion:");
                        motivo = Console.ReadLine();
                        gestionHabilitacionEstudiante.Habilitar(motivo, idEstudiante);
                        Console.WriteLine("Estudiante habilitado correctamente");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Deshabilitar Estudiante");
                        Console.WriteLine("Que estudiante1 desea deshabilitar?");
                        MostrarEstudiantesHabilitados();
                        idEstudiante = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el motivo de la deshabilitacion:");
                        motivo = Console.ReadLine();
                        gestionHabilitacionEstudiante.Deshabilitar(motivo, idEstudiante);
                        Console.WriteLine("Estudiante deshabilitado correctamente");
                        Console.ReadKey();
                        break;
                    case 3:
                        MostrarEstudiantesHabilitados();
                        Console.ReadKey();
                        break;
                    case 4:
                        MostrarEstudiantesDeshabilitados();
                        Console.ReadKey();
                        break;
                    case 5:
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
                Console.ResetColor();
            } while (continuar);
        }
        public static void MostrarEstudiantesHabilitados()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            listaEstudiantes=gestionHabilitacionEstudiante.EstudiantesHabilitados();
            // Imprimir la cabecera de la tabla
            Console.Write("---------------------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-10} | {2,-10} |", "Id", "Nombre", "Apellido"));
            Console.WriteLine("---------------------------------");

            // Imprimir los datos
            foreach (var estudiante1 in listaEstudiantes)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-10} |", estudiante1.Id, estudiante1.Nombre, estudiante1.Apellido));
            }
            Console.WriteLine("---------------------------------\n");
            Console.ResetColor();
        }
        public static void MostrarEstudiantesDeshabilitados()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            List<Estudiante> listaEstudiantes = gestionHabilitacionEstudiante.EstudiantesDeshabilitados();
            listaEstudiantes = new List<Estudiante>();
            // Imprimir la cabecera de la tabla
            Console.Write("------------------------------------------------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-10} | {2,-10} | {3,-25} |", "Id", "Nombre", "Apellido", "Motivo"));
            Console.WriteLine("------------------------------------------------------------");

            // Imprimir los datos
            foreach (var estudiante1 in listaEstudiantes)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-10} | {3,-25} |", estudiante1.Id, estudiante1.Nombre, estudiante1.Apellido, estudiante1.Motivo));
            }
            Console.WriteLine("------------------------------------------------------------\n");
            Console.ResetColor();
        }
        public static void MostrarEstudiantesReingresados()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            listaEstudiantes = gestionHabilitacionEstudiante.EstudiantesReingresados();
            // Imprimir la cabecera de la tabla
            Console.Write("------------------------------------------------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-10} | {2,-10} | {3,-25} |", "Id", "Nombre", "Apellido", "Motivo"));
            Console.WriteLine("------------------------------------------------------------");

            // Imprimir los datos
            foreach (var estudiante1 in listaEstudiantes)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-10} | {3,-25} |", estudiante1.Id, estudiante1.Nombre, estudiante1.Apellido, estudiante1.Motivo));
            }
            Console.WriteLine("------------------------------------------------------------\n");
            Console.ResetColor();
        }
    }
}
