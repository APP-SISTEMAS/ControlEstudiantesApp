using Aplicacion.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Aplicacion.Config;
using System;
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
        public string Validar(Estudiante estudiante)
        {
            return "";
        }
        public Boolean ValidarIdentificacion(Estudiante estudiante)
        {
            return true;
        }
        public List<Departamento> ObtenerListaDepartamentos()
        {
            return new List<Departamento>();
        }


        public List<Municipio> ObtenerListaMunicipios()
        {
            DataTable data = new DataTable();
            if (this._database.Context.State != ConnectionState.Open)
            {
                this._database.Context.Open();
            }
            var command = this._database.Context.CreateCommand();
            command.CommandText = "SELECT Municipio.id, Municipio.municipio, Municipio.id_departamento, Departamento.nombre AS departamento_nombre " +
                "FROM Municipio INNER JOIN Departamento ON Municipio.id_departamento = Departamento.id;\r\n";
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
            Console.Write("-------------------------------------------------------------");
            Console.WriteLine(string.Format("\n{0,-5} | {1,-20} | {2,-8} | {3,-20}|", "Id", "Municipio", "Id_depto", "Departamento"));
            Console.WriteLine("-------------------------------------------------------------");

            // Imprimir los datos
            foreach (var municipio in municipios)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-20} | {2,-8} | {3,-20}|", municipio.Id, municipio.MunicipioNombre, municipio.DepartamentoCodigo, municipio.DepartamentoNombre));
            }
            Console.WriteLine("-------------------------------------------------------------\n");

            this._database.Context.Close();
            return municipios;
        }
        public List<TipoSangre> ObtenerListaTipoSangre()
        {
            return new List<TipoSangre>();
        }
        public Boolean Registrar(Estudiante estudiante)
        {
            return true;
        }
        public Boolean Actualizar(Estudiante estudiante, int id)
        {
            return true;
        }
        public List<Estudiante> ObtenerInformacionEstudiante(int id)
        {
            return new List<Estudiante>();
        }
        public List<Estudiante> Listar(Estudiante estudiante)
        {
            return new List<Estudiante>();
        }
    }
}

