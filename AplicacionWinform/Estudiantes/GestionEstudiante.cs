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

        public string Validar(Estudiante estudiante) {

            var msjValidacion = "";

            if (string.IsNullOrWhiteSpace(estudiante.Nombre))
                msjValidacion += "El nombre no puede estar vacio o nullo \n";


            if (string.IsNullOrWhiteSpace(estudiante.Identidad))
                msjValidacion += "La identidad no puede estar vacia o nullo  \n";


            return msjValidacion;
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

        public bool Guardar(Estudiante estudiante)
        {
            var result  = false;
            try
            {
                this._db.DbContext.Open();
                var command = this._db.DbContext.CreateCommand();
                command.CommandText = $@"
                    INSERT INTO Estudiantes (Nombre, Identidad, FechaNacimiento, Activo)
                    Values ( @Nombre, @Identidad, @FechaNacimiento, 1) ";
                command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                command.Parameters.AddWithValue("@Identidad", estudiante.Identidad );
                command.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento.ToString("dd/MM/yyyy"));
                var rowsAfected = command.ExecuteNonQuery();
                result = rowsAfected > 0;
                this._db.DbContext.Close();
            }
            catch (Exception err)
            {
                throw new Exception("Ocurrio un error en la base de datos: "+err);
            }
            return result;
        }

        public bool Modificar(Estudiante estudiante, int id)
        {
            this._db.DbContext.Open();
            var command = this._db.DbContext.CreateCommand();
            command.CommandText = $@"
                UDPATE Estudiantes SET Nombre = @Nombre, Identidad = @Identidad, FechaNacimiento = @FechaNacimiento
                WHERE Id = @Id  ";
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
            command.Parameters.AddWithValue("@Identidad", estudiante.Identidad);
            command.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
            var rowsAfected = command.ExecuteNonQuery();
            this._db.DbContext.Close();
            return rowsAfected > 0;
        }

        public bool Deshabilitar(string motivo, int id)
        {
            this._db.DbContext.Open();
            var command = this._db.DbContext.CreateCommand();
            command.CommandText = $@"
                UDPATE Estudiantes SET Activo = 0, Motivo =@Motivo  WHERE Id = @Id ";
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Motivo", motivo);
            var rowsAfected = command.ExecuteNonQuery();
            this._db.DbContext.Close();
            return rowsAfected > 0;
        }

        public bool ExisteIdentidad(string identidad)
        {
            this._db.DbContext.Open();
            var command = this._db.DbContext.CreateCommand();
            command.CommandText = $@"
                SELECT * FROM Estudiantes WHERE Identidad = @Identidad ";
            command.Parameters.AddWithValue("@Identidad", identidad);
            var rowsAfected = command.ExecuteNonQuery();
            this._db.DbContext.Close();
            return rowsAfected > 0;
        }

        public List<Estudiante> ObtenerListaEstudiantes()
        {
            DataTable data = new DataTable();
            this._db.DbContext.Open();
            var command = this._db.DbContext.CreateCommand();
            command.CommandText = "Select Id, Nombre, Identidad, FechaNacimiento from Estudiantes Where Activo = 1  ";
            data.Load(command.ExecuteReader());
            var lstEstudiantes = new List<Estudiante>();

            foreach (DataRow fila in data.Rows)
            {
                var nuevoEstudiante = new Estudiante();
                nuevoEstudiante.Id = (int)fila["Id"];
                nuevoEstudiante.Nombre = fila["Nombre"].ToString();
                nuevoEstudiante.Identidad = fila["Identidad"].ToString();
                nuevoEstudiante.FechaNacimiento = (DateTime)fila["FechaNacimiento"];
                lstEstudiantes.Add(nuevoEstudiante);

                //lstEstudiantes.Add(new Estudiante
                //    {
                //        Id = (int)fila["Id"],
                //        Nombre = fila["Nombre"].ToString(),
                //        Identidad = fila["Identidad"].ToString(),
                //        FechaNacimiento = (DateTime)fila["FechaNacimiento"],
                //    }
                //);
            }
            this._db.DbContext.Close();
            return lstEstudiantes;
        }

        public Estudiante ObtenerDatosEstudiante(int id)
        {
            DataTable data = new DataTable();
            this._db.DbContext.Open();
            var command = this._db.DbContext.CreateCommand();
            command.CommandText = "Select Id, Nombre, Identidad, FechaNacimiento from Estudiantes Where Id = @Id  ";
            command.Parameters.AddWithValue("@Id", id);
            data.Load(command.ExecuteReader());
            var estudiante = new Estudiante();
            //estudiante = null;
            foreach (DataRow fila in data.Rows)
            {
                estudiante.Id = (int)fila["Id"];
                estudiante.Nombre = fila["Nombre"].ToString();
                estudiante.Identidad = fila["Identidad"].ToString();
                estudiante.FechaNacimiento = (DateTime)fila["FechaNacimiento"];
            }
            this._db.DbContext.Close();
            return estudiante;
        }



    }
}
