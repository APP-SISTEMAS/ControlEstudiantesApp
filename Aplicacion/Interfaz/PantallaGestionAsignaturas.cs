using Aplicacion.Gestores;
using System;
using System.Collections.Generic;
using Aplicacion.Models;

namespace Aplicacion.Interfaz
{
    public class PantallaGestionAsignaturas
    {
        public static void MenuAsignatura()
        {
            GestionAsignaturas gestionAsignaturas = new GestionAsignaturas();
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestion de Asignaturas");
                Console.WriteLine("=======================");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1)Agregar Asignatura");
                Console.WriteLine("2)Listar Asignaturas");
                Console.WriteLine("3)Modificar Asignatura");
                Console.WriteLine("4)Eliminar Asignatura");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        Asignatura asignatura= new Asignatura();
                        Console.Clear();
                        try
                            {
                            Console.WriteLine("Agregar Asignatura");
                            Console.WriteLine("===================");
                            Console.WriteLine("Ingrese el nombre de la Asignatura:");
                            asignatura.AsignaturaNombre = Console.ReadLine();
                            asignatura.Activo = true;
                            gestionAsignaturas.Agregar(asignatura);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Asignatura agregada correctamente");
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
                        List<Asignatura> listaAsignaturas = new List<Asignatura>();
                        listaAsignaturas = gestionAsignaturas.ListarAsignaturas();

                        // Imprimir la cabecera de la tabla
                        Console.Write("-------------------------------------------");
                        Console.WriteLine(string.Format("\n{0,-5} | {1,-20} | {2,-10} |", "Id", "Asignatura", "Activo"));
                        Console.WriteLine("-------------------------------------------");

                        // Imprimir los datos
                        foreach (var asignatura1 in listaAsignaturas)
                        {
                            Console.WriteLine(string.Format("{0,-5} | {1,-20} | {2,-10} |", asignatura1.Id, asignatura1.AsignaturaNombre, asignatura1.Activo));
                        }
                        Console.WriteLine("-------------------------------------------\n");
                        Console.ReadKey();
                       /*break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Modificar Asignatura");
                            Console.WriteLine("====================");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("*Nota: Solo se pueden modificar nombre y estado de asignaturas sin calificaciones asignadas");
                            Console.ResetColor();
                            Console.WriteLine("Ingrese el Id:");
                            int idModificar = Convert.ToInt32(Console.ReadLine());
                            if (idModificar == asignatura1.id)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Nuevo nombre de la Asignatura:");
                                asignatura1.asignatura = Console.ReadLine();
                                Console.WriteLine("Ingrese el estado:");
                                asignatura1.activo = Convert.ToBoolean(Console.ReadLine());
                                Console.WriteLine("Asignatura modificada correctamente");
                            }
                            else
                            {
                                Console.WriteLine("Asignatura no encontrada");
                            }
                            Console.ResetColor();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Eliminar Asignatura");
                            Console.WriteLine("====================");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("*Nota: Solo se pueden eliminar asignaturas sin calificaciones asignadas");
                            Console.ResetColor();
                            Console.WriteLine("Ingrese el Id:");
                            int idEliminar = Convert.ToInt32(Console.ReadLine());
                            if (idEliminar == asignatura1.id)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                asignatura1.activo = false;
                                Console.WriteLine("Asignatura eliminada correctamente");
                            }
                            else
                            {
                                Console.WriteLine("Asignatura no encontrada");
                            }
                            Console.ResetColor();
                            Console.ReadKey();*/
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
