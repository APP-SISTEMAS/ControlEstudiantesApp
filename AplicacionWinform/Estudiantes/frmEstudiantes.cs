using Aplicacion.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionWinform.Estudiantes
{
    public partial class frmEstudiantes : Form
    {

        private GestionEstudiante _gestionEstudiante;

        public frmEstudiantes()
        {
            InitializeComponent();
            _gestionEstudiante = new GestionEstudiante();
        }



        private void frmEstudiantes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var estudiante = new Estudiante();
            estudiante.Nombre = txtNombre.Text;
            estudiante.Identidad = txtIdentidad.Text;
            estudiante.FechaNacimiento = txtFechaNacimiento.Value;
            var result = _gestionEstudiante.Guardar(estudiante);
            if (result) MessageBox.Show("Los datos se han guardado!!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var  id = Convert.ToInt32(txtId.Text);
            var estudiante = _gestionEstudiante.ObtenerDatosEstudiante(id);
            txtId.Text = estudiante.Id.ToString();
            txtNombre.Text = estudiante.Nombre.ToString();
            txtIdentidad.Text = estudiante.Identidad.ToString();
            txtFechaNacimiento.Value= estudiante.FechaNacimiento;
        }
    }
}
