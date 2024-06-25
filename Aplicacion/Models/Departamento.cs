using System;


namespace Aplicacion.Models
{
    public class Departamento
    {
        public int Id {  get; set; }
        public string DepartamentoNombre { get; set; }

        public Departamento(int id, string departamentoNombre)
        {
            Id = id;
            DepartamentoNombre = departamentoNombre;
        }
        //public static void GestionDepartamento()
        //{
        //    bool continuar = true;
        //    do
        //    {
        //        Console.Clear();
        //        Console.ForegroundColor = ConsoleColor.Cyan;
        //        Console.WriteLine("Gestion de Departamentos");
        //        Console.WriteLine("=========================");
        //        Console.WriteLine("1)Agregar Departamento");
        //        Console.WriteLine("2)Listar Departamentos");
        //        Console.WriteLine("3)Modificar Departamento");
        //        Console.WriteLine("4)Eliminar Departamento");
        //        Console.WriteLine("0)Salir");
        //        Console.WriteLine("Seleccione una opcion:");
        //        int numeroOpcion = Convert.ToInt32(Console.ReadLine());
        //        Console.ResetColor();
        //        switch (numeroOpcion)
        //        {
        //            case 1:
        //                Console.Clear();
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine("Agregar Departamento");
        //                Console.WriteLine("====================");
        //                Console.WriteLine("Ingrese el Departamento:");
        //                departamento1.departamento = Console.ReadLine();
        //                Console.WriteLine("Departamento agregado correctamente");
        //                Console.ResetColor();
        //                Console.ReadKey();
        //                break;
        //            case 2:
        //                Console.Clear();
        //                ListarDepartamento();
        //                Console.ReadKey();
        //                break;
        //            case 3:
        //                Console.Clear();
        //                Console.WriteLine("Modificar Departamento");
        //                Console.WriteLine("======================");
        //                Console.WriteLine("Ingrese el Id:");
        //                int idModificar = Convert.ToInt32(Console.ReadLine());
        //                if (idModificar != departamento1.id)
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Green;
        //                    Console.WriteLine("Ingrese el Departamento:");
        //                    departamento1.departamento = Console.ReadLine();
        //                    Console.WriteLine("Departamento modificado correctamente");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Departamento no encontrado");
        //                }
        //                Console.ResetColor();
        //                Console.ReadKey();
        //                break;
        //            case 4:
        //                Console.Clear();
        //                Console.WriteLine("Eliminar Departamento");
        //                Console.WriteLine("======================");
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine("Ingrese el Id:");
        //                int idEliminar = Convert.ToInt32(Console.ReadLine());
        //                if (idEliminar == departamento1.id)
        //                {
        //                    departamento1.id = 0;
        //                    departamento1.departamento = "";
        //                    Console.WriteLine("Departamento eliminado correctamente");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Departamento no encontrado");
        //                }
        //                Console.ResetColor();
        //                Console.ReadKey();
        //                break;
        //            case 0:
        //                continuar = false;
        //                break;
        //            default:
        //                Console.WriteLine("Opcion no valida");
        //                break;
        //        }
        //    } while (continuar);
        //}
        //public static void ListarDepartamento()
        //{
        //    Console.WriteLine("Listar Departamentos");
        //    Console.ForegroundColor = ConsoleColor.DarkYellow;
        //    for (int i = 0; i < 3; i++)
        //    {

        //        Console.WriteLine("====================");
        //        Console.Write("Id: " + departamento1.id);
        //        Console.WriteLine("\tDepartamento: " + departamento1.departamento);
        //    }
        //    Console.ResetColor();
        //}
    }
}
