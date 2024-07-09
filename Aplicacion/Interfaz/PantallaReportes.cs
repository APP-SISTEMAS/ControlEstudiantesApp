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
    public class PantallaReportes
    {
        public static PantallaGestionAsignatura pantallaGestionAsignatura = new PantallaGestionAsignatura();
        public static PantallaGestionEstudiante pantallaGestionEstudiante = new PantallaGestionEstudiante();
        public static GestionNotas gestionNotas = new GestionNotas();
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        MostrarPromedioGeneralEstudiante();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        pantallaGestionEstudiante.ListarEstudiantes();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Seleccione el estudiante del que desea ver notas:");
                        Console.WriteLine("Sugerencia: Seleccione el ID");
                        int idEstudiante = Convert.ToInt32(Console.ReadLine());
                        MostrarNotasPorEstudiante(idEstudiante);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        pantallaGestionAsignatura.ListarAsignaturas();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Seleccione la asignatura de la que desea ver notas:");
                        Console.WriteLine("Sugerencia: Seleccione el ID");
                        int idAsignatura = Convert.ToInt32(Console.ReadLine());
                        MostrarNotasPorClase(idAsignatura);
                        Console.ReadKey();
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
        public static void MostrarNotasPorEstudiante(int idEstudiante)
        {
            List<Nota> notas = new List<Nota>();
            notas = gestionNotas.ObtenerNotasPorEstudiante(idEstudiante);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\tReporte de Notas del Estudiante");
            Console.WriteLine("-----------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Numero de Identificacion Estudiantil: " + notas[0].IdEstudiante);
            Console.WriteLine("Nombre del Estudiante: " + notas[0].NombreEstudiante+" " + notas[0].ApellidoEstudiante+"\n");

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
        public static void MostrarNotasPorClase(int idAsignatura)
        {
            List<Nota> notas = new List<Nota>();
            notas = gestionNotas.ObtenerNotasPorClase(idAsignatura);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\tReporte de Notas de la Clase");
            Console.WriteLine("----------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Asignatura: " + notas[0].NombreAsignatura + "\n");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("------------------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("\n{0,-3} |       {1,-14} |  {2,-5}  |  {3,-5}  |  {4,-5}  |  {5,-5}  | {6,-8} | {7,-8} |","ID", "Estudiante", "Nota1", "Nota2", "Nota3", "Nota4", "Promedio", "Aprobado"));
            Console.WriteLine("------------------------------------------------------------------------------------------");

            foreach (Nota nota1 in notas)
            {
                Console.WriteLine(string.Format("{0,-3} | {1,-20} |  {2,-6} |  {3,-6} |  {4,-6} |  {5,-6} |  {6,-7} |    {7,-5} |",nota1.IdEstudiante ,nota1.NombreEstudiante+" "+nota1.ApellidoEstudiante, nota1.Nota1, nota1.Nota2, nota1.Nota3, nota1.Nota4, nota1.Promedio, ((bool)nota1.Aprobado ? "Si" : "No")));
            }
            Console.WriteLine("------------------------------------------------------------------------------------------");
        }
        public static void MostrarPromedioGeneralEstudiante()
        {
            List<Nota> notas = new List<Nota>();
            notas = gestionNotas.ObtenerPromedioGeneralEstudiante();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("      Reporte de Promedio General de Estudiantes");
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("--------------------------------------------------");
            Console.WriteLine(string.Format("\n{0,-3} |       {1,-14} | {2,-8} | {3,-8} |", "ID", "Estudiante", "Promedio", "Aprobado"));
            Console.WriteLine("--------------------------------------------------");

            foreach (Nota nota1 in notas)
            {
                Console.WriteLine(string.Format("{0,-3} | {1,-20} |  {2,-7} |    {3,-5} |", nota1.IdEstudiante, nota1.NombreEstudiante + " " + nota1.ApellidoEstudiante, nota1.Promedio, ((bool)nota1.Aprobado ? "Si" : "No")));
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
