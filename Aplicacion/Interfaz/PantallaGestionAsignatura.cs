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
            try
            {

                PantallaGestionAsignatura pantallaGestionAsignatura = new PantallaGestionAsignatura();
                bool continuar = true;
                var result = false;
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\tPantalla de Gestion de Asignaturas");
                    Console.WriteLine("==============================================");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n1)Registrar Asignatura");
                    Console.WriteLine("2)Listar Asignaturas");
                    Console.WriteLine("3)Modificar Asignatura");
                    Console.WriteLine("4)Deshabilitar Asignatura");
                    Console.WriteLine("5)Habilitar Asignatura");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n==============================================");
                    Console.WriteLine("0)Salir a la pantalla anterior");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nSeleccione una opcion:");
                    int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                    switch (numeroOpcion)
                    {
                        case 1:
                            try
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Registrar Asignatura");
                                Console.WriteLine("========================");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese el nombre de la Asignatura:");
                                asignatura.AsignaturaNombre = Console.ReadLine();
                                result = gestionAsignaturas.VerificarSiClaseExiste(asignatura.AsignaturaNombre);
                                if (result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Esta clase ya existe");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                    Console.Clear();
                                    break;
                                }
                                asignatura.Activo = true;
                                var mensajeValidacion = gestionAsignaturas.ValidarAsignatura(asignatura);
                                if (mensajeValidacion != "")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(mensajeValidacion);
                                    Console.ReadKey();
                                    break;
                                }
                                gestionAsignaturas.RegistrarAsignatura(asignatura);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Asignatura agregada correctamente");
                                Console.ReadKey();
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Datos Erroneos");
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
                            break;
                        case 2:
                            Console.Clear();
                            pantallaGestionAsignatura.ListarAsignaturas();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            try
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Modificar Asignatura");
                                Console.WriteLine("=========================");
                                pantallaGestionAsignatura.ListarAsignaturas();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese el Id de la Asignatura:");
                                int idAsignatura = Convert.ToInt32(Console.ReadLine());
                                result = gestionAsignaturas.ExisteIdAsignaturaActiva(idAsignatura);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("La Asignatura no existe");
                                    Console.ReadKey();
                                    break;
                                }
                                asignatura.Id = idAsignatura;
                                Console.Clear();
                                result = gestionAsignaturas.VerificarSiHayNotas(idAsignatura);
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
                                gestionAsignaturas.ModificarAsignatura(asignatura);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Asignatura modificada correctamente");
                                Console.ReadKey();
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Datos Erroneos");
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
                            break;
                        case 4:
                            try
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Deshabilitar Asignatura");
                                Console.WriteLine("============================");
                                pantallaGestionAsignatura.ListarAsignaturas();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese el Id de la Asignatura:");
                                int idAsignatura = Convert.ToInt32(Console.ReadLine());
                                result = gestionAsignaturas.ExisteIdAsignaturaActiva(idAsignatura);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Asignatura no habilitada o no existe");
                                    Console.ReadKey();
                                    break;
                                }
                                gestionAsignaturas.DeshabilitarAsignatura(idAsignatura);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Asignatura deshabilitada correctamente");
                                Console.ReadKey();
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Datos Erroneos");
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
                            break;
                        case 5:
                            try
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Habilitar Asignatura");
                                Console.WriteLine("=========================");
                                pantallaGestionAsignatura.ListarAsignaturas();
                                Console.WriteLine("Ingrese el Id de la Asignatura:");
                                int idAsignatura = Convert.ToInt32(Console.ReadLine());
                                result = gestionAsignaturas.ExisteIdAsignaturaInactiva(idAsignatura);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Asignatura habilitada o no existe");
                                    Console.ReadKey();
                                    break;
                                }
                                gestionAsignaturas.HabilitarAsignatura(idAsignatura);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Asignatura habilitada correctamente");
                                Console.ReadKey();
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Datos Erroneos");
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
                Console.WriteLine("Error: Debe ingresar un numero");
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
        public void ListarAsignaturas()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                List<Asignatura> listaAsignaturas = new List<Asignatura>();
                listaAsignaturas = gestionAsignaturas.ListarAsignaturas();

                Console.Write("-------------------------------------------");
                Console.WriteLine(string.Format("\n{0,-5} | {1,-20} | {2,-10} |", "Id", "Asignatura", "Activo"));
                Console.WriteLine("-------------------------------------------");

                foreach (var asignatura1 in listaAsignaturas)
                {
                    Console.WriteLine(string.Format("{0,-5} | {1,-20} | {2,-10} |", asignatura1.Id, asignatura1.AsignaturaNombre, (asignatura1.Activo ? "Si" : "No")));
                }
                Console.WriteLine("-------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}