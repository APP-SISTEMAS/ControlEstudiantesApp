using Aplicacion.Gestores;
using Aplicacion.Models;
using System;
using System.Collections.Generic;

namespace Aplicacion.Interfaz
{
    public class PantallaGestionEstudiante
    {
        public static GestionEstudiante gestionEstudiante = new GestionEstudiante();
        public static Estudiante estudiante = new Estudiante();
        public static void MenuEstudiante()
        {
            PantallaGestionEstudiante pantallaGestionEstudiante = new PantallaGestionEstudiante();
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Gestion de Estudiante");
                Console.WriteLine("1)Registrar Estudiante");
                Console.WriteLine("2)Modificar Estudiante");
                Console.WriteLine("3)Gestion Habilitacion-Deshabilitacion Estudiante");
                Console.WriteLine("4)Mostrar Informacion Estudiante");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Registro de Estudiante");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese el nombre del estudiante:");
                            estudiante.Nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del estudiante:");
                            estudiante.Apellido = Console.ReadLine();
                            Console.WriteLine("Ingrese la fecha de nacimiento del estudiante:");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Sugerencia: Ingrese la fecha en el formato 'dd/mm/aaaa'\nEjemplo: '31/12/1987'");
                            Console.ForegroundColor = ConsoleColor.Green;
                            estudiante.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Ingrese la identificacion del estudiante:");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Sugerencia: Ingrese el numero de identificacion con guiones en el formato 'xxxx-xxxx-xxxxx'");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string comprobacionIdentificacion = Console.ReadLine();
                            var result = gestionEstudiante.ValidarIdentificacion(comprobacionIdentificacion);
                            if (result == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Identificacion no valida, ya se encuentra registrada.");
                                Console.ReadKey();
                                break;
                            }
                            estudiante.Identificacion = comprobacionIdentificacion;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese el genero del estudiante:");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("M = Masculino, F = Femenino");
                            Console.ForegroundColor = ConsoleColor.Green;
                            estudiante.Genero = Convert.ToChar(Console.ReadLine().ToUpper());
                            estudiante.Activo = true;
                            Console.WriteLine("Ingrese el telefono del estudiante:");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Sugerencia: Ingrese el telefono incluyendo el numero de area, en el siguiente formato '504-xxxx-xxxx'");
                            Console.ForegroundColor = ConsoleColor.Green;
                            estudiante.Telefono = Console.ReadLine();
                            Console.WriteLine("Ingrese el departamento del estudiante:");
                            MostrarDepartamentos();
                            Console.ForegroundColor = ConsoleColor.Green;
                            estudiante.Departamento = Console.ReadLine();
                            Console.WriteLine("Ingrese el municipio del estudiante:");
                            MostrarMunicipios(estudiante.Departamento);
                            Console.ForegroundColor = ConsoleColor.Green;
                            estudiante.Municipio = Console.ReadLine();
                            Console.WriteLine("Ingrese la direccion del estudiante:");
                            estudiante.Direccion = Console.ReadLine();
                            Console.WriteLine("Ingrese el correo del estudiante:");
                            estudiante.Correo = Console.ReadLine();
                            Console.WriteLine("Ingrese el tipo de sangre1 del estudiante:");
                            MostrarListaTipoSangre();
                            Console.ForegroundColor = ConsoleColor.Green;
                            estudiante.TipoSangre = Console.ReadLine();
                            Console.WriteLine("Ingrese el tutor del estudiante:");
                            estudiante.Tutor = Console.ReadLine();

