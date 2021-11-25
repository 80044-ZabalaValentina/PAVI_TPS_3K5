using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.BusinessLayer;
using TPS_PAVI.Entities;

namespace TPS_PAVI.GUILayer.ObjetivosPorCurso
{
    public partial class frmABMObjetivosCurso : Form
    {
        private FormMode formMode = FormMode.modificar;

        private readonly ObjetivosCursoService oObjetivosCursoService;
        private ObjetivosCurso oObjetivosCursoSelected;
        private int Id_curso;

        public frmABMObjetivosCurso()
        {
            InitializeComponent();
            oObjetivosCursoService = new ObjetivosCursoService();
            Id_curso = new int();

        }
        public enum FormMode
        {
            eliminar = 99,    //Baja
            modificar       //Modificarcion
        }

        private void ABMObjetivosCurso_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.modificar:
                    {
                        this.Text = "Actualizar objetivo";
                        // Recuperar categoria seleccionada en la grilla 
                        MostrarDatos();
                        txtPuntos.Enabled = true;
                        break;
                    }

                case FormMode.eliminar:
                    {
                        MostrarDatos();
                        this.Text = "Eliminar Objetivo";
                        txtPuntos.Enabled = false;
                        break;
                    }
            }

        }

        public void InicializarFormulario(FormMode op, ObjetivosCurso objetivoCursoSelected, int idcurso)
        {
            formMode = op;
            oObjetivosCursoSelected = objetivoCursoSelected;
            Id_curso = idcurso;
        }

        private void MostrarDatos()
        {
            if (oObjetivosCursoSelected != null)
            {
                txtIdCurso.Text = Id_curso.ToString();
                txtObjetivo.Text = oObjetivosCursoSelected.Objetivo.NombreLargoObjetivo.ToString();
                txtPuntos.Text = oObjetivosCursoSelected.Puntos.ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.modificar:
                    {
                        oObjetivosCursoSelected.Puntos = int.Parse(txtPuntos.Text);

                        if (oObjetivosCursoService.ActualizarPuntos(oObjetivosCursoSelected))
                        {
                            MessageBox.Show("Puntos actualizados!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("Error al actualizar los puntos!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    }

                case FormMode.eliminar:
                    {
                        if (MessageBox.Show("Seguro que desea eliminar el objetivo seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oObjetivosCursoService.EliminarObjetivo(oObjetivosCursoSelected))
                            {
                                MessageBox.Show("Objetivo Eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al eliminar el objetivo!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }
        }
    }
}
