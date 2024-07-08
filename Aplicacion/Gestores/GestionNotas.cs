using Aplicacion.Models;
using System.Collections.Generic;
using Aplicacion.Config;
using System;
using System.Data;

namespace Aplicacion.Gestores
{
    public class GestionNotas
    {
        private Database _database;
        public GestionNotas()
        {
            _database = new Database();
        }
        public bool Registrar(Nota nota)
        {
            var result = false;
            try
            {
                if (_database.Context.State != ConnectionState.Open)
                {
                    _database.Context.Open();
                }
                var command = _database.Context.CreateCommand();
                command.CommandText = "INSERT INTO Notas (IdEstudiante, IdAsignatura, Nota1, Nota2, Nota3, Nota4) VALUES (@IdEstudiante, @IdAsignatura, @Nota1, @Nota2, @Nota3, @Nota4)";
                command.Parameters.AddWithValue("@IdEstudiante", nota.IdEstudiante);
                command.Parameters.AddWithValue("@IdAsignatura", nota.IdAsignatura);
                command.Parameters.AddWithValue("@Nota1", nota.Nota1);
                command.Parameters.AddWithValue("@Nota2", nota.Nota2);
                command.Parameters.AddWithValue("@Nota3", nota.Nota3);
                command.Parameters.AddWithValue("@Nota4", nota.Nota4);                
                command.ExecuteNonQuery();
                CalcularPromedioPorClase(nota);
                result = true;
                _database.Context.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return result;
        }

        public bool ActualizarNota(Nota nota)
        {
            return true;
        }
        public List<Nota> MostrarNotasGenerales()
        {
            return new List<Nota>();
        }
        public List<Nota> MostrarNotasPorEstudiante(int idEstudiante)
        {
            return new List<Nota>();
        }

        public List<Nota> MostrarNotasPorClase(int idAsignatura)
        {
            return new List<Nota>();
        }
        public bool CalcularPromedioPorEstudiante()
        {
            return false;
        }
        public void CalcularPromedioPorClase(Nota nota)
        {
            if(_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
            var command = _database.Context.CreateCommand();
            command.CommandText = "SELECT Nota1, Nota2, Nota3, Nota4 FROM Notas WHERE IdEstudiante = @IdEstudiante AND IdAsignatura = @IdAsignatura";
            command.Parameters.AddWithValue("@IdEstudiante", nota.IdEstudiante);
            command.Parameters.AddWithValue("@IdAsignatura", nota.IdAsignatura);
            var reader = command.ExecuteReader();
            if(reader.Read())
            {
                var nota1 = reader.GetFloat(0);
                var nota2 = reader.GetFloat(1);
                var nota3 = reader.GetFloat(2);
                var nota4 = reader.GetFloat(3);
                var promedio = (nota1 + nota2 + nota3 + nota4) / 4;
                var aprobado = promedio >= 65&& promedio<=100 ? true : false;
                if(_database.Context.State != ConnectionState.Open)
                {
                    _database.Context.Open();
                }
                command.CommandText = "UPDATE Notas SET Promedio = @Promedio, Aprobado = @Aprobado WHERE IdEstudiante = @IdEstudiante AND IdAsignatura = @IdAsignatura";
                command.Parameters.AddWithValue("@Promedio", promedio);
                command.Parameters.AddWithValue("@Aprobado", aprobado);
                command.ExecuteNonQuery();
            }
        }
    }
}
