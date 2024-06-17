using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    internal class Asignatura
    {
        int id;
        string asignatura;
        bool activo;

        public static Asignatura asignatura1 = new Asignatura();

        public static void GestionAsignatura()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestion de Asignaturas");
                Console.WriteLine("=======================");
                Console.WriteLine("1)Agregar Asignatura");
                Console.WriteLine("2)Listar Asignaturas");
                Console.WriteLine("3)Buscar Asignatura");
                Console.WriteLine("4)Modificar Asignatura");
                Console.WriteLine("5)Eliminar Asignatura");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        Console.WriteLine("Agregar Asignatura");
                        Console.WriteLine("==================");
                        Console.WriteLine("Ingrese el Id:");
                        asignatura1.id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese la Asignatura:");
                        asignatura1.asignatura = Console.ReadLine();
                        asignatura1.activo = true;
                        break;
                    case 2:
                        Console.WriteLine("Listar Asignaturas");
                        Console.WriteLine("==================");
                        Console.WriteLine("Id: " + asignatura1.id);
                        Console.WriteLine("Asignatura: " + asignatura1.asignatura);
                        Console.WriteLine("Activo: " + asignatura1.activo);
                        break;
                    case 3:
                        Console.WriteLine("Buscar Asignatura");
                        Console.WriteLine("==================");
                        Console.WriteLine("Ingrese el Id:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        if (id == asignatura1.id)
                        {
                            Console.WriteLine("Id: " + asignatura1.id);
                            Console.WriteLine("Asignatura: " + asignatura1.asignatura);
                            Console.WriteLine("Activo: " + asignatura1.activo);
                        }
                        else
                        {
                            Console.WriteLine("Asignatura no encontrada");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Modificar Asignatura");
                        Console.WriteLine("====================");
                        Console.WriteLine("Ingrese el Id:");
                        int idModificar = Convert.ToInt32(Console.ReadLine());
                        if (idModificar == asignatura1.id)
                        {
                            Console.WriteLine("Ingrese la Asignatura:");
                            asignatura1.asignatura = Console.ReadLine();
                            Console.WriteLine("Ingrese el estado:");
                            asignatura1.activo = Convert.ToBoolean(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Asignatura no encontrada");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Eliminar Asignatura");
                        Console.WriteLine("====================");
                        Console.WriteLine("Ingrese el Id:");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        if (idEliminar == asignatura1.id)
                        {
                            asignatura1.activo = false;
                        }
                        else
                        {
                            Console.WriteLine("Asignatura no encontrada");
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
    }
}
