using Aplicacion.Models;
using System.Collections.Generic;

namespace Aplicacion.Gestores
{
    public class GestionNotas
    {

        public bool Registrar(bool aprobado)
        {
            return aprobado = CalcularPromedio();
        }

        public bool ActualizarNota(bool aprobado)
        {
            return aprobado = CalcularPromedio();
        }

        public List<Nota> MostrarNotasGeneralesPorEstudiante(Nota nota, Estudiante estudiante)
        {
            return new List<Nota>();
        }

        public List<Nota> MostrarNotasPorClase(Nota nota, Asignatura asignatura)
        {
            return new List<Nota>();
        }

        public List<Estudiante> ListarEstudiante(Estudiante estudiante)
        {
            return new List<Estudiante>();
        }

        public List<Asignatura> ListarAsignatura(Asignatura asignatura)
        {
            return new List<Asignatura>();
        }
        public bool CalcularPromedio(/*float nota1,float nota2,float nota3, float nota4*/)
        {
            return false;
        }
    }
}
