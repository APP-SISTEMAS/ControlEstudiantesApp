using Aplicacion.Models;
using System;
using System.Collections.Generic;

namespace Aplicacion.Gestores
{
    public class GestionHabilitacionEstudiante
    {
        public Boolean Deshabilitar(Estudiante estudiante, string motivo)
        {
            return true;
        }
        public Boolean Habilitar(Estudiante estudiante, string motivo)
        {
            return true;
        }
        public List<Estudiante> EstudiantesHabilitados()
        {
            return new List<Estudiante>();
        }
        public List<Estudiante> EstudiantesDeshabilitados()
        {
            return new List<Estudiante>();
        }
    }
}
