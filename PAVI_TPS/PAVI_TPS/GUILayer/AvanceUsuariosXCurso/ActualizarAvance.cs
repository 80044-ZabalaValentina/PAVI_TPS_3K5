using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.BusinessLayer;
using TPS_PAVI.Entities;

namespace TPS_PAVI.GUILayer.AvanceUsuariosXCurso
{
    public partial class frmActualizarAvance : Form
    {
        private readonly AvanceUsuariosCursoService avanceUsuariosCursoService;
        private AvanceUsuario avanceUsuarioSelected;

        public frmActualizarAvance()
        {
            InitializeComponent();
            avanceUsuariosCursoService = new AvanceUsuariosCursoService();

        }

        private void ActualizarAvance_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        public void InicializarFormulario(AvanceUsuario avance_usuarioSelected)
        {
            avanceUsuarioSelected = avance_usuarioSelected;
        }

        private void MostrarDatos()
        {
            if (avanceUsuarioSelected != null)
            {
                txtCurso.Text = avanceUsuarioSelected.Curso.NombreCurso;
                txtUsuario.Text = avanceUsuarioSelected.Usuario.NombreUsuario;
                txtInicio.Text = avanceUsuarioSelected.Inicio.ToString();
                txtFin.Text = avanceUsuarioSelected.Fin.ToString();
                txtPorcAvance.Text = avanceUsuarioSelected.PorcentajeAvance.ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            avanceUsuarioSelected.PorcentajeAvance = Convert.ToInt32(txtPorcAvance.Text);
            if (avanceUsuariosCursoService.ActualizarPorcentaje(avanceUsuarioSelected))
            {
                MessageBox.Show("Porcentaje de avance actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
                MessageBox.Show("Error al actualizar el porcentaje de avance!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }    
}
