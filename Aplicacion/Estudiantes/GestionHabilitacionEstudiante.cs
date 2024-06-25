using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Estudiantes
{
    public class GestionHabilitacionEstudiante
    {
        public GestionHabilitacionEstudiante(int id,bool estado, string motivo)
        {
        }
        public Boolean Deshabilitar(Estudiante estudiante, string motivo)
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
        public Boolean Habilitar(Estudiante estudiante, string motivo)
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
