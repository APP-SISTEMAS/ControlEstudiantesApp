namespace Aplicacion.Models
{
    public class Municipio: Departamento
    {
        public int Id { get; set; }
        public int DepartamentoCodigo { get; set; }
        public string MunicipioNombre { get; set; }

        public string DepartamentoNombre { get; set; }
    }
}