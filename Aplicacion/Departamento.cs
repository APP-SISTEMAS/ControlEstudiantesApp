using System;


namespace EstructurasDatos
{
    class Departamento
    {
        int id;
        String departamento;

        public static Departamento departamento1 = new Departamento();
        public static void GestionDepartamento()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestion de Departamentos");
                Console.WriteLine("=========================");
                Console.WriteLine("1)Agregar Departamento");
                Console.WriteLine("2)Listar Departamentos");
                Console.WriteLine("3)Buscar Departamento");
                Console.WriteLine("4)Modificar Departamento");
                Console.WriteLine("5)Eliminar Departamento");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        Console.WriteLine("Agregar Departamento");
                        Console.WriteLine("====================");
                        Console.WriteLine("Ingrese el Id:");
                        departamento1.id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el Departamento:");
                        departamento1.departamento = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Listar Departamentos");
                        Console.WriteLine("====================");
                        Console.WriteLine("Id: " + departamento1.id);
                        Console.WriteLine("Departamento: " + departamento1.departamento);
                        break;
                    case 3:
                        Console.WriteLine("Buscar Departamento");
                        Console.WriteLine("====================");
                        Console.WriteLine("Ingrese el Id:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        if (id == departamento1.id)
                        {
                            Console.WriteLine("Id: " + departamento1.id);
                            Console.WriteLine("Departamento: " + departamento1.departamento);
                        }
                        else
                        {
                            Console.WriteLine("Departamento no encontrado");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Modificar Departamento");
                        Console.WriteLine("======================");
                        Console.WriteLine("Ingrese el Id:");
                        int idModificar = Convert.ToInt32(Console.ReadLine());
                        if (idModificar == departamento1.id)
                        {
                            Console.WriteLine("Ingrese el Departamento:");
                            departamento1.departamento = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Departamento no encontrado");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Eliminar Departamento");
                        Console.WriteLine("======================");
                        Console.WriteLine("Ingrese el Id:");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        if (idEliminar == departamento1.id)
                        {
                            departamento1.id = 0;
                            departamento1.departamento = "";
                        }
                        else
                        {
                            Console.WriteLine("Departamento no encontrado");
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
