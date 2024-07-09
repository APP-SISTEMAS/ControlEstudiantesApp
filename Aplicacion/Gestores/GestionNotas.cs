using Aplicacion.Config;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

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
                command.CommandText = "INSERT INTO Notas (Id_Estudiante, Id_Asignatura, Nota1, Nota2, Nota3, Nota4) VALUES (@Id_Estudiante, @Id_Asignatura, @Nota1, @Nota2, @Nota3, @Nota4)";
                command.Parameters.AddWithValue("@Id_Estudiante", nota.IdEstudiante);
                command.Parameters.AddWithValue("@Id_Asignatura", nota.IdAsignatura);
                command.Parameters.AddWithValue("@Nota1", nota.Nota1);
                command.Parameters.AddWithValue("@Nota2", nota.Nota2);
                command.Parameters.AddWithValue("@Nota3", nota.Nota3);
                command.Parameters.AddWithValue("@Nota4", nota.Nota4);
                command.ExecuteNonQuery();
                result = true;
                _database.Context.Close();
                CalcularPromedioPorClase(nota);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return result;
        }
        public void CalcularPromedioPorClase(Nota nota)
        {
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
            var command = _database.Context.CreateCommand();
            command.CommandText = "SELECT Nota1, Nota2, Nota3, Nota4 FROM Notas WHERE Id_Estudiante = @Id_Estudiante AND Id_Asignatura = @Id_Asignatura";
            command.Parameters.AddWithValue("@Id_Estudiante", nota.IdEstudiante);
            command.Parameters.AddWithValue("@Id_Asignatura", nota.IdAsignatura);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var nota1 = reader.GetDecimal(0);
                var nota2 = reader.GetDecimal(1);
                var nota3 = reader.GetDecimal(2);
                var nota4 = reader.GetDecimal(3);
                var promedio = (nota1 + nota2 + nota3 + nota4) / 4;
                var aprobado = promedio >= 65 && promedio <= 100 ? true : false;
                _database.Context.Close();
                if (_database.Context.State != ConnectionState.Open)
                {
                    _database.Context.Open();
                }
                command.CommandText = "UPDATE Notas SET Promedio = @Promedio, Aprobado = @Aprobado WHERE Id_Estudiante = @Id_Estudiante AND Id_Asignatura = @Id_Asignatura";
                command.Parameters.AddWithValue("@Promedio", promedio);
                command.Parameters.AddWithValue("@Aprobado", aprobado);
                command.ExecuteNonQuery();
            }
            _database.Context.Close();
        }
        public bool ActualizarNota(Nota nota, int idEstudiante, int idAsignatura)
        {
            var result = false;
            try
            {
                if (_database.Context.State != ConnectionState.Open)
                {
                    _database.Context.Open();
                }
                var command = _database.Context.CreateCommand();
                command.CommandText = "UPDATE Notas SET Nota1 = @Nota1, Nota2 = @Nota2, Nota3 = @Nota3, Nota4 = @Nota4 WHERE Id_Estudiante = @Id_Estudiante AND Id_Asignatura = @Id_Asignatura";
                command.Parameters.AddWithValue("@Nota1", nota.Nota1);
                command.Parameters.AddWithValue("@Nota2", nota.Nota2);
                command.Parameters.AddWithValue("@Nota3", nota.Nota3);
                command.Parameters.AddWithValue("@Nota4", nota.Nota4);
                command.Parameters.AddWithValue("@Id_Estudiante", idEstudiante);
                command.Parameters.AddWithValue("@Id_Asignatura", idAsignatura);
                command.ExecuteNonQuery();
                CalcularPromedioPorClase(nota);
                result = true;
                _database.Context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return result;
        }

        public Nota ObtenerNotasPorActualizar(int idEstudiante, int idAsignatura)
        {
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
            var command = _database.Context.CreateCommand();
            command.CommandText = "SELECT Nota1, Nota2, Nota3, Nota4 FROM Notas WHERE Id_Estudiante = @Id_Estudiante AND Id_Asignatura = @Id_Asignatura";
            command.Parameters.AddWithValue("@Id_Estudiante", idEstudiante);
            command.Parameters.AddWithValue("@Id_Asignatura", idAsignatura);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var nota = new Nota();
                nota.Nota1 = reader.GetDecimal(0);
                nota.Nota2 = reader.GetDecimal(1);
                nota.Nota3 = reader.GetDecimal(2);
                nota.Nota4 = reader.GetDecimal(3);
                _database.Context.Close();
                return nota;
            }
            return null;
        }

        //Muestra del consolidado que solo mostrara el nombre del estudiante, su id y el promedio general de todas sus clases
        // y si esta aprobado o no
        public List<Nota> ObtenerPromedioGeneralEstudiante()
        {
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
            var command = _database.Context.CreateCommand();
            command.CommandText = "select E.id,E.nombre,E.apellido,Cast(ROUND(SUM(N.promedio) / COUNT(N.id_asignatura),2)as decimal(5,2))as promedio, CASE WHEN(SUM(N.promedio)/ COUNT(N.id_asignatura) >= 65 AND SUM(N.promedio)/ COUNT(N.id_asignatura) <= 100) THEN 1 ELSE 0 END as aprobado from Notas N inner join Estudiante E on E.id = N.id_estudiante inner join Asignatura A on A.id = N.id_asignatura group by E.id,E.nombre,E.apellido";            
            data.Load(command.ExecuteReader());
            List<Nota> notas = new List<Nota>();

            foreach (DataRow item in data.Rows)
            {
                Nota nota = new Nota();
                nota.IdEstudiante = Convert.ToInt32(item["id"]);
                nota.NombreEstudiante = item["nombre"].ToString();
                nota.ApellidoEstudiante = item["apellido"].ToString();
                nota.Promedio = Convert.ToDecimal(item["promedio"]);
                nota.Aprobado = Convert.ToBoolean(item["aprobado"]);
                notas.Add(nota);
            }
            _database.Context.Close();
            return notas;
        }
        public List<Nota> ObtenerNotasPorEstudiante(int idEstudiante)
        {
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
            var command = _database.Context.CreateCommand();
            command.CommandText = "select E.id,E.nombre,E.apellido ,A.nombre as nombreAsignatura,N.nota1,N.nota2,N.nota3,N.nota4,N.promedio,N.aprobado " +
                "from Notas N inner join Estudiante E on E.id=N.id_estudiante inner join Asignatura A on " +
                "A.id=N.id_asignatura where N.id_estudiante=@idEstudiante";
            command.Parameters.AddWithValue("@idEstudiante", idEstudiante);
            data.Load(command.ExecuteReader());
            List<Nota> notas = new List<Nota>();

            foreach (DataRow item in data.Rows)
            {
                Nota nota = new Nota();
                nota.IdEstudiante = Convert.ToInt32(item["id"]);
                nota.NombreEstudiante = item["nombre"].ToString();
                nota.ApellidoEstudiante = item["apellido"].ToString();
                nota.NombreAsignatura = item["nombreAsignatura"].ToString();
                nota.Nota1 = Convert.ToDecimal(item["nota1"]);
                nota.Nota2 = Convert.ToDecimal(item["nota2"]);
                nota.Nota3 = Convert.ToDecimal(item["nota3"]);
                nota.Nota4 = Convert.ToDecimal(item["nota4"]);
                nota.Promedio = Convert.ToDecimal(item["promedio"]);
                nota.Aprobado = Convert.ToBoolean(item["aprobado"]);
                notas.Add(nota);
            }
            _database.Context.Close();
            return notas;
        }
        public List<Nota> ObtenerNotasPorClase(int idAsignatura)
        {
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
            var command = _database.Context.CreateCommand();
            command.CommandText = "select E.id,E.nombre,E.apellido ,A.nombre as nombreAsignatura,N.nota1,N.nota2,N.nota3,N.nota4,N.promedio,N.aprobado " +
                "from Notas N inner join Estudiante E on E.id=N.id_estudiante inner join Asignatura A on A.id=N.id_asignatura where N.id_asignatura=@idAsignatura order by id asc";
            command.Parameters.AddWithValue("@idAsignatura", idAsignatura);
            data.Load(command.ExecuteReader());
            List<Nota> notas = new List<Nota>();

            foreach (DataRow item in data.Rows)
            {
                Nota nota = new Nota();
                nota.IdEstudiante = Convert.ToInt32(item["id"]);
                nota.NombreEstudiante = item["nombre"].ToString();
                nota.ApellidoEstudiante = item["apellido"].ToString();
                nota.NombreAsignatura = item["nombreAsignatura"].ToString();
                nota.Nota1 = Convert.ToDecimal(item["nota1"]);
                nota.Nota2 = Convert.ToDecimal(item["nota2"]);
                nota.Nota3 = Convert.ToDecimal(item["nota3"]);
                nota.Nota4 = Convert.ToDecimal(item["nota4"]);
                nota.Promedio = Convert.ToDecimal(item["promedio"]);
                nota.Aprobado = Convert.ToBoolean(item["aprobado"]);
                notas.Add(nota);
            }
            _database.Context.Close();
            return notas;
        }
    }
}
