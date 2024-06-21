using Aplicacion.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionWinform.Estudiantes
{
    public class GestionEstudiante
    {
        public string  Validar(Estudiante estudiante) {

            return "";
        }

        public List<Departamento> ObtenerListaDepartamentos() {

            return new List<Departamento>();
        }

        public List<Municipio> ObtenerListaMunicipios()
        {
            return new List<Municipio>();
        }

        public Boolean Guardar(Estudiante estudiante)
        {


            return true;
        }

        public Boolean Modificar(Estudiante estudiante, int id)
        {
            return true;
        }

        public Boolean Deshabilitar(String moitivo, int id)
        {
            return true;
        }

        public Boolean ExisteIdentidad(String id)
        {
            return true;
        }

        public Boolean EvarluarEdadMayor13(String id)
        {
            return true;
        }

    }
}
