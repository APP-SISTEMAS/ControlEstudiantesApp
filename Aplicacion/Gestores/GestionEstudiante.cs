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
            if (string.IsNullOrEmpty(estudiante.Nombre))
            {
                mensajeValidacion += "El campo nombre es requerido\n";
            }
            if (string.IsNullOrEmpty(estudiante.Apellido))
            {
                mensajeValidacion += "El campo apellido es requerido\n";
            }
            if (estudiante.FechaNacimiento == null)
            {
                mensajeValidacion += "El campo fecha de nacimiento es requerido\n";
            }
            if (string.IsNullOrEmpty(estudiante.Identificacion))
            {
                mensajeValidacion += "El campo identificacion es requerido\n";
            }
            //Mejorar este if
            if((estudiante.Identificacion).Length != 13)
            {
                mensajeValidacion += "El campo identificacion debe tener 13 digitos\n";
            }
            if (string.IsNullOrEmpty(estudiante.Genero.ToString()))
            {
                mensajeValidacion += "El campo genero es requerido\n";
            }
            if (string.IsNullOrEmpty(estudiante.Telefono))
            {
                mensajeValidacion += "El campo telefono es requerido\n";
            }
            if (string.IsNullOrEmpty(estudiante.Departamento))
            {
                mensajeValidacion += "El campo departamento es requerido\n";
            }
            if (string.IsNullOrEmpty(estudiante.Municipio))
            {
                mensajeValidacion += "El campo municipio es requerido\n";
            }
            if (string.IsNullOrEmpty(estudiante.Direccion))
            {
                mensajeValidacion += "El campo direccion es requerido\n";
            }
            if (string.IsNullOrEmpty(estudiante.Correo))
            {
                mensajeValidacion += "El campo correo es requerido\n";
            }
            if (string.IsNullOrEmpty(estudiante.TipoSangre))
            {
                mensajeValidacion += "El campo tipo de sangre es requerido\n";
            }
            if (string.IsNullOrEmpty(estudiante.Tutor))
            {
                mensajeValidacion += "El campo tutor es requerido\n";
            }

            return mensajeValidacion;
        }
        public Boolean ValidarIdentificacion(Estudiante estudiante)
        {
            return true;
        }
        public List<Departamento> ObtenerListaDepartamentos()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DataTable data = new DataTable();
            if (this._database.Context.State != ConnectionState.Open)
            {
                this._database.Context.Open();
            }
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
            // Imprimir la cabecera de la tabla
            Console.Write("------------------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-20} |", "Id", "Departamento"));
            Console.WriteLine("------------------------------");

            // Imprimir los datos
            foreach (var departamento in departamentos)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-20} |", departamento.Id, departamento.DepartamentoNombre));
            }
            Console.WriteLine("------------------------------\n");

            this._database.Context.Close();
            Console.ResetColor();
            return departamentos;
        }

        public List<Municipio> ObtenerListaMunicipios()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DataTable data = new DataTable();
            if (this._database.Context.State != ConnectionState.Open)
            {
                this._database.Context.Open();
            }
            var command = this._database.Context.CreateCommand();
            command.CommandText = "SELECT Municipio.id, Municipio.municipio, Municipio.id_departamento, Departamento.nombre AS departamento_nombre " +
                "FROM Municipio INNER JOIN Departamento ON Municipio.id_departamento = Departamento.id";
            data.Load(command.ExecuteReader());
            List<Municipio> municipios = new List<Municipio>();

            foreach (DataRow fila in data.Rows)
            {
                municipios.Add(new Municipio
                {
                    Id = (int)(fila["Id"]),
                    MunicipioNombre = fila["Municipio"].ToString(),
                    DepartamentoCodigo = (int)(fila["id_departamento"]),
                    DepartamentoNombre = fila["departamento_nombre"].ToString()
                });
            }
            // Imprimir la cabecera de la tabla
            Console.Write("---------------------------------------------------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-20} | {2,-8} | {3,-20}|", "Id", "Municipio", "Id_depto", "Departamento"));
            Console.WriteLine("---------------------------------------------------------------");

            // Imprimir los datos
            foreach (var municipio in municipios)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-20} | {2,-8} | {3,-20}|", municipio.Id, municipio.MunicipioNombre, municipio.DepartamentoCodigo, municipio.DepartamentoNombre));
            }
            Console.WriteLine("---------------------------------------------------------------\n");

            this._database.Context.Close();
            Console.ResetColor();
            return municipios;
        }

        public List<TipoSangre> ObtenerListaTipoSangre()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DataTable data = new DataTable();
            if (this._database.Context.State != ConnectionState.Open)
            {
                this._database.Context.Open();
            }
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
            // Imprimir la cabecera de la tabla
            Console.Write("--------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-10}|", "Id", "Tipo Sangre"));
            Console.WriteLine("--------------------");

            // Imprimir los datos
            foreach (var sangre in tiposangre)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10} |", sangre.Id, sangre.SangreNombre));
            }
            Console.WriteLine("--------------------\n");

            this._database.Context.Close();
            Console.ResetColor();
            return tiposangre;
        }

        public Boolean Registrar(Estudiante estudiante)
        {
            var result = false;
            try
            {
                if (_database.Context.State != ConnectionState.Open)
                {
                    _database.Context.Open();
                }
                var command = _database.Context.CreateCommand();
                command.CommandText = "INSERT INTO Estudiante (nombre, apellido, fecha_nacimiento, identidad, genero, activo, telefono, id_departamento, id_municipio, direccion, correo, id_tipo_sangre, tutor) " +
                    "VALUES (@nombre, @apellido, @fecha_nacimiento, @identidad, @genero, @activo, @telefono, @id_departamento, @id_municipio, @direccion, @correo, @id_tipo_sangre, @tutor)";
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
        public Boolean Actualizar(Estudiante estudiante, int id)
        {
            return true;
        }
        public Estudiante ObtenerInformacionEstudiante(int id)
        {
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
            var command = _database.Context.CreateCommand();
            command.CommandText = "SELECT e.id, e.nombre, e.apellido, " +
                "e.fecha_nacimiento, e.identidad, e.genero, " +
                "e.activo, e.telefono, d.nombre AS departamento, " +
                "m.municipio AS municipio, e.direccion, e.correo, " +
                "ts.nombre AS tipo_sangre, e.tutor " +
                "FROM Estudiante e JOIN Departamento d ON e.id_departamento = d.id JOIN Municipio m ON e.id_municipio = m.id JOIN Tipo_Sangre ts ON e.id_tipo_sangre = ts.id " +
                "WHERE e.id = @id";
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ficha Estudiantil");
            Console.WriteLine("Id: " + estudiante.Id);
            Console.WriteLine("Nombre: " + estudiante.Nombre);
            Console.WriteLine("Apellido: " + estudiante.Apellido);
            Console.WriteLine("Fecha de Nacimiento: " + estudiante.FechaNacimiento);
            Console.WriteLine("Identificacion: " + estudiante.Identificacion);
            Console.WriteLine("Genero: " + estudiante.Genero);
            Console.WriteLine("Activo: " + estudiante.Activo);
            Console.WriteLine("Telefono: " + estudiante.Telefono);
            Console.WriteLine("Departamento: " + estudiante.Departamento);
            Console.WriteLine("Municipio: " + estudiante.Municipio);
            Console.WriteLine("Direccion: " + estudiante.Direccion);
            Console.WriteLine("Correo: " + estudiante.Correo);
            Console.WriteLine("Tipo de Sangre: " + estudiante.TipoSangre);
            Console.WriteLine("Tutor: " + estudiante.Tutor);
            _database.Context.Close();
            Console.ResetColor();
            return estudiante;
        }
        public List<Estudiante> ObtenerListaEstudiantes()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DataTable data = new DataTable();
            if (_database.Context.State != ConnectionState.Open)
            {
                _database.Context.Open();
            }
            var command = _database.Context.CreateCommand();
            command.CommandText = "select id, Nombre,apellido from estudiante";
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
    }
}