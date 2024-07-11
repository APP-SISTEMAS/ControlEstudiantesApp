namespace Aplicacion.Models
{
    public class Municipio: Departamento
    {
        public new int Id { get; set; }
        public int DepartamentoCodigo { get; set; }
        public string MunicipioNombre { get; set; }

        public new string DepartamentoNombre { get; set; }
    }
}