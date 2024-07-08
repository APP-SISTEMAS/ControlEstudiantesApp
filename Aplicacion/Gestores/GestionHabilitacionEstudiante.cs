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

        public Boolean Deshabilitar(string motivo, int id)
        {
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
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
        public Boolean Habilitar(string motivo, int id)
        {
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
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
        public List<Estudiante> EstudiantesHabilitados()
        {
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
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
        public List<Estudiante> EstudiantesDeshabilitados()
        {
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
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
        public List<Estudiante> EstudiantesReingresados()
        {
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
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
    }
}
