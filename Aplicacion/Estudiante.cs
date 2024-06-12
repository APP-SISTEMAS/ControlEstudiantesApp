using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos
{
    class Estudiante
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
            Console.WriteLine("Gestion de Estudiante");
            Console.WriteLine("1)Registrar");
            Console.WriteLine("2)Actualizar");
            Console.WriteLine("3)Deshabilitar");
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
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }


        public void Registrar()
        {
        }
        public void Actualizar()
        {
        }

        public void Deshabilitar()
        {

        }
    }
}
