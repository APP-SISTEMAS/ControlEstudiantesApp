using Aplicacion.Models;
using System.Collections.Generic;
using Aplicacion.Config;

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
            return true;
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
