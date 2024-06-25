using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Models
{
    public class Asignatura
    {
        public int Id {  get; set; }
        public string AsignaturaNombre {  get; set; }
        public bool Activo {  get; set; }
        
        public Asignatura(int id, string asignaturaNombre, bool activo)
        {
            Id = id;
            AsignaturaNombre = asignaturaNombre;
            Activo = activo;
        }
    }
}
