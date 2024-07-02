using Aplicacion.Gestores;
using Aplicacion.Models;
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
                        Estudiante estudiante = new Estudiante();
                        Console.Clear();
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registro de Estudiante");
                            Console.WriteLine("Ingrese el nombre del estudiante:");
                            estudiante.Nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del estudiante:");
                            estudiante.Apellido = Console.ReadLine();
                            Console.WriteLine("Ingrese la fecha de nacimiento del estudiante:");
                            estudiante.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Ingrese la identificacion del estudiante:");
                            estudiante.Identificacion = Console.ReadLine();
                            Console.WriteLine("Ingrese el genero del estudiante:");
                            Console.WriteLine("M = Masculino, F = Femenino");
                            estudiante.Genero = Convert.ToChar(Console.ReadLine());
                            estudiante.Activo = true;
                            Console.WriteLine("Ingrese el telefono del estudiante:");
                            estudiante.Telefono = Console.ReadLine();
                            Console.WriteLine("Ingrese el departamento del estudiante:");
                            gestionEstudiante.ObtenerListaDepartamentos();
                            estudiante.Departamento = Console.ReadLine();
                            Console.WriteLine("Ingrese el municipio del estudiante:");
                            gestionEstudiante.ObtenerListaMunicipios();
                            estudiante.Municipio = Console.ReadLine();
                            Console.WriteLine("Ingrese la direccion del estudiante:");
                            estudiante.Direccion = Console.ReadLine();
                            Console.WriteLine("Ingrese el correo del estudiante:");
                            estudiante.Correo = Console.ReadLine();
                            Console.WriteLine("Ingrese el tipo de sangre del estudiante:");
                            gestionEstudiante.ObtenerListaTipoSangre();
                            estudiante.TipoSangre = Console.ReadLine();
                            Console.WriteLine("Ingrese el tutor del estudiante:");
                            estudiante.Tutor = Console.ReadLine();

                            var mensajeValidacion = gestionEstudiante.ValidarEstudiante(estudiante);
                            if (mensajeValidacion != "")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(mensajeValidacion);
                                Console.ReadKey();
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            gestionEstudiante.Registrar(estudiante);
                            Console.WriteLine("Estudiante registrado correctamente");
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex);

                        }

                        Console.ReadKey();
                        Console.ResetColor();
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
