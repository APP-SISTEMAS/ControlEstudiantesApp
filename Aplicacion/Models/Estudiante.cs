using System;
using Aplicacion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Models
{
    public class Estudiante
    {
        public int Id { get; set;}  //Propiedades para la base de datos 
        public string Nombre { get; set;}
        public string Apellido { get; set;}
        public DateTime? FechaNacimiento { get; set;}
        public string Identificacion { get; set;}
        public char Genero { get; set;}
        public bool Ativo { get; set;}
        public string Telefono { get; set;}
        public string Departamento { get; set;}
        public string Municipio { get; set;}
        public string Direccion { get; set;}
        public string Correo { get; set;}
        public string TipoSangre { get; set;}
        public string Tutor { get; set;}
        
        public Estudiante(int id, string nombre, string apellido, DateTime? fechaNacimiento, string identificacion, char genero, bool ativo, string telefono, string departamento, string municipio, string direccion, string correo, string tipoSangre, string tutor)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Identificacion = identificacion;
            Genero = genero;
            Ativo = ativo;
            Telefono = telefono;
            Departamento = departamento;
            Municipio = municipio;
            Direccion = direccion;
            Correo = correo;
            TipoSangre = tipoSangre;
            Tutor = tutor;
        }
        public Estudiante()
        {
            this.Id = 0;
            this.Nombre = "";
            this.Apellido = "";
            this.FechaNacimiento = null;
            this.Identificacion = "";
            this.Genero = ' ';
            this.Ativo = false;
            this.Telefono = "";
            this.Departamento = "";
            this.Municipio = "";
            this.Direccion = "";
            this.Correo = "";
            this.TipoSangre = "";
            this.Tutor = "";

        }
    }
}
