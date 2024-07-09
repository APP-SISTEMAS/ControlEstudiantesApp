
using Aplicacion.Gestores;
using Aplicacion.Models;
using System;
namespace Aplicacion.Interfaz
{
    public class PantallaGestionNotas
    {
        public static GestionNotas gestionNotas = new GestionNotas();
        public static Nota nota = new Nota();
        public static PantallaGestionEstudiante gestionEstudiante = new PantallaGestionEstudiante();
        public static PantallaGestionAsignatura gestionAsignatura = new PantallaGestionAsignatura();
        public static void MenuNota()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Gestion de Notas por clase");
                Console.WriteLine("1)Registrar");
                Console.WriteLine("2)Actualizar");
                Console.WriteLine("3)Gestion de Reportes de Notas");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
                switch (numeroOpcion)
                {
                    case 1:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registrar Nota");
                            Console.WriteLine("===================");
                            gestionEstudiante.ListarEstudiantes();
                            Console.WriteLine("Ingrese el Id del Estudiante:");
                            nota.IdEstudiante = Convert.ToInt32(Console.ReadLine());
                            gestionAsignatura.ListarAsignaturas();
                            Console.WriteLine("Ingrese el Id de la Asignatura:");
                            nota.IdAsignatura = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese la Nota 1:");
                            nota.Nota1 = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("Ingrese la Nota 2:");
                            nota.Nota2 = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("Ingrese la Nota 3:");
                            nota.Nota3 = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("Ingrese la Nota 4:");
                            nota.Nota4 = Convert.ToDecimal(Console.ReadLine());
                            gestionNotas.Registrar(nota);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Nota registrada correctamente");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Actualizar Nota");
                            Console.WriteLine("===================");

                            gestionEstudiante.ListarEstudiantes();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese el Id del Estudiante:");
                            int idEstudiante = Convert.ToInt32(Console.ReadLine());

                            gestionAsignatura.ListarAsignaturas();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese el Id de la Asignatura:");
                            int idAsignatura = Convert.ToInt32(Console.ReadLine());

                            Nota notaActualizar = MostrarNotasPorActualizar(idEstudiante, idAsignatura);
                            notaActualizar.IdEstudiante = idEstudiante;
                            notaActualizar.IdAsignatura = idAsignatura;

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Desea Actualizar la siguiente nota1?");
                            Console.WriteLine("s = si, n = no");
                            string respuesta = Console.ReadLine().ToLower();
                            if (respuesta != "s") break;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Nota 1 registrada: " + notaActualizar.Nota1);
                            Console.WriteLine("Ingrese la correcion o actualizacion de la Nota 1:");
                            Console.WriteLine("Advertencia: si no desea actualizar la nota1 1, presione enter");
                            string nota1 = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nota1)) notaActualizar.Nota1 = Convert.ToDecimal(nota1);

                            Console.WriteLine("Nota 2 registrada: " + notaActualizar.Nota2);
                            Console.WriteLine("Ingrese la correcion o actualizacion de la Nota 2:");
                            Console.WriteLine("Advertencia: si no desea actualizar la nota1 2, presione enter");
                            string nota2 = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nota2)) notaActualizar.Nota2 = Convert.ToDecimal(nota2);

                            Console.WriteLine("Nota 3 registrada: " + notaActualizar.Nota3);
                            Console.WriteLine("Ingrese la correcion o actualizacion de la Nota 3:");
                            Console.WriteLine("Advertencia: si no desea actualizar la nota1 3, presione enter");
                            string nota3 = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nota3)) notaActualizar.Nota3 = Convert.ToDecimal(nota3);

                            Console.WriteLine("Nota 4 registrada: " + notaActualizar.Nota4);
                            Console.WriteLine("Ingrese la correcion o actualizacion de la Nota 4:");
                            Console.WriteLine("Advertencia: si no desea actualizar la nota1 4, presione enter");
                            string nota4 = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nota4)) notaActualizar.Nota4 = Convert.ToDecimal(nota4);

                            gestionNotas.ActualizarNota(notaActualizar, idEstudiante, idAsignatura);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Nota actualizada correctamente");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        PantallaReportes.MenuReporte();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.ResetColor();
            } while (continuar);
        }
        public static Nota MostrarNotasPorActualizar(int idEstudiante, int idAsignatura)
        {
            Nota nota1 = gestionNotas.ObtenerNotasPorActualizar(idEstudiante, idAsignatura);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Notas registradas:");
            Console.WriteLine("===================");
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Nota 1: " + nota1.Nota1);
            Console.WriteLine("Nota 2: " + nota1.Nota2);
            Console.WriteLine("Nota 3: " + nota1.Nota3);
            Console.WriteLine("Nota 4: " + nota1.Nota4);
            Console.ResetColor();
            return nota1;
        }
    }
}
