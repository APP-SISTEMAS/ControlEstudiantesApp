using Aplicacion.Modelos;
using AplicacionWinform.Config;
using System.Data;


namespace AplicacionWinform.Estudiantes
{
    public class GestionEstudiante
    {

        private Database _db;

        public GestionEstudiante()
        {
            _db = new Database();    
        }

        public string  Validar(Estudiante estudiante) {

            return "";
        }

        public List<Departamento> ObtenerListaDepartamentos() {

            return new List<Departamento>();
        }

        public List<Municipio> ObtenerListaMunicipios()
        {
            DataTable data = new DataTable();
            this._db.DbContext.Open();
            var command = this._db.DbContext.CreateCommand();
            command.CommandText = "Select Id, IdDepartamento, Nombre from Municipios";
            data.Load(command.ExecuteReader());

            List<Municipio> lstMunicipios = new List<Municipio>();

            foreach (DataRow fila in data.Rows)
            {
                lstMunicipios.Add(new Municipio {
                    Id = (int)fila["Id"], 
                    IdDepartamento = (int)fila["IdDepartamento"],  
                    Nombre= fila["Nombre"].ToString()
                    }
                );
            }
            this._db.DbContext.Close();
            return lstMunicipios;
        }

        public Boolean Guardar(Estudiante estudiante)
        {
           

            return true;
        }

        public Boolean Modificar(Estudiante estudiante, int id)
        {
            return true;
        }

        public Boolean Deshabilitar(String moitivo, int id)
        {
            return true;
        }

        public Boolean ExisteIdentidad(String id)
        {
            return true;
        }

        public Boolean EvarluarEdadMayor13(String id)
        {
            return true;
        }

    }
}
