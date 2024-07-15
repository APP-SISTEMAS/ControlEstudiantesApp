using Aplicacion.Config;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Aplicacion.Gestores
{
    public class GestionHabilitacionEstudiante
    {
        private Database _database;
        public GestionHabilitacionEstudiante()
        {
            _database = new Database();
        }

        public bool DeshabilitarEstudiante(string motivo, int id)
        {
            try
            {
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "UPDATE Estudiante SET activo = 0 WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                int rowsAffectedEstudiante = command.ExecuteNonQuery();

                command.CommandText = "SELECT COUNT(1) FROM log_estudiante WHERE id_estudiante = @Id";
                int exists = (int)command.ExecuteScalar();
                if (exists > 0)
                {
                    command.CommandText = "UPDATE log_estudiante SET estado = 0, motivo = @Motivo WHERE id_estudiante = @Id";
                }
                else
                {
                    // Insert new record
                    command.CommandText = "INSERT INTO log_estudiante (id_estudiante, estado, motivo) VALUES (@Id, 0, @Motivo)";
                }
                command.Parameters.AddWithValue("@Motivo", motivo);
                int rowsAffectedLogEstudiante = command.ExecuteNonQuery();

                this._database.Context.Close();
                return rowsAffectedEstudiante > 0 && rowsAffectedLogEstudiante > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }
        public bool HabilitarEstudiante(string motivo, int id)
        {
            try
            {
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "UPDATE Estudiante SET activo = 1 WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                int rowsAffectedEstudiante = command.ExecuteNonQuery();

                command.CommandText = "SELECT COUNT(1) FROM log_estudiante WHERE id_estudiante = @Id";
                int exists = (int)command.ExecuteScalar();
                if (exists > 0)
                {
                    command.CommandText = "UPDATE log_estudiante SET estado = 1, motivo = @Motivo WHERE id_estudiante = @Id";
                }
                else
                {
                    // Insert new record
                    command.CommandText = "INSERT INTO log_estudiante (id_estudiante, estado, motivo) VALUES (@Id, 1, @Motivo)";
                }
                command.Parameters.AddWithValue("@Motivo", motivo);
                int rowsAffectedLogEstudiante = command.ExecuteNonQuery();

                this._database.Context.Close();
                return rowsAffectedLogEstudiante > 0 && rowsAffectedEstudiante > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }
        public List<Estudiante> EstudiantesHabilitados()
        {
            try
            {
                DataTable data = new DataTable();
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "select id, Nombre,apellido from estudiante where activo=1";
                data.Load(command.ExecuteReader());
                List<Estudiante> estudiantes = new List<Estudiante>();

                foreach (DataRow fila in data.Rows)
                {
                    estudiantes.Add(new Estudiante
                    {
                        Id = (int)(fila["id"]),
                        Nombre = fila["Nombre"].ToString(),
                        Apellido = fila["apellido"].ToString()
                    });
                }
                _database.Context.Close();
                return estudiantes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }
        public List<Estudiante> EstudiantesDeshabilitados()
        {
            try
            {
                DataTable data = new DataTable();
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "SELECT e.id , e.nombre, e.apellido, le.motivo FROM Estudiante e JOIN Log_Estudiante le ON e.id = le.id_estudiante WHERE e.activo = 0";
                data.Load(command.ExecuteReader());
                List<Estudiante> estudiantes = new List<Estudiante>();
                foreach (DataRow fila in data.Rows)
                {
                    estudiantes.Add(new Estudiante
                    {
                        Id = (int)(fila["id"]),
                        Nombre = fila["Nombre"].ToString(),
                        Apellido = fila["apellido"].ToString(),
                        Motivo = fila["motivo"].ToString()
                    });
                }
                _database.Context.Close();
                return estudiantes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }
        public List<Estudiante> EstudiantesReingresados()
        {
            try
            {
                DataTable data = new DataTable();
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "SELECT e.id , e.nombre, e.apellido, le.motivo FROM Estudiante e JOIN Log_Estudiante le ON e.id = le.id_estudiante WHERE e.activo = 1";
                data.Load(command.ExecuteReader());
                List<Estudiante> estudiantes = new List<Estudiante>();
                foreach (DataRow fila in data.Rows)
                {
                    estudiantes.Add(new Estudiante
                    {
                        Id = (int)(fila["id"]),
                        Nombre = fila["Nombre"].ToString(),
                        Apellido = fila["apellido"].ToString(),
                        Motivo = fila["motivo"].ToString()
                    });
                }
                _database.Context.Close();
                return estudiantes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }
        public bool ExisteIdEstudianteInactivo(int id)
        {
            var result = false;
            try
            {
                if (_database.Context.State != ConnectionState.Open) _database.Context.Open();

                var command = _database.Context.CreateCommand();
                command.CommandText = "SELECT COUNT(1) FROM Estudiante WHERE id = @id and activo=0";
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
        public bool ExisteIdEstudianteHabilitado(int id)
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
    }
}
