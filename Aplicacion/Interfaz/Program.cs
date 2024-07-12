using Aplicacion.Gestores;
using System;
namespace Aplicacion.Interfaz
{
    class Program
    {
        public static void Main()
        {
            Console.Title = "Control de Centro Educativo";
            try
            {
                bool continuar = true;
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\tAplicacion Control de Centro Educativo");
                    Console.WriteLine("===================================================");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n1)Gestion de Estudiante");
                    Console.WriteLine("2)Gestion de Asignaturas");
                    Console.WriteLine("3)Gestion de Registro de Notas y Reportes de Notas");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n===================================================");
                    Console.WriteLine("0)Cerrar el programa");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nSeleccione una opcion:");
                    int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                    switch (numeroOpcion)
                    {
                        case 1:
                            Console.Clear();
                            PantallaGestionEstudiante.MenuEstudiante();
                            break;
                        case 2:
                            Console.Clear();
                            PantallaGestionAsignatura.MenuAsignatura();
                            break;
                        case 3:
                            Console.Clear();
                            PantallaGestionNotas.MenuNota();
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
                Console.WriteLine("Error: Datos Incorrectos. Asegúrese de ingresar números válidos.");
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
    }
}
