using System;

namespace Aplicacion.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public char Genero { get; set; }
        public bool Activo { get; set; }
        public string? Telefono { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Direccion { get; set; }
        public string? Correo { get; set; }
        public string TipoSangre { get; set; }
        public string Tutor { get; set; }
        public string? Motivo { get; set; }
    }
}
