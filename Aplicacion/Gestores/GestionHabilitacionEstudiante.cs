﻿using Aplicacion.Config;
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
            Console.ForegroundColor = ConsoleColor.Green;
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
            // Imprimir la cabecera de la tabla
            Console.Write("---------------------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-10} | {2,-10} |", "Id", "Nombre", "Apellido"));
            Console.WriteLine("---------------------------------");

            // Imprimir los datos
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-10} |", estudiante.Id, estudiante.Nombre, estudiante.Apellido));
            }
            Console.WriteLine("---------------------------------\n");

            _database.Context.Close();
            Console.ResetColor();
            return estudiantes;
        }
        public List<Estudiante> EstudiantesDeshabilitados()
        {
            Console.ForegroundColor = ConsoleColor.Green;
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
            // Imprimir la cabecera de la tabla
            Console.Write("------------------------------------------------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-10} | {2,-10} | {3,-25} |", "Id", "Nombre", "Apellido", "Motivo"));
            Console.WriteLine("------------------------------------------------------------");

            // Imprimir los datos
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-10} | {3,-25} |", estudiante.Id, estudiante.Nombre, estudiante.Apellido, estudiante.Motivo));
            }

            Console.WriteLine("------------------------------------------------------------\n");


            _database.Context.Close();
            Console.ResetColor();
            return estudiantes;
        }
        public List<Estudiante> EstudiantesReingresados()
        {
            Console.ForegroundColor = ConsoleColor.Green;
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
            // Imprimir la cabecera de la tabla
            Console.Write("------------------------------------------------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-10} | {2,-10} | {3,-25} |", "Id", "Nombre", "Apellido", "Motivo"));
            Console.WriteLine("------------------------------------------------------------");

            // Imprimir los datos
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-10} | {3,-25} |", estudiante.Id, estudiante.Nombre, estudiante.Apellido, estudiante.Motivo));
            }

            Console.WriteLine("------------------------------------------------------------\n");


            _database.Context.Close();
            Console.ResetColor();
            return estudiantes;
        }
    }
}
