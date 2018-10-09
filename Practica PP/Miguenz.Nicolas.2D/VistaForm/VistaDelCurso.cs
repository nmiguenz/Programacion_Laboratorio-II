using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace VistaForm
{
    public partial class VistaDelCurso : Form
    {
        Curso curso;
        public VistaDelCurso()
        {
            InitializeComponent();
            cmbDivisionCurso.DataSource = Enum.GetValues(typeof(Divisiones));            cmbDivision.DataSource = Enum.GetValues(typeof(Divisiones));            this.nudAnio.Value = 0;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (this.nudAnioCurso.Value > 0 && this.txtNombreProfesor != null && this.txtApellidoProfesor != null
                && this.txtDocumentoProfe != null)
            {
                Divisiones division;
                Enum.TryParse<Divisiones>(cmbDivisionCurso.SelectedValue.ToString(), out division);
                Profesor profesor = new Profesor(this.txtNombreProfesor.Text, this.txtApellidoProfesor.Text,
                    this.txtDocumentoProfe.Text, this.dtpFechaIngreso.Value);

                this.curso = new Curso((short)this.nudAnioCurso.Value, division, profesor);

                this.nudAnioCurso.Value = 0;
                this.txtNombreProfesor.Clear();
                this.txtApellidoProfesor.Clear();
                this.txtDocumentoProfe.Clear();
            }
            else
                MessageBox.Show("Debe completar todos los campos antes de crear", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.rtbDatos.Clear();
            if (curso is null)
                MessageBox.Show("Debe crear un curso primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                this.rtbDatos.Text = (string)this.curso;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Divisiones division;
            Enum.TryParse<Divisiones>(cmbDivision.SelectedValue.ToString(), out division);
            Alumno alumno = new Alumno(this.txtNombre.Text, this.txtApellido.Text, this.txtDocumento.Text,
                                       (short)this.nudAnio.Value, division);
            if (this.curso is null)
                MessageBox.Show("DEbe crear un curso primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                this.curso += alumno;
        }
    }
}
