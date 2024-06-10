using System;

namespace EstructurasDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aplicacion Control de Estudiantes!");

            string nombre = "";
            DateTime fechaNac;
            int[] numero;



            Estudiante estudiante1 = new Estudiante();
            estudiante1.nombre = "Irvin";
            estudiante1.fechaNac = null;
            estudiante1.Registrar();
            estudiante1.Deshabilitar();

        }



    }
}
