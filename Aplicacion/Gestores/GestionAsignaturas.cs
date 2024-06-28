using Aplicacion.Models;
using System.Collections.Generic;

namespace Aplicacion.Gestores
{
    public class GestionAsignaturas
    {
        public bool Agregar(Asignatura asignatura)
        {
            return true;
        }
        public bool Modificar(Asignatura asignatura)
        {
            return true;
        }
        public bool Eliminar(Asignatura asignatura)
        {
            return false;
        }
        public List<Asignatura> ListarAsignaturas()
        {
            return new List<Asignatura>();
        }
    }
}
