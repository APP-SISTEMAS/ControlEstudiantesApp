using Aplicacion.Models;
using System.Collections.Generic;
using Aplicacion.Config;
using System;

namespace Aplicacion.Gestores
{
    public class GestionAsignaturas
    {
        private Database _database;
        public GestionAsignaturas()
        {
            _database = new Database();
        }
        public bool Agregar(Asignatura asignatura)
        {
            var result = false;
            try
                {
                if (_database.Context.State != System.Data.ConnectionState.Open)
                {
                    _database.Context.Open();
                }
                var command = _database.Context.CreateCommand();
                command.CommandText = "insert into Asignatura(nombre,activo) values(@nombre,@activo)";
                command.Parameters.AddWithValue("@nombre", asignatura.AsignaturaNombre);
                command.Parameters.AddWithValue("@activo", asignatura.Activo);
                command.ExecuteNonQuery();
                result = true;
                _database.Context.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("Error: "+ex);
            }
            return result;
        }
        public bool Modificar(Asignatura asignatura)
        {
            return true;
        }
        public bool Eliminar(Asignatura asignatura)
        {
            return false;
        }
        public bool VerificarExistencia(Asignatura asignatura)
        {
            return true;
        }
        public List<Asignatura> ListarAsignaturas()
        {
            if (_database.Context.State != System.Data.ConnectionState.Open)
            {
                _database.Context.Open();
            }
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
    }
}
