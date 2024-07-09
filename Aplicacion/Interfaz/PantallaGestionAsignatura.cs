using Aplicacion.Gestores;
using Aplicacion.Models;
using System;
using System.Collections.Generic;

namespace Aplicacion.Interfaz
{
    public class PantallaGestionAsignatura
    {
        public static GestionAsignaturas gestionAsignaturas = new GestionAsignaturas();
        public static Asignatura asignatura = new Asignatura();
        public static void MenuAsignatura()
        {
            PantallaGestionAsignatura pantallaGestionAsignatura = new PantallaGestionAsignatura();
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Gestion de Asignaturas");
                Console.WriteLine("=======================");
                Console.WriteLine("1)Agregar Asignatura");
                Console.WriteLine("2)Listar Asignaturas");
                Console.WriteLine("3)Modificar Asignatura");
                Console.WriteLine("4)Deshabilitar Asignatura");
                Console.WriteLine("5)Habilitar Asignatura");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Agregar Asignatura");
                            Console.WriteLine("===================");
                            Console.WriteLine("Ingrese el nombre de la Asignatura:");
                            asignatura.AsignaturaNombre = Console.ReadLine();
                            asignatura.Activo = true;
                            gestionAsignaturas.Agregar(asignatura);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Asignatura agregada correctamente");
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
                        Console.Clear();
                        pantallaGestionAsignatura.ListarAsignaturas();
                        Console.ReadKey();
                        break;
                    case 3:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Modificar Asignatura");
                            Console.WriteLine("====================");
                            pantallaGestionAsignatura.ListarAsignaturas();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese el Id de la Asignatura:");
                            int idModificar = Convert.ToInt32(Console.ReadLine());
                            asignatura.Id = idModificar;
                            var result = gestionAsignaturas.VerificarSiHayNotas(idModificar);
                            if (result)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No se puede modificar la asignatura porque tiene notas registradas");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine("Ingrese el nuevo nombre de la Asignatura:");
                            string nombreModificar = Console.ReadLine();
                            asignatura.AsignaturaNombre = nombreModificar;
                            gestionAsignaturas.Modificar(asignatura);
                            Console.WriteLine("Asignatura modificada correctamente");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Deshabilitar Asignatura");
                            Console.WriteLine("=======================");
                            pantallaGestionAsignatura.ListarAsignaturas();
                            Console.WriteLine("Ingrese el Id de la Asignatura:");
                            int idDeshabilitar = Convert.ToInt32(Console.ReadLine());
                            gestionAsignaturas.Deshabilitar(idDeshabilitar);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Asignatura deshabilitada correctamente");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Habilitar Asignatura");
                            Console.WriteLine("=====================");
                            pantallaGestionAsignatura.ListarAsignaturas();
                            Console.WriteLine("Ingrese el Id de la Asignatura:");
                            int idHabilitar = Convert.ToInt32(Console.ReadLine());
                            gestionAsignaturas.Habilitar(idHabilitar);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Asignatura habilitada correctamente");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex.Message);
                            Console.ReadKey();
                        }
                        break;
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
        public void ListarAsignaturas()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            List<Asignatura> listaAsignaturas = new List<Asignatura>();
            listaAsignaturas = gestionAsignaturas.ListarAsignaturas();

            // Imprimir la cabecera de la tabla
            Console.Write("-------------------------------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-20} | {2,-10} |", "Id", "Asignatura", "Activo"));
            Console.WriteLine("-------------------------------------------");

            // Imprimir los datos
            foreach (var asignatura1 in listaAsignaturas)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-20} | {2,-10} |", asignatura1.Id, asignatura1.AsignaturaNombre, (asignatura1.Activo ? "Si" : "No")));
            }
            Console.WriteLine("-------------------------------------------\n");
        }
    }
}