                            Console.Clear();
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
                            Console.WriteLine("Estudiante registrado correctamente");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex);
                            Console.ReadKey();
                        }
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case 2:
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("ActualizarEstudiante Estudiante");
                            pantallaGestionEstudiante.ListarEstudiantes();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Seleccione el ID del estudiante1 a actualizar:");
                            int idEstudianteActualizar = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();

                            Estudiante estudianteActualizar = MostrarInformacionEstudiante(idEstudianteActualizar);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("¿Desea actualizar la información de este estudiante1?");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("1 = Si, 0 = No");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string respuesta = Console.ReadLine().ToLower();
                            Console.Clear();
                            if (respuesta != "1") break;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Nombre registrado: " + estudianteActualizar.Nombre);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización del nombre (dejar en blanco para mantener):");
                            string nuevoNombre = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoNombre)) estudianteActualizar.Nombre = nuevoNombre;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Apellido registrado: " + estudianteActualizar.Apellido);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización del apellido (dejar en blanco para mantener):");
                            string nuevoApellido = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoApellido)) estudianteActualizar.Apellido = nuevoApellido;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Fecha de Nacimiento registrada: " + estudianteActualizar.FechaNacimiento);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización de la fecha de nacimiento (dejar en blanco para mantener):");
                            string nuevaFechaNacimiento = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevaFechaNacimiento)) estudianteActualizar.FechaNacimiento = DateTime.Parse(nuevaFechaNacimiento);

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Identificación registrada: " + estudianteActualizar.Identificacion);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización de la identificación (dejar en blanco para mantener):");
                            string nuevaIdentificacion = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevaIdentificacion)) estudianteActualizar.Identificacion = nuevaIdentificacion;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Género registrado: " + estudianteActualizar.Genero);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización del género \n(M = Masculino, F = Femenino, dejar en blanco para mantener):");
                            string nuevoGenero = Console.ReadLine().ToUpper();
                            if (!string.IsNullOrEmpty(nuevoGenero)) estudianteActualizar.Genero = char.Parse(nuevoGenero);

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Teléfono registrado: " + estudianteActualizar.Telefono);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización del teléfono (dejar en blanco para mantener):");
                            string nuevoTelefono = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoTelefono)) estudianteActualizar.Telefono = nuevoTelefono;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Departamento registrado: " + estudianteActualizar.Departamento);
                            MostrarDepartamentos();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización del departamento (dejar en blanco para mantener):");
                            string nuevoDepartamento = Console.ReadLine();
                            if (string.IsNullOrEmpty(nuevoDepartamento)) estudianteActualizar.Departamento = ObtenerCodigoDepartamento(estudianteActualizar.Departamento).ToString();
                            if (!string.IsNullOrEmpty(nuevoDepartamento)) estudianteActualizar.Departamento = nuevoDepartamento;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Municipio registrado: " + estudianteActualizar.Municipio);
                            MostrarMunicipios(estudianteActualizar.Departamento);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización del municipio (dejar en blanco para mantener):");
                            string nuevoMunicipio = Console.ReadLine();
                            if (string.IsNullOrEmpty(nuevoMunicipio)) estudianteActualizar.Municipio = ObtenerCodigoMunicipio(estudianteActualizar.Municipio,estudianteActualizar.Departamento).ToString();
                            if (!string.IsNullOrEmpty(nuevoMunicipio)) estudianteActualizar.Municipio = nuevoMunicipio;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Dirección registrada: " + estudianteActualizar.Direccion);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización de la dirección (dejar en blanco para mantener):");
                            string nuevaDireccion = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevaDireccion)) estudianteActualizar.Direccion = nuevaDireccion;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Correo registrado: " + estudianteActualizar.Correo);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización del correo (dejar en blanco para mantener):");
                            string nuevoCorreo = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoCorreo)) estudianteActualizar.Correo = nuevoCorreo;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Tipo de Sangre registrado: " + estudianteActualizar.TipoSangre);
                            MostrarListaTipoSangre();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización del tipo de sangre1 (dejar en blanco para mantener):");
                            string nuevoTipoSangre = Console.ReadLine();
                            if (string.IsNullOrEmpty(nuevoTipoSangre)) estudianteActualizar.TipoSangre = ObtenerCodigoTipoSangre(estudianteActualizar.TipoSangre).ToString();
                            if (!string.IsNullOrEmpty(nuevoTipoSangre)) estudianteActualizar.TipoSangre = nuevoTipoSangre;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Tutor registrado: " + estudianteActualizar.Tutor);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ingrese la corrección o actualización del tutor (dejar en blanco para mantener):");
                            string nuevoTutor = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoTutor)) estudianteActualizar.Tutor = nuevoTutor;

                            Console.Clear();
                            gestionEstudiante.ActualizarEstudiante(estudianteActualizar, idEstudianteActualizar);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Estudiante actualizado correctamente.");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex);
                            Console.ReadKey();
                        }
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case 3:
                        PantallaGestionHabilitacionEstudiante.MenuHabilitacionEstudiante();
                        break;
                    case 4:
                        Console.Clear();
                        pantallaGestionEstudiante.ListarEstudiantes();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Seleccione el estudiante1 del que desea ver la información:");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Nota: Seleccione el ID");
                        int idEstudiante = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        MostrarInformacionEstudiante(idEstudiante);
                        Console.ReadKey();
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.ResetColor();
                Console.Clear();
            } while (continuar);
            Console.Clear();
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
        public static int ObtenerCodigoMunicipio(string municipio,string departamento)
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