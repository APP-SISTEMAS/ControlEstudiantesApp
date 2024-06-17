using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos
{
    class Municipio
    {
        int id;
        string departamento;
        string municipio;

        public static Municipio municipio1 = new Municipio();
        public static void GestionMunicipio()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestion de Municipios");
                Console.WriteLine("=====================");
                Console.WriteLine("1)Agregar Municipio");
                Console.WriteLine("2)Listar Municipios");
                Console.WriteLine("3)Buscar Municipio");
                Console.WriteLine("4)Modificar Municipio");
                Console.WriteLine("5)Eliminar Municipio");
                Console.WriteLine("0)Salir");
                Console.WriteLine("Seleccione una opcion:");
                int numeroOpcion = Convert.ToInt32(Console.ReadLine());
                switch (numeroOpcion)
                {
                    case 1:
                        Console.WriteLine("Agregar Municipio");
                        Console.WriteLine("=================");
                        Console.WriteLine("Ingrese el Id:");
                        municipio1.id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el Departamento:");
                        municipio1.departamento = Console.ReadLine();
                        Console.WriteLine("Ingrese el Municipio:");
                        municipio1.municipio = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Listar Municipios");
                        Console.WriteLine("=================");
                        Console.WriteLine("Id: " + municipio1.id);
                        Console.WriteLine("Departamento: " + municipio1.departamento);
                        Console.WriteLine("Municipio: " + municipio1.municipio);
                        break;
                    case 3:
                        Console.WriteLine("Buscar Municipio");
                        Console.WriteLine("=================");
                        Console.WriteLine("Ingrese el Id:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        if (id == municipio1.id)
                        {
                            Console.WriteLine("Id: " + municipio1.id);
                            Console.WriteLine("Departamento: " + municipio1.departamento);
                            Console.WriteLine("Municipio: " + municipio1.municipio);
                        }
                        else
                        {
                            Console.WriteLine("Municipio no encontrado");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Modificar Municipio");
                        Console.WriteLine("=================");
                        Console.WriteLine("Ingrese el Id:");
                        int idModificar = Convert.ToInt32(Console.ReadLine());
                        if (idModificar == municipio1.id)
                        {
                            Console.WriteLine("Ingrese el Departamento:");
                            municipio1.departamento = Console.ReadLine();
                            Console.WriteLine("Ingrese el Municipio:");
                            municipio1.municipio = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Municipio no encontrado");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Eliminar Municipio");
                        Console.WriteLine("=================");
                        Console.WriteLine("Ingrese el Id:");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        if (idEliminar == municipio1.id)
                        {
                            municipio1.id = 0;
                            municipio1.departamento = "";
                            municipio1.municipio = "";
                        }
                        else
                        {
                            Console.WriteLine("Municipio no encontrado");
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

