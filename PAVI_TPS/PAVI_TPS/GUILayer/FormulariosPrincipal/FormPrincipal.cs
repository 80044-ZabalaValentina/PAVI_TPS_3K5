using PAVI_TPS.GUILayer.Reportes;
using PAVI_TPS.GUILayer.Reportes.CantidadObjetivosPorCursos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.FormulariosABMC.Cursos;
using TPS_PAVI.FormulariosABMC.Objetivos;
using TPS_PAVI.GUILayer;

namespace TPS_PAVI.Formularios
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias formulario = new frmCategorias();
            formulario.ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCursos formulario = new FormCursos();
            formulario.ShowDialog();
        }

        private void objetivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormObjetivos formulario = new FormObjetivos();
            formulario.ShowDialog();
        }

        private void actualizarObjetivosDelCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmObjetivosCurso formulario = new frmObjetivosCurso();
            formulario.ShowDialog();
        }

        private void actualizarAvanceUsuariosPorCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAvanceUsuarioCurso formulario = new frmAvanceUsuarioCurso();
            formulario.ShowDialog();
        }

        private void listadoUsuariosPorCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuariosPorCurso formulario = new frmUsuariosPorCurso();
            formulario.ShowDialog();
        }

        private void cantidadObjetivosPorCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmObjetivosPorCurso formulario = new frmObjetivosPorCurso();
            formulario.ShowDialog();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
