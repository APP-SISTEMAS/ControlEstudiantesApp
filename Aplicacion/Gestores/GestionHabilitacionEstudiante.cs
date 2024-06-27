using Aplicacion.Models;
using System.Collections.Generic;

namespace Aplicacion.Gestores
{
    public class GestionHabilitacionEstudiante
    {
        public bool Deshabilitar(Estudiante estudiante, string motivo)
        {/*
            Console.Clear();
            Console.WriteLine("Deshabilitar Estudiante");
            Console.WriteLine("Que estudiante desea deshabilitar?");
            Listar();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese el motivo de la deshabilitacion:");
            Console.ResetColor();
            motivo = Console.ReadLine();
            activo = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Estudiante deshabilitado correctamente");
            Console.ResetColor();
            Console.ReadKey();*/
            return true;
        }
        public bool Habilitar(Estudiante estudiante, string motivo)
        {/*
            Console.Clear();
            Console.WriteLine("Habilitar Estudiante");
            Console.WriteLine("Que estudiante desea habilitar?");
            Listar();
            activo = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Estudiante habilitado correctamente");
            Console.ResetColor();
            Console.ReadKey();*/
            return true;
        }
        public List<Estudiante> EstudiantesHabilitados()
        {
            return new List<Estudiante>();
        }
        public List<Estudiante> EstudiantesDeshabilitados()
        {
            return new List<Estudiante>();
        }
    }
}
