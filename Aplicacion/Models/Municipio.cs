using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Models
{
    public class Municipio
    {
        public int Id {  get; set; }
        public int DepartamentoCodigo { get; set; }
        public string MunicipioNombre { get; set; }

        public Municipio(int id, int departamentoCodigo, string municipioNombre)
        {
            Id = id;
            DepartamentoCodigo = departamentoCodigo;
            MunicipioNombre = municipioNombre;
        }

        //public static Municipio municipio1 = new Municipio();
        //public static void GestionMunicipio()
        //{
        //    bool continuar = true;
        //    do
        //    {
        //        Console.Clear();
        //        Console.ForegroundColor = ConsoleColor.Cyan;
        //        Console.WriteLine("Gestion de Municipios");
        //        Console.WriteLine("=====================");
        //        Console.WriteLine("1)Agregar Municipio");
        //        Console.WriteLine("2)Listar Municipios");
        //        Console.WriteLine("3)Modificar Municipio");
        //        Console.WriteLine("4)Eliminar Municipio");
        //        Console.WriteLine("0)Salir");
        //        Console.WriteLine("Seleccione una opcion:");
        //        int numeroOpcion = Convert.ToInt32(Console.ReadLine());
        //        Console.ResetColor();
        //        switch (numeroOpcion)
        //        {
        //            case 1:
        //                Console.Clear();
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine("Agregar Municipio");
        //                Console.WriteLine("=================");
        //                Console.WriteLine("Ingrese el Departamento:");
        //                municipio1.departamento = Console.ReadLine();
        //                Console.WriteLine("Ingrese el Municipio:");
        //                municipio1.municipio = Console.ReadLine();
        //                Console.WriteLine("Municipio agregado correctamente");
        //                Console.ResetColor();
        //                Console.ReadKey();
        //                break;
        //            case 2:
        //                Console.Clear();
        //                ListarMunicipios();
        //                Console.ReadKey();
        //                break;
        //            case 3:
        //                Console.Clear();
        //                Console.WriteLine("Modificar Municipio");
        //                Console.WriteLine("=================");
        //                Console.WriteLine("Ingrese el Id:");
        //                int idModificar = Convert.ToInt32(Console.ReadLine());
        //                if (idModificar == municipio1.id)
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Green;
        //                    Console.WriteLine("Ingrese el Departamento:");
        //                    municipio1.departamento = Console.ReadLine();
        //                    Console.WriteLine("Ingrese el Municipio:");
        //                    municipio1.municipio = Console.ReadLine();
        //                    Console.WriteLine("Municipio modificado correctamente");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Municipio no encontrado");
        //                }
        //                Console.ResetColor();
        //                Console.ReadKey();
        //                break;
        //            case 4:
        //                Console.Clear();
        //                Console.WriteLine("Eliminar Municipio");
        //                Console.WriteLine("=================");
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine("Ingrese el Id:");
        //                int idEliminar = Convert.ToInt32(Console.ReadLine());
        //                if (idEliminar == municipio1.id)
        //                {
        //                    municipio1.id = 0;
        //                    municipio1.departamento = "";
        //                    municipio1.municipio = "";
        //                    Console.WriteLine("Municipio eliminado correctamente");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Municipio no encontrado");
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
        //public static void ListarMunicipios()
        //{
        //    Console.ForegroundColor = ConsoleColor.DarkYellow;
        //    Console.WriteLine("Listar Municipios");
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Console.WriteLine("=================");
        //        Console.Write("Id: " + municipio1.id);
        //        Console.Write("\tDepartamento: " + municipio1.departamento);
        //        Console.WriteLine("\tMunicipio: " + municipio1.municipio);
        //    }
        //    Console.ResetColor();
        //}
    }
}

