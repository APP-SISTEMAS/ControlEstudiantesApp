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
                            var result = gestionEstudiante.ValidarIdentificacion(Console.ReadLine());
                            if (result == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Identificacion no valida, ya se encuentra registrada.");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine("Ingrese el genero del estudiante:");
                            Console.WriteLine("M = Masculino, F = Femenino");
                            estudiante.Genero = Convert.ToChar(Console.ReadLine());
                            estudiante.Activo = true;
                            Console.WriteLine("Ingrese el telefono del estudiante:");
                            estudiante.Telefono = Console.ReadLine();
                            Console.WriteLine("Ingrese el departamento del estudiante:");
                            gestionEstudiante.ObtenerListaDepartamentos();
                            Console.ForegroundColor = ConsoleColor.Green;
                            estudiante.Departamento = Console.ReadLine();
                            Console.WriteLine("Ingrese el municipio del estudiante:");
                            gestionEstudiante.ObtenerListaMunicipios(estudiante.Departamento);
                            Console.ForegroundColor = ConsoleColor.Green;
                            estudiante.Municipio = Console.ReadLine();
                            Console.WriteLine("Ingrese la direccion del estudiante:");
                            estudiante.Direccion = Console.ReadLine();
                            Console.WriteLine("Ingrese el correo del estudiante:");
                            estudiante.Correo = Console.ReadLine();
                            Console.WriteLine("Ingrese el tipo de sangre del estudiante:");
                            gestionEstudiante.ObtenerListaTipoSangre();
                            Console.ForegroundColor = ConsoleColor.Green;
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
                            Console.ReadKey();
                        }

                        Console.ReadKey();
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    case 2:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine("Actualizar Estudiante");
                            gestionEstudiante.ObtenerListaEstudiantes();
                            Console.WriteLine("Seleccione el ID del estudiante a actualizar:");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Estudiante estudianteActualizar = gestionEstudiante.ObtenerInformacionEstudiante(id);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("¿Desea actualizar la información de este estudiante? (s/n)");
                            string respuesta = Console.ReadLine().ToLower();
                            if (respuesta != "s")
                            {
                                Console.WriteLine("Actualización cancelada.");
                                break;
                            }

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Nombre registrado: " + estudianteActualizar.Nombre);
                            Console.WriteLine("Ingrese la corrección o actualización del nombre (dejar en blanco para mantener):");
                            string nuevoNombre = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoNombre)) estudianteActualizar.Nombre = nuevoNombre;

                            Console.WriteLine("Apellido registrado: " + estudianteActualizar.Apellido);
                            Console.WriteLine("Ingrese la corrección o actualización del apellido (dejar en blanco para mantener):");
                            string nuevoApellido = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoApellido)) estudianteActualizar.Apellido = nuevoApellido;

                            Console.WriteLine("Fecha de Nacimiento registrada: " + estudianteActualizar.FechaNacimiento);
                            Console.WriteLine("Ingrese la corrección o actualización de la fecha de nacimiento (dejar en blanco para mantener):");
                            string nuevaFechaNacimiento = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevaFechaNacimiento)) estudianteActualizar.FechaNacimiento = DateTime.Parse(nuevaFechaNacimiento);

                            Console.WriteLine("Identificación registrada: " + estudianteActualizar.Identificacion);
                            Console.WriteLine("Ingrese la corrección o actualización de la identificación (dejar en blanco para mantener):");
                            string nuevaIdentificacion = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevaIdentificacion)) estudianteActualizar.Identificacion = nuevaIdentificacion;

                            Console.WriteLine("Género registrado: " + estudianteActualizar.Genero);
                            Console.WriteLine("Ingrese la corrección o actualización del género \n(M = Masculino, F = Femenino, dejar en blanco para mantener):");
                            string nuevoGenero = Console.ReadLine().ToUpper();
                            if (!string.IsNullOrEmpty(nuevoGenero)) estudianteActualizar.Genero = char.Parse(nuevoGenero);

                            Console.WriteLine("Teléfono registrado: " + estudianteActualizar.Telefono);
                            Console.WriteLine("Ingrese la corrección o actualización del teléfono (dejar en blanco para mantener):");
                            string nuevoTelefono = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoTelefono)) estudianteActualizar.Telefono = nuevoTelefono;

                            Console.WriteLine("Departamento registrado: " + estudianteActualizar.Departamento);
                            gestionEstudiante.ObtenerListaDepartamentos();
                            Console.WriteLine("Ingrese la corrección o actualización del departamento (dejar en blanco para mantener):");
                            string nuevoDepartamento = Console.ReadLine();
                            if (string.IsNullOrEmpty(nuevoDepartamento)) estudianteActualizar.Departamento = ObtenerCodigoDepartamento(estudianteActualizar.Departamento).ToString();
                            if (!string.IsNullOrEmpty(nuevoDepartamento)) estudianteActualizar.Departamento = nuevoDepartamento;

                            Console.WriteLine("Municipio registrado: " + estudianteActualizar.Municipio);
                            gestionEstudiante.ObtenerListaMunicipios(estudianteActualizar.Departamento);
                            Console.WriteLine("Ingrese la corrección o actualización del municipio (dejar en blanco para mantener):");
                            string nuevoMunicipio = Console.ReadLine();
                            if (string.IsNullOrEmpty(nuevoMunicipio)) estudianteActualizar.Municipio = ObtenerCodigoMunicipio(estudianteActualizar.Municipio).ToString();
                            if (!string.IsNullOrEmpty(nuevoMunicipio)) estudianteActualizar.Municipio = nuevoMunicipio;

                            Console.WriteLine("Dirección registrada: " + estudianteActualizar.Direccion);
                            Console.WriteLine("Ingrese la corrección o actualización de la dirección (dejar en blanco para mantener):");
                            string nuevaDireccion = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevaDireccion)) estudianteActualizar.Direccion = nuevaDireccion;

                            Console.WriteLine("Correo registrado: " + estudianteActualizar.Correo);
                            Console.WriteLine("Ingrese la corrección o actualización del correo (dejar en blanco para mantener):");
                            string nuevoCorreo = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoCorreo)) estudianteActualizar.Correo = nuevoCorreo;

                            Console.WriteLine("Tipo de Sangre registrado: " + estudianteActualizar.TipoSangre);
                            gestionEstudiante.ObtenerListaTipoSangre();
                            Console.WriteLine("Ingrese la corrección o actualización del tipo de sangre (dejar en blanco para mantener):");
                            string nuevoTipoSangre = Console.ReadLine();
                            if (string.IsNullOrEmpty(nuevoTipoSangre)) estudianteActualizar.TipoSangre = ObtenerCodigoTipoSangre(estudianteActualizar.TipoSangre).ToString();
                            if (!string.IsNullOrEmpty(nuevoTipoSangre)) estudianteActualizar.TipoSangre = nuevoTipoSangre;

                            Console.WriteLine("Tutor registrado: " + estudianteActualizar.Tutor);
                            Console.WriteLine("Ingrese la corrección o actualización del tutor (dejar en blanco para mantener):");
                            string nuevoTutor = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoTutor)) estudianteActualizar.Tutor = nuevoTutor;

                            gestionEstudiante.Actualizar(estudianteActualizar, id);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Estudiante actualizado correctamente.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex);
                            Console.ReadKey();
                        }
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
        public static int ObtenerCodigoDepartamento(string dep)
        {
            switch (dep)
            {
                case "Atlántida":
                    return 1;
                case "Choluteca":
                    return 2;
                case "Colón":
                    return 3;
                case "Comayagua":
                    return 4;
                case "Copán":
                    return 5;
                case "Cortés":
                    return 6;
                case "El Paraíso":
                    return 7;
                case "Francisco Morazán":
                    return 8;
                case "Gracias a Dios":
                    return 9;
                case "Intibucá":
                    return 10;
                case "Islas de la Bahía":
                    return 11;
                case "La Paz":
                    return 12;
                case "Lempira":
                    return 13;
                case "Ocotepeque":
                    return 14;
                case "Olancho":
                    return 15;
                case "Santa Bárbara":
                    return 16;
                case "Valle":
                    return 17;
                case "Yoro":
                    return 18;
                default:
                    return 0;
            }
        }
        public static int ObtenerCodigoTipoSangre(string tipo)
        {
            switch (tipo)
            {
                case "A+":
                    return 1;
                case "A-":
                    return 2;
                case "B+":
                    return 3;
                case "B-":
                    return 4;
                case "AB+":
                    return 5;
                case "AB-":
                    return 6;
                case "O+":
                    return 7;
                case "O-":
                    return 8;
                default:
                    return 0;
            }
        }
        public static int ObtenerCodigoMunicipio(string muni)
        {
            switch (muni)
            {
                case "La Ceiba":
                    return 1;
                case "Tela":
                    return 2;
                case "Choluteca":
                    return 3;
                case "San Marcos de Colón":
                    return 4;
                case "Trujillo":
                    return 5;
                case "Tocoa":
                    return 6;
                case "Comayagua":
                    return 7;
                case "Siguatepeque":
                    return 8;
                case "Santa Rosa de Copán":
                    return 9;
                case "La Entrada":
                    return 10;
                case "San Pedro Sula":
                    return 11;
                case "Puerto Cortés":
                    return 12;
                case "Danlí":
                    return 13;
                case "Yuscarán":
                    return 14;
                case "Tegucigalpa":
                    return 15;
                case "Valle de Ángeles":
                    return 16;
                case "Puerto Lempira":
                    return 17;
                case "La Esperanza":
                    return 18;
                case "Roatán":
                    return 19;
                case "La Paz":
                    return 20;
                case "Gracias":
                    return 21;
                case "Nueva Ocotepeque":
                    return 22;
                case "Juticalpa":
                    return 23;
                case "Santa Bárbara":
                    return 24;
                case "Nacaome":
                    return 25;
                case "Yoro":
                    return 26;
                default:
                    return 0; // Si el municipio no se encuentra en la lista, retornar 0 o algún valor que indique no encontrado
            }
        }
    }
}
