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
            var estudiantes = this._gestionEstudiante.ObtenerListaEstudiantes();
            foreach (var item in estudiantes)
            {
                dataGridView1.Rows.Add(item.Id, item.Nombre, item.Identidad, item.FechaNacimiento, item.Activo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var estudiante = new Estudiante();
            estudiante.Nombre = txtNombre.Text;
            estudiante.Identidad = txtIdentidad.Text;
            estudiante.FechaNacimiento = txtFechaNacimiento.Value;

            var msjValidacion = _gestionEstudiante.Validar(estudiante);
            if (msjValidacion != "") {
                MessageBox.Show(msjValidacion, "Aceptar");
                return;
            }

            var result = false;
            try
            {
                result = _gestionEstudiante.Guardar(estudiante);
                if (result) MessageBox.Show("Los datos se han guardado!!");
            }
            catch (Exception err)
            {
                MessageBox.Show("Error" + err);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtId.Text);
            var estudiante = _gestionEstudiante.ObtenerDatosEstudiante(id);
            txtId.Text = estudiante.Id.ToString();
            txtNombre.Text = estudiante.Nombre.ToString();
            txtIdentidad.Text = estudiante.Identidad.ToString();
            txtFechaNacimiento.Value = estudiante.FechaNacimiento;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<int> temperaturas = new List<int>();

            temperaturas.Add(2);
            temperaturas.Add(100);
            temperaturas.Add(20);
            temperaturas.Add(30);
            temperaturas.Add(40);
            temperaturas.Add(50);

            List<String> dias = new List<String>();
            dias.Add("Lunes");
            dias.Add("Martes");
            dias.Add("Miercoles");
            dias.Add("Jueves");


        }
    }
}
