using Aplicacion.Gestores;
using Aplicacion.Models;
using System;
using System.Collections.Generic;

namespace Aplicacion.Interfaz
{
    public class PantallaReportes
    {
        public static PantallaGestionAsignatura pantallaGestionAsignatura = new PantallaGestionAsignatura();
        public static PantallaGestionEstudiante pantallaGestionEstudiante = new PantallaGestionEstudiante();
        public static GestionNotas gestionNotas = new GestionNotas();
        public static GestionAsignaturas gestionAsignaturas = new GestionAsignaturas();
        public static void MenuReporte()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Gestion de Reportes de Notas");
                Console.WriteLine("1)Consolidado de Notas Generales");
                Console.WriteLine("2)Mostrar Notas por estudiante");
                Console.WriteLine("3)Mostrar Notas por clase");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
                switch (numeroOpcion)
                {
                    case 1:
                        Console.Clear();
                        MostrarPromedioGeneralEstudiante();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        pantallaGestionEstudiante.ListarEstudiantes();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Seleccione el estudiante del que desea ver sus notas:");
                        Console.WriteLine("Sugerencia: Seleccione el ID");
                        int idEstudiante = Convert.ToInt32(Console.ReadLine());
                        var result = gestionNotas.VerificarSiHayNotasPorAlumno(idEstudiante);
                        if (!result)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Este estudiante no tiene notas registradas");
                            Console.ReadKey();
                            Console.ResetColor();
                            Console.Clear();
                            break;
                        }
                        MostrarNotasPorEstudiante(idEstudiante);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();                        
                        pantallaGestionAsignatura.ListarAsignaturas();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Seleccione la asignatura de la que desea ver sus notas:");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Sugerencia: Seleccione el ID");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int idAsignatura = Convert.ToInt32(Console.ReadLine());
                        result = gestionNotas.VerificarSiHayNotasPorClase(idAsignatura);
                        if (!result)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Este estudiante no tiene notas registradas");
                            Console.ReadKey();
                            Console.ResetColor();
                            Console.Clear();
                            break;
                        }
                        MostrarNotasPorClase(idAsignatura);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.Clear();
                Console.ResetColor();
            } while (continuar);
            Console.Clear();
        }
        public static void MostrarNotasPorEstudiante(int idEstudiante)
        {
            try
            {
                List<Nota> notas = new List<Nota>();
                var result = gestionNotas.VerificarSiHayNotasPorAlumno(idEstudiante);
                if (!result)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Este estudiante no tiene notas registradas");
                    return;
                }
                notas = gestionNotas.ObtenerNotasPorEstudiante(idEstudiante);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\tReporte de Notas del Estudiante");
                Console.WriteLine("-----------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Numero de Identificacion Estudiantil: " + notas[0].IdEstudiante);
                Console.WriteLine("Nombre del Estudiante: " + notas[0].NombreEstudiante + " " + notas[0].ApellidoEstudiante + "\n");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("------------------------------------------------------------------------------------");
                Console.WriteLine(string.Format("\n      {0,-14} |  {1,-5}  |  {2,-5}  |  {3,-5}  |  {4,-5}  | {5,-8} | {6,-8} |", "Asignatura", "Nota1", "Nota2", "Nota3", "Nota4", "Promedio", "Aprobado"));
                Console.WriteLine("------------------------------------------------------------------------------------");

                foreach (Nota nota1 in notas)
                {
                    Console.WriteLine(string.Format("{0,-20} |  {1,-6} |  {2,-6} |  {3,-6} |  {4,-6} |  {5,-7} |    {6,-5} |", nota1.NombreAsignatura, nota1.Nota1, nota1.Nota2, nota1.Nota3, nota1.Nota4, nota1.Promedio, ((bool)nota1.Aprobado ? "Si" : "No")));
                }
                Console.WriteLine("------------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ResetColor();
        }
        public static void MostrarNotasPorClase(int idAsignatura)
        {
            try
            {
                List<Nota> notas = new List<Nota>();
                notas = gestionNotas.ObtenerNotasPorClase(idAsignatura);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\tReporte de Notas de la Clase");
                Console.WriteLine("----------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Asignatura: " + notas[0].NombreAsignatura + "\n");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("---------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(string.Format("\n  {0,-2} |                {1,-25} |  {2,-5}  |  {3,-5}  |  {4,-5}  |  {5,-5}  | {6,-8} | {7,-8} |", "ID", "Estudiante", "Nota1", "Nota2", "Nota3", "Nota4", "Promedio", "Aprobado"));
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

                foreach (Nota nota1 in notas)
                {
                    Console.WriteLine(string.Format(" {0,-3} | {1,-40} |  {2,-6} |  {3,-6} |  {4,-6} |  {5,-6} |  {6,-7} |    {7,-5} |", nota1.IdEstudiante, nota1.NombreEstudiante + " " + nota1.ApellidoEstudiante, nota1.Nota1, nota1.Nota2, nota1.Nota3, nota1.Nota4, nota1.Promedio, ((bool)nota1.Aprobado ? "Si" : "No")));
                }
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ResetColor();
        }
        public static void MostrarPromedioGeneralEstudiante()
        {
            try
            {
                List<Nota> notas = new List<Nota>();
                notas = gestionNotas.ObtenerPromedioGeneralEstudiante();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\t\tReporte de Promedio General de Estudiantes");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("-----------------------------------------------------------------------");
                Console.WriteLine(string.Format("\n  {0,-2} |                {1,-25} | {2,-8} | {3,-8} |", "ID", "Estudiante", "Promedio", "Aprobado"));
                Console.WriteLine("-----------------------------------------------------------------------");

                foreach (Nota nota1 in notas)
                {
                    Console.WriteLine(string.Format(" {0,-3} | {1,-40} |  {2,-7} |    {3,-5} |", nota1.IdEstudiante, nota1.NombreEstudiante + " " + nota1.ApellidoEstudiante, nota1.Promedio, ((bool)nota1.Aprobado ? "Si" : "No")));
                }
                Console.WriteLine("-----------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ResetColor();
        }
    }
}
