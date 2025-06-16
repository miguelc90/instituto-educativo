using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstitutoEducativo.Formularios
{
    public partial class FormAlumnos : Form
    {
        public FormAlumnos()
        {
            InitializeComponent();

            Controlador.ControladorAlumnos alumnos = new Controlador.ControladorAlumnos();
            alumnos.MostrarAlumnos(dtgvlistadoalumnos);
        }

        public void LimpiarCampos()
        {
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtdni.Text = "";
            txttel.Text = "";
            txtid.Text = "";
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuPrincipal ir_menu_principal = new MenuPrincipal();
            ir_menu_principal.Show();
        }

        private void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            Controlador.ControladorAlumnos alumno = new Controlador.ControladorAlumnos();
            alumno.AgregarAlumno(txtnombre, txtapellido, txtdni, txttel, dtpAlumnos);
            alumno.MostrarAlumnos(dtgvlistadoalumnos);
            LimpiarCampos();
        }

        private void dtgvlistadoalumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Controlador.ControladorAlumnos alumno = new Controlador.ControladorAlumnos();
            alumno.Seleccionar(dtgvlistadoalumnos, txtid, txtnombre, txtapellido, txtdni, dtpAlumnos, txttel);
        }

        private void btnModificarAlumno_Click(object sender, EventArgs e)
        {
            Controlador.ControladorAlumnos alumno = new Controlador.ControladorAlumnos();
            alumno.ModificarAlumno(txtid, txtnombre, txtapellido, txtdni, dtpAlumnos, txttel);
            alumno.MostrarAlumnos(dtgvlistadoalumnos);
            LimpiarCampos();
        }

        private void btnEliminarAlumno_Click(object sender, EventArgs e)
        {
            Controlador.ControladorAlumnos alumno = new Controlador.ControladorAlumnos();
            alumno.EliminarAlumno(txtid);
            alumno.MostrarAlumnos(dtgvlistadoalumnos);
            LimpiarCampos();
        }
    }
}
