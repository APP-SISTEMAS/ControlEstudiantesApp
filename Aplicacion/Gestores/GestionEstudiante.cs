using Aplicacion.Config;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Aplicacion.Gestores
{
    public class GestionEstudiante
    {
        private Database _database;
        public GestionEstudiante()
        {
            _database = new Database();
        }
        public string ValidarEstudiante(Estudiante estudiante)
        {
            var mensajeValidacion = "";
            if (string.IsNullOrEmpty(estudiante.Nombre)) mensajeValidacion += "El campo nombre es requerido\n";

            if (string.IsNullOrEmpty(estudiante.Apellido)) mensajeValidacion += "El campo apellido es requerido\n";

            if (estudiante.FechaNacimiento == null) mensajeValidacion += "El campo fecha de nacimiento es requerido\n";

            if (string.IsNullOrEmpty(estudiante.Identificacion)) mensajeValidacion += "El campo identificacion es requerido\n";

            if (string.IsNullOrEmpty(estudiante.Genero.ToString())) mensajeValidacion += "El campo genero es requerido\n";

            if (string.IsNullOrEmpty(estudiante.Departamento)) mensajeValidacion += "El campo departamento es requerido\n";

            if (string.IsNullOrEmpty(estudiante.Municipio)) mensajeValidacion += "El campo municipio es requerido\n";

            if (string.IsNullOrEmpty(estudiante.Direccion)) mensajeValidacion += "El campo direccion es requerido\n";

            if (string.IsNullOrEmpty(estudiante.TipoSangre)) mensajeValidacion += "El campo tipo de sangre es requerido\n";

            if (string.IsNullOrEmpty(estudiante.Tutor)) mensajeValidacion += "El campo tutor es requerido\n";

            return mensajeValidacion;
        }
        public bool ValidarIdentificacion(string identidad)
        {
            if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

            var command = _database.Context.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM Estudiante WHERE identidad = @identidad";
            command.Parameters.AddWithValue("@identidad", identidad);
            int count = (int)command.ExecuteScalar();
            _database.Context.Close();
            return count == 0;
        }
        public List<Departamento> ObtenerListaDepartamentos()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            DataTable data = new DataTable();
            if (this._database.Context.State != ConnectionState.Open) this._database.Context.Open();

            var command = this._database.Context.CreateCommand();
            command.CommandText = "SELECT id,nombre FROM Departamento";
            data.Load(command.ExecuteReader());
            List<Departamento> departamentos = new List<Departamento>();
            foreach (DataRow fila in data.Rows)
            {
                departamentos.Add(new Departamento
                {
                    Id = (int)(fila["Id"]),
                    DepartamentoNombre = fila["nombre"].ToString()
                });
            }
            this._database.Context.Close();
            return departamentos;
        }
        public List<Municipio> ObtenerListaMunicipios(string idDepartamento)
        {
            DataTable data = new DataTable();
            if (this._database.Context.State != ConnectionState.Open) this._database.Context.Open();

            var command = this._database.Context.CreateCommand();
            command.CommandText = "SELECT m.id, m.municipio, d.nombre AS departamento_nombre FROM Municipio m JOIN Departamento d ON m.id_departamento = d.id WHERE m.id_departamento = @id";
            command.Parameters.AddWithValue("@id", idDepartamento);
            data.Load(command.ExecuteReader());
            List<Municipio> municipios = new List<Municipio>();
            foreach (DataRow fila in data.Rows)
            {
                municipios.Add(new Municipio
                {
                    Id = (int)(fila["Id"]),
                    MunicipioNombre = fila["Municipio"].ToString(),
                    DepartamentoNombre = fila["departamento_nombre"].ToString()
                });
            }
            this._database.Context.Close();
            return municipios;
        }
        public List<TipoSangre> ObtenerListaTipoSangre()
        {
            DataTable data = new DataTable();
            if (this._database.Context.State != ConnectionState.Open) this._database.Context.Open();

            var command = this._database.Context.CreateCommand();
            command.CommandText = "select id, nombre from tipo_sangre order by id";
            data.Load(command.ExecuteReader());
            List<TipoSangre> tiposangre = new List<TipoSangre>();
            foreach (DataRow fila in data.Rows)
            {
                tiposangre.Add(new TipoSangre
                {
                    Id = (int)(fila["id"]),
                    SangreNombre = fila["nombre"].ToString()
                });
            }
            this._database.Context.Close();
            return tiposangre;
        }
        public bool RegistrarEstudiante(Estudiante estudiante)
        {
            var result = false;
            try
            {
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "INSERT INTO Estudiante (nombre, apellido, fecha_nacimiento, identidad, genero, activo, telefono, id_departamento, id_municipio, direccion, correo, id_tipo_sangre, tutor) VALUES (@nombre, @apellido, @fecha_nacimiento, @identidad, @genero, @activo, @telefono, @id_departamento, @id_municipio, @direccion, @correo, @id_tipo_sangre, @tutor)";
                command.Parameters.AddWithValue("@nombre", estudiante.Nombre);
                command.Parameters.AddWithValue("@apellido", estudiante.Apellido);
                command.Parameters.AddWithValue("@fecha_nacimiento", estudiante.FechaNacimiento);
                command.Parameters.AddWithValue("@identidad", estudiante.Identificacion);
                command.Parameters.AddWithValue("@genero", estudiante.Genero);
                command.Parameters.AddWithValue("@activo", estudiante.Activo);
                command.Parameters.AddWithValue("@telefono", estudiante.Telefono);
                command.Parameters.AddWithValue("@id_departamento", estudiante.Departamento);
                command.Parameters.AddWithValue("@id_municipio", estudiante.Municipio);
                command.Parameters.AddWithValue("@direccion", estudiante.Direccion);
                command.Parameters.AddWithValue("@correo", estudiante.Correo);
                command.Parameters.AddWithValue("@id_tipo_sangre", estudiante.TipoSangre);
                command.Parameters.AddWithValue("@tutor", estudiante.Tutor);
                command.ExecuteNonQuery();
                result = true;
                _database.Context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            return result;
        }
        public bool ActualizarEstudiante(Estudiante estudiante, int idEstudiante)
        {
            var result = false;
            try
            {
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "UPDATE Estudiante SET nombre = @nombre, apellido = @apellido, fecha_nacimiento = @fechaNacimiento, identidad = @identidad, genero = @genero, activo = @activo, telefono = @telefono, id_departamento = @departamento, id_municipio = @municipio, direccion = @direccion, correo = @correo, id_tipo_sangre = @idTipoSangre, tutor = @tutor WHERE id = @idEstudiante";
                command.Parameters.AddWithValue("@nombre", estudiante.Nombre);
                command.Parameters.AddWithValue("@apellido", estudiante.Apellido);
                command.Parameters.AddWithValue("@fechaNacimiento", estudiante.FechaNacimiento);
                command.Parameters.AddWithValue("@identidad", estudiante.Identificacion);
                command.Parameters.AddWithValue("@genero", estudiante.Genero);
                command.Parameters.AddWithValue("@activo", estudiante.Activo);
                command.Parameters.AddWithValue("@telefono", estudiante.Telefono);
                command.Parameters.AddWithValue("@departamento", estudiante.Departamento);
                command.Parameters.AddWithValue("@municipio", estudiante.Municipio);
                command.Parameters.AddWithValue("@direccion", estudiante.Direccion);
                command.Parameters.AddWithValue("@correo", estudiante.Correo);
                command.Parameters.AddWithValue("@idTipoSangre", estudiante.TipoSangre);
                command.Parameters.AddWithValue("@tutor", estudiante.Tutor);
                command.Parameters.AddWithValue("@idEstudiante", idEstudiante);
                command.ExecuteNonQuery();
                result = true;
                _database.Context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            return result;
        }
        public Estudiante ObtenerInformacionEstudiante(int id)
        {
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

            var command = _database.Context.CreateCommand();
            command.CommandText = "SELECT e.id, e.nombre, e.apellido, e.fecha_nacimiento, e.identidad, e.genero, e.activo, e.telefono, d.nombre AS departamento, m.municipio AS municipio, e.direccion, e.correo, ts.nombre AS tipo_sangre, e.tutor FROM Estudiante e JOIN Departamento d ON e.id_departamento = d.id JOIN Municipio m ON e.id_municipio = m.id JOIN Tipo_Sangre ts ON e.id_tipo_sangre = ts.id WHERE e.id = @id";
            command.Parameters.AddWithValue("@Id", id);
            data.Load(command.ExecuteReader());
            Estudiante estudiante = new Estudiante();
            foreach (DataRow fila in data.Rows)
            {
                estudiante.Id = (int)(fila["id"]);
                estudiante.Nombre = fila["nombre"].ToString();
                estudiante.Apellido = fila["apellido"].ToString();
                estudiante.FechaNacimiento = (DateTime)(fila["fecha_nacimiento"]);
                estudiante.Identificacion = fila["identidad"].ToString();
                estudiante.Genero = Convert.ToChar(fila["genero"]);
                estudiante.Activo = Convert.ToBoolean(fila["activo"]);
                estudiante.Telefono = fila["telefono"].ToString();
                estudiante.Departamento = fila["departamento"].ToString();
                estudiante.Municipio = fila["municipio"].ToString();
                estudiante.Direccion = fila["direccion"].ToString();
                estudiante.Correo = fila["correo"].ToString();
                estudiante.TipoSangre = fila["tipo_sangre"].ToString();
                estudiante.Tutor = fila["tutor"].ToString();
            }
            _database.Context.Close();
            return estudiante;
        }
        public List<Estudiante> ObtenerListaEstudiantes()
        {
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

            var command = _database.Context.CreateCommand();
            command.CommandText = "SELECT id, nombre, apellido, fecha_nacimiento, identidad FROM Estudiante";
            data.Load(command.ExecuteReader());
            List<Estudiante> estudiantes = new List<Estudiante>();
            foreach (DataRow fila in data.Rows)
            {
                estudiantes.Add(new Estudiante
                {
                    Id = (int)(fila["id"]),
                    Nombre = fila["nombre"].ToString(),
                    Apellido = fila["apellido"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(fila["fecha_nacimiento"]),
                    Identificacion = fila["identidad"].ToString()
                });
            }
            _database.Context.Close();
            return estudiantes;
        }
        public bool ExisteIdEstudiante(int id)
        {
            var result = false;
            try
            {
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "SELECT COUNT(1) FROM Estudiante WHERE id = @id and activo=1";
                command.Parameters.AddWithValue("@id", id);
                var count = (int)command.ExecuteScalar();
                if (count > 0) return result = true;
                _database.Context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            return result;
        }
        public bool ExisteIdDepartamento(string id)
        {
            var result = false;
            try
            {
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "SELECT COUNT(1) FROM Departamento WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                var count = (int)command.ExecuteScalar();
                if (count > 0) return result = true;
                _database.Context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            return result;
        }
        public bool ExisteIdMunicipio(string id)
        {
            var result = false;
            try
            {
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "SELECT COUNT(1) FROM Municipio WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                var count = (int)command.ExecuteScalar();
                if (count > 0) return result = true;
                _database.Context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            return result;
        }
        public bool ExisteIdTipoSangre(string id)
        {
            var result = false;
            try
            {
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "SELECT COUNT(1) FROM Tipo_Sangre WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                var count = (int)command.ExecuteScalar();
                if (count > 0) return result = true;
                _database.Context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            return result;
        }
    }
}