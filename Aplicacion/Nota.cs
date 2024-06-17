using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos
{
    internal class Nota
    {
        public int id_estudiante = 0;
        public int id_asignatura = 0;
        public float nota1 = 0;
        public float nota2 = 0;
        public float nota3 = 0;
        public float nota4 = 0;
        public float promedio = 0;
        public bool aprobado = false;

        public static Nota notas= new Nota();
        public static void GestionNota()
        {
            Console.Clear();
            Console.WriteLine("Gestion de Notas por clase");
            Console.WriteLine("1)Registrar");
            Console.WriteLine("2)Actualizar");
            Console.WriteLine("3)Mostrar notas por estudiante");
            Console.WriteLine("4)Mostrar notas por clase");
            Console.WriteLine("Seleccione una opcion:");
            int numeroOpcion = Convert.ToInt32(Console.ReadLine());
            switch (numeroOpcion)
            {
                case 1:
                    Console.WriteLine("Registrar Nota");
                    notas.Registrar();
                    break;
                case 2:
                    Console.WriteLine("Actualizar Nota");
                    notas.Actualizar();
                    break;
                case 3:
                    Console.WriteLine("Mostrar notas por estudiante");
                    notas.MostrarNotasGeneralesPorEstudiante();
                    break;
                case 4:
                    Console.WriteLine("Mostrar notas por clase");
                    notas.MostrarNotasPorClase();
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }
        public void Registrar()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Registrar Nota");
                Console.WriteLine("==================================");
                Console.WriteLine("Seleccione una estudiante:");
                ListarEstudiante();
                Console.WriteLine("Que asignatura desea registrar la nota?");
                ListarAsignatura();
                Console.WriteLine("De que parcial desea agregar nota (1,2,3,4)?");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese la nota del primer parcial:");
                        notas.nota1 = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Ingrese la nota del segundo parcial:");
                        notas.nota2 = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Ingrese la nota del tercer parcial:");
                        notas.nota3 = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Ingrese la nota del cuarto parcial:");
                        notas.nota4 = Convert.ToSingle(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                
                Console.WriteLine("¿Desea actualizar otro campo? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s") continuar = false;

            } while (continuar);
            CalcularPromedio();
        }
        public void Actualizar()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Actualizar Nota");
                Console.WriteLine("==================================");
                Console.WriteLine("Seleccione una estudiante:");
                ListarEstudiante();
                Console.WriteLine("Que asignatura desea registrar la nota?");
                ListarAsignatura();
                Console.WriteLine("De que parcial desea corregir o modificar su nota (1,2,3,4)?");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        Console.WriteLine("Nota del primer parcial actual: "+nota1);
                        Console.WriteLine("Ingrese la nota del primer parcial:");
                        notas.nota1 = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Nota del segundo parcial actual: "+nota2);
                        Console.WriteLine("Ingrese la nota del segundo parcial:");
                        notas.nota2 = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Nota del tercer parcial actual: "+nota3);
                        Console.WriteLine("Ingrese la nota del tercer parcial:");
                        notas.nota3 = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 4:
                        Console.Write("Nota del cuarto parcial actual: "+nota4);
                        Console.WriteLine("Ingrese la nota del cuarto parcial:");
                        notas.nota4 = Convert.ToSingle(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                
                Console.WriteLine("¿Desea actualizar otro campo? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s") continuar = false;

            } while (continuar);
            CalcularPromedio();
        }
        public void MostrarNotasGeneralesPorEstudiante()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Mostrar notas por estudiante");
                Console.WriteLine("==================================");
                Console.WriteLine("Seleccione un estudiante:");
                ListarEstudiante();
                Console.WriteLine("Promedio de notas por parcial de todas sus clases:");
                Console.WriteLine("==================================");
                Console.WriteLine("Notas asignatura 1");
                Console.Write("\tNota 1: "+nota1);
                Console.WriteLine("\tNota 2: "+nota2);
                Console.Write("\tNota 3: "+nota3);
                Console.WriteLine("\tNota 4: "+nota4);
                Console.Write("\tPromedio: "+promedio);
                Console.WriteLine("\tAprobado: "+aprobado);
                Console.WriteLine("==================================");
                Console.WriteLine("Notas asignatura 2");
                Console.Write("\tNota 1: " + nota1);
                Console.WriteLine("\tNota 2: " + nota2);
                Console.Write("\tNota 3: " + nota3);
                Console.WriteLine("\tNota 4: " + nota4);
                Console.Write("\tPromedio: " + promedio);
                Console.WriteLine("\tAprobado: " + aprobado);
                Console.WriteLine("==================================");
                Console.WriteLine("Notas asignatura 3");
                Console.Write("\tNota 1: " + nota1);
                Console.WriteLine("\tNota 2: " + nota2);
                Console.Write("\tNota 3: " + nota3);
                Console.WriteLine("\tNota 4: " + nota4);
                Console.Write("\tPromedio: " + promedio);
                Console.WriteLine("\tAprobado: " + aprobado);
                Console.WriteLine("==================================");

                Console.WriteLine("¿Desea ver otro estudiante? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s") continuar = false;

            } while (continuar);
        }
        public void MostrarNotasPorClase()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Mostrar notas por clase");
                Console.WriteLine("==================================");
                Console.WriteLine("Seleccione una asignatura:");
                ListarAsignatura();
                Console.WriteLine("Promedio de notas por parcial de todas sus clases:");
                Console.WriteLine("Notas estudiante 1");
                Console.Write("\tNota 1: " + nota1);
                Console.WriteLine("\tNota 2: " + nota2);
                Console.Write("\tNota 3: " + nota3);
                Console.WriteLine("\tNota 4: " + nota4);
                Console.Write("\tPromedio: " + promedio);
                Console.WriteLine("\tAprobado: " + aprobado);
                Console.WriteLine("==================================");
                Console.WriteLine("Notas estudiante 2");
                Console.Write("\tNota 1: " + nota1);
                Console.WriteLine("\tNota 2: " + nota2);
                Console.Write("\tNota 3: " + nota3);
                Console.WriteLine("\tNota 4: " + nota4);
                Console.Write("\tPromedio: " + promedio);
                Console.WriteLine("\tAprobado: " + aprobado);
                Console.WriteLine("==================================");
                Console.WriteLine("Notas estudiante 3");
                Console.Write("\tNota 1: " + nota1);
                Console.WriteLine("\tNota 2: " + nota2);
                Console.Write("\tNota 3: " + nota3);
                Console.WriteLine("\tNota 4: " + nota4);
                Console.Write("\tPromedio: " + promedio);
                Console.WriteLine("\tAprobado: " + aprobado);
                Console.WriteLine("==================================");


                Console.WriteLine("¿Desea ver otra asignatura? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s") continuar = false;

            } while (continuar);
        }
        public void ListarEstudiante()
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
        public void ListarAsignatura()
        {
            Console.Clear();
            Console.WriteLine("Listado de Asignaturas");
            Console.WriteLine("1)Asignatura 1");
            Console.WriteLine("2)Asignatura 2");
            Console.WriteLine("3)Asignatura 3");
            Console.WriteLine("Seleccione una asignatura:");
            int numeroOpcion = Convert.ToInt32(Console.ReadLine());
            switch (numeroOpcion)
            {
                case 1:
                    Console.WriteLine("Asignatura 1");
                    break;
                case 2:
                    Console.WriteLine("Asignatura 2");
                    break;
                case 3:
                    Console.WriteLine("Asignatura 3");
                    break;
                default:
                    Console.WriteLine("Asignatura no valida");
                    break;
            }
        }
        public void CalcularPromedio()
        {
            promedio = (nota1 + nota2 + nota3 + nota4) / 4;
            if (promedio >= 65 && promedio<=100) aprobado = true;
        }
    }
}
