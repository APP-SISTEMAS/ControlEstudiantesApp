using System;

namespace EstructurasDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            do
            {
                Console.WriteLine("Aplicacion Control de Centro Educativo");
                Console.WriteLine("==================================");
                Console.WriteLine("1)Gestion de Estudiante");
                Console.WriteLine("2)Gestion de Clases");
                Console.WriteLine("3)Gestion de Notas");
                Console.WriteLine("4)Gestion de Reporteria");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        Estudiante.GestionEstudiante();
                        break;
                    case 2:
                        //Console.WriteLine("Gestion de Clases");
                        break;
                    case 3:
                        //Console.WriteLine("Gestion de Notas");
                        break;
                    case 4:
                        //Console.WriteLine("Gestion de Reporteria");
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
    }
}
