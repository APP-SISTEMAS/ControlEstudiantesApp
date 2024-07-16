 using Aplicacion.Gestores;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Aplicacion.Interfaz
{
    public class PantallaGestionEstudiante
    {
        public static GestionEstudiante gestionEstudiante = new GestionEstudiante();
        public static Estudiante estudiante = new Estudiante();
        public static PantallaGestionEstudiante pantallaGestionEstudiante = new PantallaGestionEstudiante();
        public static void MenuEstudiante()
        {
            try
            {
                bool continuar = true;
                var result = false;
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\tPantalla de Gestion de Estudiante");
                    Console.WriteLine("===================================================");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n1)Registrar Estudiante");
                    Console.WriteLine("2)Modificar Estudiante");
                    Console.WriteLine("3)Pantala de Gestion Habilitacion y Deshabilitacion de Estudiantes");
                    Console.WriteLine("4)Mostrar Informacion de Estudiante");
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
                                Console.WriteLine("Registro de Estudiante");
                                Console.WriteLine("============================");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nIngrese el nombre del estudiante:");
                                estudiante.Nombre = Console.ReadLine();
                                Console.WriteLine("\nIngrese el apellido del estudiante:");
                                estudiante.Apellido = Console.ReadLine();
                                Console.WriteLine("\nIngrese la fecha de nacimiento del estudiante:");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Sugerencia: Ingrese la fecha en el formato 'dd/mm/aaaa'\nEjemplo: '31/12/1987'");
                                Console.ForegroundColor = ConsoleColor.Green;
                                estudiante.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("\nIngrese la identificacion del estudiante:");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;                                
                                Console.WriteLine("Sugerencia: Ingrese el numero de identificacion con guiones en el formato 'xxxx-xxxx-xxxxx'");
                                Console.ForegroundColor = ConsoleColor.Green;
                                string comprobacionIdentificacion = Console.ReadLine();
                                if (!Regex.IsMatch(comprobacionIdentificacion, @"^\d{4}-\d{4}-\d{5}$"))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Identificacion no valida, debe tener el formato 'xxxx-xxxx-xxxxx'");
                                    Console.ReadKey();
                                    break;
                                }
                                result = gestionEstudiante.ValidarIdentificacion(comprobacionIdentificacion);
                                if (result == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Identificacion no valida, ya se encuentra registrada.");
                                    Console.ReadKey();
                                    break;
                                }
                                estudiante.Identificacion = comprobacionIdentificacion;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nIngrese el genero del estudiante:");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("M = Masculino, F = Femenino");
                                Console.ForegroundColor = ConsoleColor.Green;
                                estudiante.Genero = Convert.ToChar(Console.ReadLine().ToUpper());
                                if (estudiante.Genero != 'M' && estudiante.Genero != 'F')
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Genero no valido, debe ser Masculino o Femenino");
                                    Console.ReadKey();
                                    break;
                                }
                                estudiante.Activo = true;
                                Console.WriteLine("\nIngrese el telefono del estudiante:");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Sugerencia: Ingrese el telefono incluyendo el numero de area, en el siguiente formato Ejemplo: '504-9999-9999'");
                                Console.WriteLine("PRESIONE ENTER SI NO DESEA AGREGAR UN TELEFONO");
                                Console.ForegroundColor = ConsoleColor.Green;
                                estudiante.Telefono = Console.ReadLine();
                                Console.WriteLine("\nIngrese el departamento del estudiante:");
                                MostrarDepartamentos();
                                Console.ForegroundColor = ConsoleColor.Green;
                                estudiante.Departamento = Console.ReadLine();
                                result=gestionEstudiante.ExisteIdDepartamento(estudiante.Departamento);
                                if (result == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El departamento seleccionado no existe");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nIngrese el municipio del estudiante:");
                                MostrarMunicipios(estudiante.Departamento);
                                Console.ForegroundColor = ConsoleColor.Green;
                                estudiante.Municipio = Console.ReadLine();
                                result = gestionEstudiante.ExisteIdMunicipio(estudiante.Municipio);
                                if (result == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El municipio seleccionado no existe");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nIngrese la direccion del estudiante:");
                                estudiante.Direccion = Console.ReadLine();
                                Console.WriteLine("\nIngrese el correo del estudiante:");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("PRESIONE ENTER SI NO DESEA AGREGAR UN CORREO");
                                Console.ForegroundColor = ConsoleColor.Green;
                                estudiante.Correo = Console.ReadLine();
                                Console.WriteLine("\nIngrese el tipo de sangre del estudiante:");
                                MostrarListaTipoSangre();
                                Console.ForegroundColor = ConsoleColor.Green;
                                estudiante.TipoSangre = Console.ReadLine();
                                result = gestionEstudiante.ExisteIdTipoSangre(estudiante.TipoSangre);
                                if (result == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El tipo de sangre seleccionado no existe");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nIngrese el tutor del estudiante:");
                                estudiante.Tutor = Console.ReadLine();

                                var mensajeValidacion = gestionEstudiante.ValidarEstudiante(estudiante);
                                if (mensajeValidacion != "")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(mensajeValidacion);
                                    Console.ReadKey();
                                    break;
                                }
                                gestionEstudiante.RegistrarEstudiante(estudiante);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("\nEstudiante registrado correctamente");
                                Console.ReadKey();
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Datos Incorrectos. Asegurese de ingresar un valor valido");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: " + ex);
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
                                Console.WriteLine("\nActualizar Registro de Estudiante");
                                Console.WriteLine("=============================================");

                                pantallaGestionEstudiante.ListarEstudiantes();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Seleccione el ID del estudiante1 a actualizar:");
                                int idEstudianteActualizar = Convert.ToInt32(Console.ReadLine());
                                result = gestionEstudiante.ExisteIdEstudiante(idEstudianteActualizar);
                                if (result == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El estudiante seleccionado no existe");
                                    Console.ReadKey();
                                    break;
                                }

                                Estudiante estudianteActualizar = MostrarInformacionEstudiante(idEstudianteActualizar);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("¿Desea actualizar la información de este estudiante1?");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("1 = Si, 0 = No");
                                Console.ForegroundColor = ConsoleColor.Green;
                                string respuesta = Console.ReadLine().ToLower();
                                if (respuesta != "1") break;

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Nombre registrado: " + estudianteActualizar.Nombre);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización del nombre (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevoNombre = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevoNombre)) estudianteActualizar.Nombre = nuevoNombre;

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nApellido registrado: " + estudianteActualizar.Apellido);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización del apellido (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevoApellido = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevoApellido)) estudianteActualizar.Apellido = nuevoApellido;

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nFecha de Nacimiento registrada: " + estudianteActualizar.FechaNacimiento);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización de la fecha de nacimiento (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevaFechaNacimiento = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevaFechaNacimiento)) estudianteActualizar.FechaNacimiento = DateTime.Parse(nuevaFechaNacimiento);

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nIdentificación registrada: " + estudianteActualizar.Identificacion);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización de la identificación (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevaIdentificacion = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevaIdentificacion)) estudianteActualizar.Identificacion = nuevaIdentificacion;
                                if (!Regex.IsMatch(estudianteActualizar.Identificacion, @"^\d{4}-\d{4}-\d{5}$"))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Identificacion no valida, debe tener el formato 'xxxx-xxxx-xxxxx'");
                                    Console.ReadKey();
                                    break;
                                }

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nGénero registrado: " + estudianteActualizar.Genero);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización del género \nM = Masculino, F = Femenino, (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevoGenero = Console.ReadLine().ToUpper();
                                if (!string.IsNullOrEmpty(nuevoGenero)) estudianteActualizar.Genero = char.Parse(nuevoGenero);
                                if (estudianteActualizar.Genero != 'M' && estudianteActualizar.Genero != 'F')
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Genero no valido, debe ser Masculino o Femenino");
                                    Console.ReadKey();
                                    break;
                                }

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nTeléfono registrado: " + estudianteActualizar.Telefono);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización del teléfono (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevoTelefono = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevoTelefono)) estudianteActualizar.Telefono = nuevoTelefono;

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nDepartamento registrado: " + estudianteActualizar.Departamento);
                                MostrarDepartamentos();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización del departamento (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevoDepartamento = Console.ReadLine();                                
                                if (string.IsNullOrEmpty(nuevoDepartamento)) estudianteActualizar.Departamento = ObtenerCodigoDepartamento(estudianteActualizar.Departamento).ToString();
                                if (!string.IsNullOrEmpty(nuevoDepartamento)) estudianteActualizar.Departamento = nuevoDepartamento;
                                result = gestionEstudiante.ExisteIdDepartamento(estudianteActualizar.Departamento);
                                if (result == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El departamento seleccionado no existe");
                                    Console.ReadKey();
                                    break;
                                }

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nMunicipio registrado: " + estudianteActualizar.Municipio);
                                MostrarMunicipios(estudianteActualizar.Departamento);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización del municipio (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevoMunicipio = Console.ReadLine();                                
                                if (string.IsNullOrEmpty(nuevoMunicipio)) estudianteActualizar.Municipio = ObtenerCodigoMunicipio(estudianteActualizar.Municipio, estudianteActualizar.Departamento).ToString();
                                if (!string.IsNullOrEmpty(nuevoMunicipio)) estudianteActualizar.Municipio = nuevoMunicipio;
                                result = gestionEstudiante.ExisteIdMunicipio(estudianteActualizar.Municipio);
                                if (result == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El municipio seleccionado no existe");
                                    Console.ReadKey();
                                    break;
                                }

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nDirección registrada: " + estudianteActualizar.Direccion);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización de la dirección (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevaDireccion = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevaDireccion)) estudianteActualizar.Direccion = nuevaDireccion;

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nCorreo registrado: " + estudianteActualizar.Correo);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización del correo (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevoCorreo = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevoCorreo)) estudianteActualizar.Correo = nuevoCorreo;

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nTipo de Sangre registrado: " + estudianteActualizar.TipoSangre);
                                MostrarListaTipoSangre();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización del tipo de sangre1 (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevoTipoSangre = Console.ReadLine();
                                if (string.IsNullOrEmpty(nuevoTipoSangre)) estudianteActualizar.TipoSangre = ObtenerCodigoTipoSangre(estudianteActualizar.TipoSangre).ToString();
                                if (!string.IsNullOrEmpty(nuevoTipoSangre)) estudianteActualizar.TipoSangre = nuevoTipoSangre;
                                result = gestionEstudiante.ExisteIdTipoSangre(estudianteActualizar.TipoSangre);
                                if (result == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El tipo de sangre seleccionado no existe");
                                    Console.ReadKey();
                                    break;
                                }

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nTutor registrado: " + estudianteActualizar.Tutor);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ingrese la corrección o actualización del tutor (PRESIONE ENTER PARA NO MODIFICAR):");
                                string nuevoTutor = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevoTutor)) estudianteActualizar.Tutor = nuevoTutor;
                                gestionEstudiante.ActualizarEstudiante(estudianteActualizar, idEstudianteActualizar);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Estudiante actualizado correctamente.");
                                Console.ReadKey();
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Datos Incorrectos. Asegurese de ingresar un valor valido");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: " + ex);
                                Console.ReadKey();
                            }
                            finally
                            {
                                Console.ResetColor();
                                Console.Clear();
                            }
                            break;
                        case 3:
                            PantallaGestionHabilitacionEstudiante.MenuHabilitacionEstudiante();
                            break;
                        case 4:
                            try
                            {
                                Console.Clear();
                                pantallaGestionEstudiante.ListarEstudiantes();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Seleccione el estudiante1 del que desea ver la información:");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Nota: Seleccione el ID");
                                int idEstudiante = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                result = gestionEstudiante.ExisteIdEstudiante(idEstudiante);
                                if (result == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El ID seleccionado no existe");
                                    Console.ReadKey();
                                    break;
                                }
                                MostrarInformacionEstudiante(idEstudiante);
                                Console.ReadKey();
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Datos Incorrectos. Asegurese de ingresar un valor valido");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: " + ex);
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
                Console.WriteLine("Error: Datos Incorrectos. Asegurese de ingresar un valor valido");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
            }
            finally
            {
                Console.ResetColor();
                Console.Clear();
            }
        }
        public void ListarEstudiantes()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            listaEstudiantes = gestionEstudiante.ObtenerListaEstudiantes();

            Console.Write("--------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("\n  {0,-2} |                {1,-25} | {2,-10} | {3,-15} |", "Id", "Estudiante", "Natalicio", "Identificacion"));
            Console.WriteLine("--------------------------------------------------------------------------------");

            foreach (var estudiante1 in listaEstudiantes)
            {
                Console.WriteLine(string.Format(" {0,-3} | {1,-40} | {2,-10} | {3,-15} |", estudiante1.Id, estudiante1.Nombre + " " + estudiante1.Apellido, estudiante1.FechaNacimiento.ToString().Remove(10), estudiante1.Identificacion));
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.ResetColor();
        }
        public static void MostrarDepartamentos()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            List<Departamento> departamentos = new List<Departamento>();
            departamentos = gestionEstudiante.ObtenerListaDepartamentos();

            Console.Write("---------------------------------");
            Console.WriteLine(string.Format("\n {0,-2} | {1,-25} |", "Id", "Departamento"));
            Console.WriteLine("---------------------------------");

            foreach (var departamento1 in departamentos)
            {
                Console.WriteLine(string.Format("{0,-3} | {1,-25} |", departamento1.Id, departamento1.DepartamentoNombre));
            }
            Console.WriteLine("---------------------------------");
            Console.ResetColor();
        }
        public static void MostrarMunicipios(string idDepartamento)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            List<Municipio> municipios = new List<Municipio>();
            municipios = gestionEstudiante.ObtenerListaMunicipios(idDepartamento);

            Console.Write("---------------------------------");
            Console.WriteLine(string.Format("\n {0,-2} | {1,-25} |", "Id", "Municipio"));
            Console.WriteLine("---------------------------------");

            foreach (var municipio1 in municipios)
            {
                Console.WriteLine(string.Format("{0,-3} | {1,-25} |", municipio1.Id, municipio1.MunicipioNombre));
            }
            Console.WriteLine("---------------------------------");
            Console.ResetColor();
        }
        public static Estudiante MostrarInformacionEstudiante(int id)
        {
            Estudiante estudiante2 = new Estudiante();
            estudiante2 = gestionEstudiante.ObtenerInformacionEstudiante(id);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\tFicha Estudiantil");
            Console.WriteLine("----------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Id: " + estudiante2.Id);
            Console.WriteLine("Nombre: " + estudiante2.Nombre);
            Console.WriteLine("Apellido: " + estudiante2.Apellido);
            Console.WriteLine("Fecha de Nacimiento: " + estudiante2.FechaNacimiento.ToString().Remove(10));
            Console.WriteLine("Identificacion: " + estudiante2.Identificacion);
            Console.WriteLine("Genero: " + estudiante2.Genero);
            Console.WriteLine("Activo: " + (estudiante2.Activo ? "Si" : "No"));
            Console.WriteLine("Telefono: " + estudiante2.Telefono);
            Console.WriteLine("Departamento: " + estudiante2.Departamento);
            Console.WriteLine("Municipio: " + estudiante2.Municipio);
            Console.WriteLine("Direccion: " + estudiante2.Direccion);
            Console.WriteLine("Correo: " + estudiante2.Correo);
            Console.WriteLine("Tipo de Sangre: " + estudiante2.TipoSangre);
            Console.WriteLine("Tutor: " + estudiante2.Tutor);
            return estudiante2;
        }
        public static void MostrarListaTipoSangre()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            List<TipoSangre> tipoSangres = new List<TipoSangre>();
            tipoSangres = gestionEstudiante.ObtenerListaTipoSangre();

            Console.Write("--------------------");
            Console.WriteLine(string.Format("\n{0,-3} | {1,-10}|", "Id", "Tipo Sangre"));
            Console.WriteLine("--------------------");

            foreach (var sangre1 in tipoSangres)
            {
                Console.WriteLine(string.Format("{0,-3} | {1,-10} |", sangre1.Id, sangre1.SangreNombre));
            }
            Console.WriteLine("--------------------");
            Console.ResetColor();
        }
        public static int ObtenerCodigoDepartamento(string dep)
        {
            gestionEstudiante = new GestionEstudiante();
            List<Departamento> departamentos = new List<Departamento>();
            departamentos = gestionEstudiante.ObtenerListaDepartamentos();
            foreach (var departamento1 in departamentos)
            {
                if (departamento1.DepartamentoNombre == dep)
                {
                    return departamento1.Id;
                }
            }
            return 0;
        }
        public static int ObtenerCodigoTipoSangre(string tipo)
        {
            gestionEstudiante = new GestionEstudiante();
            List<TipoSangre> tipoSangres = new List<TipoSangre>();
            tipoSangres = gestionEstudiante.ObtenerListaTipoSangre();
            foreach (var sangre1 in tipoSangres)
            {
                if (sangre1.SangreNombre == tipo)
                {
                    return sangre1.Id;
                }
            }
            return 0;
        }
        public static int ObtenerCodigoMunicipio(string municipio, string departamento)
        {
            gestionEstudiante = new GestionEstudiante();
            List<Municipio> municipios = new List<Municipio>();
            municipios = gestionEstudiante.ObtenerListaMunicipios(departamento);
            foreach (var municipio1 in municipios)
            {
                if (municipio1.MunicipioNombre == municipio)
                {
                    return municipio1.Id;
                }
            }
            return 0;
        }
    }
}