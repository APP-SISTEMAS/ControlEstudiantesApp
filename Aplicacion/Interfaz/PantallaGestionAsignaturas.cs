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
                        Console.Clear();
                        Console.WriteLine("Agregar Asignatura");
                        Console.WriteLine("==================");

                        Console.ForegroundColor = ConsoleColor.Green;
                        /*Console.WriteLine("Ingrese el nombre de la Asignatura:");
                        asignatura1.asignatura = Console.ReadLine();
                        asignatura1.activo = true;
                        Console.WriteLine("Asignatura agregada correctamente");
                        Console.ResetColor();
                        Console.ReadKey();*/
                        break;
                    case 2:
                        Console.Clear();
                        List<Asignatura> listaAsignaturas = new List<Asignatura>();
                        listaAsignaturas = gestionAsignaturas.ListarAsignaturas();
                        Console.WriteLine("Listado de Asignaturas");
                        Console.WriteLine("=======================");
                        foreach (var asignatura in listaAsignaturas)
                        {
                            Console.WriteLine("Id: " + asignatura.Id);
                            Console.WriteLine("Asignatura: " + asignatura.AsignaturaNombre);
                            Console.WriteLine("Estado: " + asignatura.Activo);
                            Console.WriteLine("=======================");
                        }
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
