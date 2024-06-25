using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Models
{
    public class TipoSangre
    {
        public int Id {  get; set; }
        public string SangreNombre {  get; set; }

        public TipoSangre(int id, string sangreNombre)
        {
            Id = id;
            SangreNombre = sangreNombre;
        }
    }
}
