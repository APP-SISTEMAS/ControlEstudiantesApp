namespace Aplicacion.Models
{
    public class Nota
    {
        public int IdEstudiante { get; set; }
        public int IdAsignatura { get; set; }
        public decimal? Nota1 { get; set; }
        public decimal? Nota2 { get; set; }
        public decimal? Nota3 { get; set; }
        public decimal? Nota4 { get; set; }
        public decimal? Promedio { get; set; }
        public bool? Aprobado { get; set; }
        public string NombreEstudiante { get; set; }
        public string ApellidoEstudiante { get; set; }
        public string NombreAsignatura { get; set; }
    }
}
