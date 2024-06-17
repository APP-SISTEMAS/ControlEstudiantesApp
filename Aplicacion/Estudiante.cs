using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos
{
    internal class Estudiante
    {
        public int id = 0;
        public string nombre = "";
        public string apellido = "";
        public DateTime? fechaNacimiento;
        public string identificacion = "";
        public char genero = 'M';
        public bool activo = false;
        public string telefono = "";
        public string departamento = "";
        public string municipio = "";
        public string direccion = "";
        public string correo = "";
        public string tipoSangre = "";
        public string tutor = "";

        public static Estudiante estudiante1 = new Estudiante();

        public static void GestionEstudiante()
        {
            Console.Clear();
            Console.WriteLine("Gestion de Estudiante");
            Console.WriteLine("1)Registrar");
            Console.WriteLine("2)Actualizar");
            Console.WriteLine("3)Deshabilitar");
            Console.WriteLine("4)Habilitar");
            Console.WriteLine("5)Mostrar Informacion Estudiante");
            Console.WriteLine("Seleccione una opcion:");
              int numeroOpcion = Convert.ToInt32(Console.ReadLine());
            switch (numeroOpcion)
            {
                case 1:
                    Console.WriteLine("Registrar Estudiante");
                    estudiante1.Registrar();
                    break;
                case 2:
                    Console.WriteLine("Actualizar Estudiante");
                    estudiante1.Actualizar();
                    break;
                case 3:
                    Console.WriteLine("Deshabilitar Estudiante");
                    estudiante1.Deshabilitar();
                    break;
                case 4:
                    Console.WriteLine("Habilitar Estudiante");
                    estudiante1.Habilitar();
                    break;
                case 5:
                    Console.WriteLine("Mostrar Informacion Estudiante");
                    estudiante1.MostrarInformacion();
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }


        public void Registrar()
        {
            Console.Clear();
            Console.WriteLine("Registro de Estudiante");
            Console.WriteLine("Ingrese el nombre del estudiante:");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del estudiante:");
            apellido = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de nacimiento del estudiante:");
            fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese la identificacion del estudiante:");
            identificacion = Console.ReadLine();
            Console.WriteLine("Ingrese el genero del estudiante:");
            genero = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Ingrese el telefono del estudiante:");
            telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el departamento del estudiante:");
            departamento = Console.ReadLine();
            Console.WriteLine("Ingrese el municipio del estudiante:");
            municipio = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion del estudiante:");
            direccion = Console.ReadLine();
            Console.WriteLine("Ingrese el correo del estudiante:");
            correo = Console.ReadLine();
            Console.WriteLine("Ingrese el tipo de sangre del estudiante:");
            tipoSangre = Console.ReadLine();
            Console.WriteLine("Ingrese el tutor del estudiante:");
            tutor = Console.ReadLine();
            Console.WriteLine("Estudiante registrado correctamente");
        }
        public void Actualizar()
        {
            Console.Clear();
            bool continuar = true;

            Console.WriteLine("Actualizar Estudiante");
            Console.WriteLine("¿Qué estudiante desea actualizar?");
            Listar();

            while (continuar)
            {
                Console.WriteLine("¿Qué campo desea actualizar?");
                Console.Write("1) Nombre \t\t2) Apellido" +
                              "\n3) Fecha de Nacimiento \t4) Identificación" +
                              "\n5) Género \t\t6) Teléfono" +
                              "\n7) Departamento \t8) Municipio" +
                              "\n9) Dirección \t\t10) Correo" +
                              "\n11) Tipo de Sangre \t12) Tutor" +
                              "\nSeleccione una opción: ");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());

                switch (numeroOpcion)
                {
                    case 1:
                        Console.WriteLine("Nombre registrado: "+nombre);
                        Console.WriteLine("Ingrese la correccion o actualizacion del nombre:");
                        nombre = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Apellido registrado: "+apellido);
                        Console.WriteLine("Ingrese la correccion o actualizacion del apellido:");
                        apellido = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Fecha de Nacimiento registrada: "+fechaNacimiento);
                        Console.WriteLine("Ingrese la correccion o actualizacion de la fecha de nacimiento:");
                        fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Identificación registrada: "+identificacion);
                        Console.WriteLine("Ingrese la correccion o actualizacion de la identificación:");
                        identificacion = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Género registrado: "+genero);
                        Console.WriteLine("Ingrese la correccion o actualizacion del género:");
                        genero = Convert.ToChar(Console.ReadLine());
                        break;
                    case 6:
                        Console.WriteLine("Telefono registrado: "+telefono);
                        Console.WriteLine("Ingrese la correccion o actualizacion del telefono:");
                        telefono = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Departamento registrado: "+departamento);
                        Console.WriteLine("Ingrese la correccion o actualizacion del departamento de residencia:");
                        departamento = Console.ReadLine();
                        break;
                    case 8:
                        Console.WriteLine("Municipio registrado: "+municipio);
                        Console.WriteLine("Ingrese la correccion o actualizacion del municipio de residencia:");
                        municipio = Console.ReadLine();
                        break;
                    case 9:
                        Console.WriteLine("Direccion registrada: "+direccion);
                        Console.WriteLine("Ingrese la correccion o actualizacion de la dirección de residencia:");
                        direccion = Console.ReadLine();
                        break;
                    case 10:
                        Console.WriteLine("Correo registrado: "+correo);
                        Console.WriteLine("Ingrese la correccion o actualizacion del correo:");
                        correo = Console.ReadLine();
                        break;
                    case 11:
                        Console.WriteLine("Tipo de Sangre registrado: "+tipoSangre);
                        Console.WriteLine("Ingrese la correccion del tipo de sangre:");
                        tipoSangre = Console.ReadLine();
                        break;
                    case 12:
                        Console.WriteLine("Tutor registrado: "+tutor);
                        Console.WriteLine("Ingrese la correccion o actualizacion del tutor a cargo del estudiante:");
                        tutor = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                Console.WriteLine("¿Desea actualizar otro campo? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s") continuar = false;
            }

            Console.WriteLine("Estudiante actualizado correctamente");
            Console.ReadKey();
        }

        public void Deshabilitar()
        {
            Console.Clear();
            Console.WriteLine("Deshabilitar Estudiante");
            Console.WriteLine("Que estudiante desea deshabilitar?");
            Listar();
            Console.WriteLine("Ingrese el motivo de la deshabilitacion:");
            string motivo = Console.ReadLine();
            activo = false;
            Console.WriteLine("Estudiante deshabilitado correctamente");
            Console.ReadKey();
        }
        public void Habilitar()
        {
            Console.Clear();
            Console.WriteLine("Habilitar Estudiante");
            Console.WriteLine("Que estudiante desea habilitar?");
            Listar();
            activo = true;
            Console.WriteLine("Estudiante habilitado correctamente");
            Console.ReadKey();
        }
        public void MostrarInformacion()
        {
            Console.Clear();
            Console.WriteLine("Seleccione el estudiante del que desea ver la información:");
            Listar();
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Ficha Estudiantil");
                Console.WriteLine("Nombre: " + nombre);
                Console.WriteLine("Apellido: " + apellido);
                Console.WriteLine("Fecha de Nacimiento: " + fechaNacimiento);
                Console.WriteLine("Identificacion: " + identificacion);
                Console.WriteLine("Genero: " + genero);
                Console.WriteLine("Telefono: " + telefono);
                Console.WriteLine("Departamento: " + departamento);
                Console.WriteLine("Municipio: " + municipio);
                Console.WriteLine("Direccion: " + direccion);
                Console.WriteLine("Correo: " + correo);
                Console.WriteLine("Tipo de Sangre: " + tipoSangre);
                Console.WriteLine("Tutor: " + tutor);
                Console.WriteLine("Activo: " + activo);
                Console.WriteLine("¿Desea ver la información de otro estudiante? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s") continuar = false;
                
            }
            
            Console.ReadKey();
        }
        public void Listar()
        {
            Console.Clear();
            Console.WriteLine("Listado de Estudiantes");
            Console.WriteLine("1)Estudiante 1");
            Console.WriteLine("2)Estudiante 2");
            Console.WriteLine("3)Estudiante 3");
            Console.WriteLine("Seleccione una estudiante:");
            int numeroOpcion = Convert.ToInt32(Console.ReadLine());
            switch (numeroOpcion)
            {
                case 1:
                    Console.WriteLine("Estudiante 1");
                    break;
                case 2:
                    Console.WriteLine("Estudiante 2");
                    break;
                case 3:
                    Console.WriteLine("Estudiante 3");
                    break;
                default:
                    Console.WriteLine("Estudiante no valido");
                    break;
            }
        }
    }
}
