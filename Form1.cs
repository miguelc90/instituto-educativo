using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstitutoEducativo
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            Configuracion.Conexion establecer_conexion = new Configuracion.Conexion();
            establecer_conexion.EnlaceConexion();
        }

        private void btnCerrarApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Formularios.FormAlumnos ir_alumnos = new Formularios.FormAlumnos();
            ir_alumnos.Show();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Formularios.FormCursos ir_cursos = new Formularios.FormCursos();
            ir_cursos.Show();
        }
    }
}
