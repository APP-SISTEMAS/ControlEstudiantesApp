namespace Aplicacion.Models
{
    public class Nota
    {
        public int IdEestudiante { get; set; }
        public int IdAasignatura { get; set; }
        public float? Nota1 { get; set; }
        public float? Nota2 { get; set; }
        public float? Nota3 { get; set; }
        public float? Nota4 { get; set; }
        public float? Promedio { get; set; }
        public bool? Aprobado { get; set; }
    }
}
