using System;
using Aplicacion.Config;
namespace Aplicacion.Interfaz
{
    class Program
    {
        static void Main()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Aplicacion Control de Centro Educativo");
                Console.WriteLine("==================================");
                Console.WriteLine("1)Gestion de Estudiante");
                Console.WriteLine("2)Gestion de Asignaturas");
                Console.WriteLine("3)Gestion de Notas y Reportes finales");
                Console.WriteLine("4)Gestion de Departamentos");
                Console.WriteLine("5)Gestion de Municipios");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        PantallaGestionEstudiante.MenuEstudiante();
                        break;
                    case 2:
                        PantallaGestionAsignaturas.MenuAsignatura();
                        break;
                    /*case 3:
                        Nota.GestionNota();
                        break;
                    case 4:
                        Departamento.GestionDepartamento();
                        break;
                    case 5:
                        Municipio.GestionMunicipio();
                        break;*/
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
