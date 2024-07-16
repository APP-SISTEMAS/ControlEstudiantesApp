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
        public static GestionEstudiante gestionEstudiante1 = new GestionEstudiante();
        public static PantallaGestionAsignatura gestionAsignatura = new PantallaGestionAsignatura();
        public static GestionAsignaturas gestionAsignatura1 = new GestionAsignaturas();
        public static void MenuNota()
        {
            try
            {
                var result = false;
                bool continuar = true;
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\tPantalla de Gestion de Notas por clase");
                    Console.WriteLine("===================================================");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n1)Registrar Nota");
                    Console.WriteLine("2)Actualizar Nota");
                    Console.WriteLine("3)Pantalla de gestion de Reportes de Notas");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n===================================================");
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
                                Console.WriteLine("Registrar Nota");
                                Console.WriteLine("===================");
                                gestionEstudiante.ListarEstudiantes();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese el Id del Estudiante:");
                                nota.IdEstudiante = Convert.ToInt32(Console.ReadLine());
                                result= gestionEstudiante1.ExisteIdEstudiante(nota.IdEstudiante);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Este estudiante no es Valido");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                    Console.Clear();
                                    break;
                                }
                                gestionAsignatura.ListarAsignaturas();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese el Id de la Asignatura:");
                                nota.IdAsignatura = Convert.ToInt32(Console.ReadLine());
                                result = gestionAsignatura1.ExisteIdAsignaturaActiva(nota.IdAsignatura);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Esta clase no esta activa");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                    Console.Clear();
                                    break;
                                }
                                result = gestionNotas.VerificarSiYaHayNotasEstudiantePorClase(nota.IdEstudiante, nota.IdAsignatura);
                                if (result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Este estudiante ya tiene notas registradas en esta clase");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                    Console.Clear();
                                    break;
                                }
                                result = gestionNotas.ValidarIngresoNotaClaseActiva(nota.IdEstudiante, nota.IdAsignatura);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Esta asignatura no es Valida");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                    Console.Clear();
                                    break;
                                }
                                Console.WriteLine("Ingrese la Nota 1:");
                                nota.Nota1 = Convert.ToDecimal(Console.ReadLine());
                                Console.WriteLine("Ingrese la Nota 2:");
                                nota.Nota2 = Convert.ToDecimal(Console.ReadLine());
                                Console.WriteLine("Ingrese la Nota 3:");
                                nota.Nota3 = Convert.ToDecimal(Console.ReadLine());
                                Console.WriteLine("Ingrese la Nota 4:");
                                nota.Nota4 = Convert.ToDecimal(Console.ReadLine());
                                if (nota.Nota1 < 0 || nota.Nota1 > 100 || nota.Nota2 < 0 || nota.Nota2 > 100 || nota.Nota3 < 0 || nota.Nota3 > 100 || nota.Nota4 < 0 || nota.Nota4 > 100)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: Las notas deben estar entre 0 y 100");
                                    Console.ReadKey();
                                    break;
                                }
                                gestionNotas.RegistrarNota(nota);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Nota registrada correctamente");
                                Console.ReadKey();
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
                            break;
                        case 2:
                            try
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\tActualizar Nota del Estudiante");
                                Console.WriteLine("==========================================");

                                gestionEstudiante.ListarEstudiantes();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese el Id del Estudiante:");
                                int idEstudiante = Convert.ToInt32(Console.ReadLine());
                                result = gestionEstudiante1.ExisteIdEstudiante(idEstudiante);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Este estudiante no es Valido");
                                    Console.ReadKey();
                                    break;
                                }
                                result = gestionNotas.VerificarSiHayNotasPorAlumno(idEstudiante);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Este estudiante no tiene notas registradas");
                                    Console.ReadKey();
                                    break;
                                }

                                gestionAsignatura.ListarAsignaturas();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese el Id de la Asignatura:");
                                int idAsignatura = Convert.ToInt32(Console.ReadLine());
                                result = gestionAsignatura1.ExisteIdAsignaturaActiva(idAsignatura);
                                if (!result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Esta clase no esta activa");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                    Console.Clear();
                                    break;
                                }
                                result = gestionNotas.ValidarIngresoNotaClaseActiva(idEstudiante, idAsignatura);
                                if (result)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Accion no valida");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                    Console.Clear();
                                    break;
                                }

                                Nota notaActualizar = MostrarNotasPorActualizar(idEstudiante, idAsignatura);
                                notaActualizar.IdEstudiante = idEstudiante;
                                notaActualizar.IdAsignatura = idAsignatura;

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Desea ActualizarEstudiante la siguiente nota1?");
                                Console.WriteLine("1 = Si, 0 = No");
                                string respuesta = Console.ReadLine().ToLower();
                                if (respuesta != "1") break;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Nota 1 registrada: " + notaActualizar.Nota1);
                                Console.WriteLine("Ingrese la correcion o actualizacion de la Nota 1:");
                                Console.WriteLine("Advertencia: si no desea actualizar la nota 1, presione enter");
                                string nota1 = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nota1)) notaActualizar.Nota1 = Convert.ToDecimal(nota1);

                                Console.WriteLine("Nota 2 registrada: " + notaActualizar.Nota2);
                                Console.WriteLine("Ingrese la correcion o actualizacion de la Nota 2:");
                                Console.WriteLine("Advertencia: si no desea actualizar la nota 2, presione enter");
                                string nota2 = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nota2)) notaActualizar.Nota2 = Convert.ToDecimal(nota2);

                                Console.WriteLine("Nota 3 registrada: " + notaActualizar.Nota3);
                                Console.WriteLine("Ingrese la correcion o actualizacion de la Nota 3:");
                                Console.WriteLine("Advertencia: si no desea actualizar la nota 3, presione enter");
                                string nota3 = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nota3)) notaActualizar.Nota3 = Convert.ToDecimal(nota3);

                                Console.WriteLine("Nota 4 registrada: " + notaActualizar.Nota4);
                                Console.WriteLine("Ingrese la correcion o actualizacion de la Nota 4:");
                                Console.WriteLine("Advertencia: si no desea actualizar la nota 4, presione enter");
                                string nota4 = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nota4)) notaActualizar.Nota4 = Convert.ToDecimal(nota4);

                                if (notaActualizar.Nota1 < 0 || notaActualizar.Nota1 > 100 || notaActualizar.Nota2 < 0 || notaActualizar.Nota2 > 100 || notaActualizar.Nota3 < 0 || notaActualizar.Nota3 > 100 || notaActualizar.Nota4 < 0 || notaActualizar.Nota4 > 100)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: Las notas deben estar entre 0 y 100");
                                    Console.ReadKey();
                                    break;
                                }
                                gestionNotas.ActualizarNota(notaActualizar);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Nota actualizada correctamente");
                                Console.ReadKey();
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
                            break;
                        case 3:
                            PantallaReportes.MenuReporte();
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
        public static Nota MostrarNotasPorActualizar(int idEstudiante, int idAsignatura)
        {
            try
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
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                return null;
            }
        }
    }
}
