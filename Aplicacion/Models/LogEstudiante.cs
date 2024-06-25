using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Models
{
    public class LogEstudiante
    {
        public int IdEstudiante { get; set; }
        public bool Estado { get; set; }
        public string Motivo { get; set; }

        public LogEstudiante(int idEstudiante, bool estado, string motivo)
        {
            IdEstudiante = idEstudiante;
            Estado = estado;
            Motivo = motivo;
        }
    }
}
