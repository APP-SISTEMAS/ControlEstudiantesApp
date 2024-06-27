namespace Aplicacion.Models
{
    public class LogEstudiante
    {
        public int IdEstudiante { get; set; }
        public bool Estado { get; set; }
        public string? Motivo { get; set; }

        //public LogEstudiante(int idEstudiante, bool estado, string motivo)
        //{
        //    IdEstudiante = idEstudiante;
        //    Estado = estado;
        //    Motivo = motivo;
        //}
        //public LogEstudiante()
        //{
        //    this.IdEstudiante = 0;
        //    this.Estado = false;
        //    this.Motivo = null;
        //}
    }
}
