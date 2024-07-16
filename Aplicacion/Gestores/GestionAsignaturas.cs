using Aplicacion.Config;
using Aplicacion.Models;
using System;
using System.Collections.Generic;

namespace Aplicacion.Gestores
{
    public class GestionAsignaturas
    {
        private Database _database;
        public GestionAsignaturas()
        {
            _database = new Database();
        }
        public bool RegistrarAsignatura(Asignatura asignatura)
        {
            var result = false;
            try
            {
                if (_database.Context.State != System.Data.ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "insert into Asignatura(nombre,activo) values(@nombre,@activo)";
                command.Parameters.AddWithValue("@nombre", asignatura.AsignaturaNombre);
                command.Parameters.AddWithValue("@activo", asignatura.Activo);
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
        public bool ModificarAsignatura(Asignatura asignatura)
        {
            var result = false;
            try
            {
                if (_database.Context.State != System.Data.ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "update Asignatura set nombre = @nombre where id = @id";
                command.Parameters.AddWithValue("@nombre", asignatura.AsignaturaNombre);
                command.Parameters.AddWithValue("@id", asignatura.Id);
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
        public bool DeshabilitarAsignatura(int id)
        {
            var result = false;
            try
            {
                if (_database.Context.State != System.Data.ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "update Asignatura set activo = 0 where id = @id";
                command.Parameters.AddWithValue("@id", id);
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
        public bool HabilitarAsignatura(int id)
        {
            var result = false;
            try
            {
                if (_database.Context.State != System.Data.ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "update Asignatura set activo = 1 where id = @id";
                command.Parameters.AddWithValue("@id", id);
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
        public string ValidarAsignatura(Asignatura asignatura)
        {
            var mensajeValidacion = "";
            if (string.IsNullOrEmpty(asignatura.AsignaturaNombre)) mensajeValidacion += "La asignatura requiere un nombre";

            return mensajeValidacion;
        }
        public bool VerificarSiHayNotas(int idAsignatura)
        {
            var result = false;
            try
            {
                if (_database.Context.State != System.Data.ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "select count(1) from Notas where id_asignatura = @idAsignatura";
                command.Parameters.AddWithValue("@idAsignatura", idAsignatura);
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
        public List<Asignatura> ListarAsignaturas()
        {
            try
            {
                if (_database.Context.State != System.Data.ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "select id,nombre,activo from Asignatura";
                var reader = command.ExecuteReader();
                List<Asignatura> asignaturas = new List<Asignatura>();
                foreach (var item in reader)
                {
                    Asignatura asignatura = new Asignatura();
                    asignatura.Id = (int)reader["id"];
                    asignatura.AsignaturaNombre = reader["nombre"].ToString();
                    asignatura.Activo = (bool)reader["activo"];
                    asignaturas.Add(asignatura);
                }
                _database.Context.Close();
                return asignaturas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }
        public bool VerificarSiClaseExiste(string nombre)
        {
            var result = false;
            try
            {
                if (_database.Context.State != System.Data.ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "select count(1) from Asignatura where nombre = @nombre";
                command.Parameters.AddWithValue("@nombre", nombre);
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
        public bool ExisteIdAsignaturaActiva(int id)
        {
            var result = false;
            try
            {
                if (_database.Context.State != System.Data.ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "select count(1) from Asignatura where id = @id and activo=1";
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
        public bool ExisteIdAsignaturaInactiva(int id)
        {
            var result = false;
            try
            {
                if (_database.Context.State != System.Data.ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "select count(1) from Asignatura where id = @id and activo=0";
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
