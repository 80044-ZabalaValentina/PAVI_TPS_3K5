using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.AccesoADatos;
using TPS_PAVI.BusinessLayer;
using TPS_PAVI.Entidades;

namespace TPS_PAVI.FormulariosABMC.Objetivos
{
    public partial class frmABMObjetivo : Form
    {
        private FormMode formMode = FormMode.nuevo;

        private readonly ObjetivoService oObjetivoService;
        private Objetivo oObjetivoSelected;

        public frmABMObjetivo()
        {
            InitializeComponent();
            oObjetivoService = new ObjetivoService();
        }

        public enum FormMode
        {
            nuevo,          //Alta
            eliminar = 99,    //Baja
            modificar       //Modificarcion
        }

        private string IdObjetivoNuevo()
        {
            int id = CategoriaDao.GetLastCategoryId();
            txtId.Text = (id + 1).ToString();
            return txtId.Text;
        }

        private void AgregarObjetivo_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo objetivo";
                        txtId.Text = IdObjetivoNuevo();
                        break;
                    }
                case FormMode.modificar:
                    {
                        this.Text = "Actualizar objetivo";
                        // Recuperar objetivo seleccionado en la grilla 
                        MostrarDatos();
                        txtNombreCorto.Enabled = true;
                        txtNombreLargo.Enabled = true;
                        break;
                    }

                case FormMode.eliminar:
                    {
                        MostrarDatos();
                        this.Text = "Eliminar objetivo";
                        txtNombreCorto.Enabled = false;
                        txtNombreLargo.Enabled = false;
                        break;
                    }
            }
        }

        public void InicializarFormulario(FormMode op, Objetivo objetivoSelected)
        {
            formMode = op;
            oObjetivoSelected = objetivoSelected;
        }
        private void MostrarDatos()
        {
            if (oObjetivoSelected != null)
            {
                txtId.Text = oObjetivoSelected.IdObjetivo.ToString();
                txtNombreCorto.Text = oObjetivoSelected.NombreCortoObjetivo;
                txtNombreLargo.Text = oObjetivoSelected.NombreLargoObjetivo;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        var oObjetivo = new Objetivo();
                        oObjetivo.IdObjetivo = int.Parse(txtId.Text);
                        oObjetivo.NombreCortoObjetivo = txtNombreCorto.Text;
                        oObjetivo.NombreLargoObjetivo = txtNombreLargo.Text;

                        if (oObjetivoService.CrearObjetivo(oObjetivo))
                        {
                            MessageBox.Show("Objetivo insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }


                        break;
                    }

                case FormMode.modificar:
                    {
                        oObjetivoSelected.IdObjetivo = int.Parse(txtId.Text);
                        oObjetivoSelected.NombreCortoObjetivo = txtNombreCorto.Text;
                        oObjetivoSelected.NombreLargoObjetivo = txtNombreLargo.Text;

                        if (oObjetivoService.ActualizarObjetivo(oObjetivoSelected))
                        {
                            MessageBox.Show("Objetivo actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("Error al actualizar el objetivo!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    }

                case FormMode.eliminar:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el objetivo seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oObjetivoService.EliminarObjetivo(oObjetivoSelected))
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
