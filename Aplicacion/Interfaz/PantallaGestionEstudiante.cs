using Aplicacion.Gestores;
using System;

namespace Aplicacion.Interfaz
{
    public class PantallaGestionEstudiante
    {

        public static void MenuEstudiante()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Gestion de Estudiante");
                Console.WriteLine("1)Registrar");
                Console.WriteLine("2)Actualizar");
                Console.WriteLine("3)Deshabilitar");
                Console.WriteLine("4)Habilitar");
                Console.WriteLine("5)Mostrar Informacion Estudiante");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        //GestionEstudiante.Registrar(estudiante);
                        break;
                    case 2:
                        //estudiante1.Actualizar();
                        break;
                    case 3:
                        //estudiante1.Deshabilitar();
                        break;
                    case 4:
                        //estudiante1.Habilitar();
                        break;
                    case 5:
                        //estudiante1.MostrarInformacion();
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
    }
}
