using Aplicacion.Models;
using System.Collections.Generic;

namespace Aplicacion.Gestores
{
    public class GestionNotas
    {

        //public static Nota notas = new Nota();
        public static void MenuNota()
        {/*
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Gestion de Notas por clase");
                Console.WriteLine("1)Registrar");
                Console.WriteLine("2)Actualizar");
                Console.WriteLine("3)Mostrar notas por estudiante");
                Console.WriteLine("4)Mostrar notas por clase");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
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
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.ResetColor();
            } while (continuar);*/
        }

        public bool Registrar(bool aprobado)
        {/*
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
                Console.ForegroundColor = ConsoleColor.Green;
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

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¿Desea actualizar otro campo? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s") continuar = false;
                Console.ResetColor();

            } while (continuar);*/
            return aprobado = CalcularPromedio();
        }

        public bool ActualizarNota(bool aprobado)
        {/*
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
                Console.ForegroundColor = ConsoleColor.Green;
                switch (numeroOpcion)
                {
                    case 1:
                        Console.WriteLine("Nota del primer parcial actual: " + nota1);
                        Console.WriteLine("Ingrese la nota del primer parcial:");
                        notas.nota1 = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Nota del segundo parcial actual: " + nota2);
                        Console.WriteLine("Ingrese la nota del segundo parcial:");
                        notas.nota2 = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Nota del tercer parcial actual: " + nota3);
                        Console.WriteLine("Ingrese la nota del tercer parcial:");
                        notas.nota3 = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 4:
                        Console.Write("Nota del cuarto parcial actual: " + nota4);
                        Console.WriteLine("Ingrese la nota del cuarto parcial:");
                        notas.nota4 = Convert.ToSingle(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.WriteLine("Nota actualizada correctamente");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¿Desea actualizar otro campo? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s") continuar = false;
                Console.ResetColor();

            } while (continuar);
            CalcularPromedio();*/
            return aprobado = CalcularPromedio();
        }

        public List<Nota> MostrarNotasGeneralesPorEstudiante(Nota nota, Estudiante estudiante)
        {/*
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Mostrar notas por estudiante");
                Console.WriteLine("==================================");
                Console.WriteLine("Seleccione un estudiante:");
                ListarEstudiante();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Promedio de notas por parcial de todas sus clases:");
                Console.WriteLine("==================================");
                Console.WriteLine("Notas asignatura 1");
                Console.Write("\tNota 1: " + nota1);
                Console.WriteLine("\tNota 2: " + nota2);
                Console.Write("\tNota 3: " + nota3);
                Console.WriteLine("\tNota 4: " + nota4);
                Console.Write("\tPromedio: " + promedio);
                Console.WriteLine("\tAprobado: " + aprobado);
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

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¿Desea ver otro estudiante? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s") continuar = false;
                Console.ResetColor();

            } while (continuar);*/
            return new List<Nota>();
        }

        public List<Nota> MostrarNotasPorClase(Nota nota, Asignatura asignatura)
        {/*
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Mostrar notas por clase");
                Console.WriteLine("==================================");
                Console.WriteLine("Seleccione una asignatura:");
                ListarAsignatura();
                Console.ForegroundColor = ConsoleColor.Green;
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

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¿Desea ver otra asignatura? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s") continuar = false;
                Console.ResetColor();

            } while (continuar);*/
            return new List<Nota>();
        }

        public List<Estudiante> ListarEstudiante(Estudiante estudiante)
        {/*
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            Console.ResetColor();*/
            return new List<Estudiante>();
        }

        public List<Asignatura> ListarAsignatura(Asignatura asignatura)
        {/*
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            Console.ResetColor();*/
            return new List<Asignatura>();
        }
        public bool CalcularPromedio(/*float nota1,float nota2,float nota3, float nota4,float promedio, bool aprobado*/)
        {/*
            promedio = (nota1 + nota2 + nota3 + nota4) / 4;
            if (promedio >= 65 && promedio <= 100) aprobado = true;*/
            return false;
        }
    }
}
