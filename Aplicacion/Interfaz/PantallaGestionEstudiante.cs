using Aplicacion.Gestores;
using System;

namespace Aplicacion.Interfaz
{
    public class PantallaGestionEstudiante
    {
        

        public static void MenuEstudiante()
        {
            GestionEstudiante gestionEstudiante = new GestionEstudiante();
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Gestion de Estudiante");
                Console.WriteLine("1)Registrar");
                Console.WriteLine("2)Actualizar");
                Console.WriteLine("3)Gestion Habilitacion-Deshabilitacion");
                Console.WriteLine("4)Mostrar Informacion Estudiante");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        //gestionEstudiante.Registrar();
                        Console.ReadKey();
                        break;
                    case 2:
                        //gestionEstudiante.Actualizar();
                        Console.ReadKey();
                        break;
                    case 3:
                        PantallaGestionHabilitacionEstudiante.MenuHabilitacionEstudiante();
                        break;
                    case 4:
                        Console.WriteLine("Seleccione el estudiante del que desea ver la información:");
                        Console.WriteLine("Nota: Seleccione el ID");
                        gestionEstudiante.ObtenerListaEstudiantes();
                        int idEstudiante = Convert.ToInt32(Console.ReadLine());
                        gestionEstudiante.ObtenerInformacionEstudiante(idEstudiante);
                        gestionEstudiante.ObtenerListaTipoSangre();
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
    }
}
