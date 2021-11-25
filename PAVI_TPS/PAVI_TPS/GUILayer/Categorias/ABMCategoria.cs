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

namespace TPS_PAVI.FormulariosABM.Categorias
{
    public partial class frmABMCategoria : Form
    {
        private FormMode formMode = FormMode.nuevo;

        private readonly CategoriaService oCategoriaService;
        private Categoria oCategoriaSelected;

        public frmABMCategoria()
        {
            InitializeComponent();
            oCategoriaService = new CategoriaService();
        }

        public enum FormMode
        {
            nuevo,          //Alta
            eliminar = 99,    //Baja
            modificar       //Modificarcion
        }

        private string IdCategoriaNueva()
        {
            int id = CategoriaDao.GetLastCategoryId();
            txtIdCategoria.Text = (id + 1).ToString();
            return txtIdCategoria.Text;
        }

        private void frmAgregarCategoria_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nueva categoria";
                        txtIdCategoria.Text = IdCategoriaNueva();
                        break;
                    }
                case FormMode.modificar:
                    {
                        this.Text = "Actualizar categoria";
                        // Recuperar categoria seleccionada en la grilla 
                        MostrarDatos();
                        txtNombreCat.Enabled = true;
                        txtDescripcionCat.Enabled = true;
                        break;
                    }

                case FormMode.eliminar:
                    {
                        MostrarDatos();
                        this.Text = "Eliminar Categoria";
                        txtNombreCat.Enabled = false;
                        txtDescripcionCat.Enabled = false;
                        break;
                    }
            }     

        }

        public void InicializarFormulario(FormMode op, Categoria categoriaSelected)
        {
            formMode = op;
            oCategoriaSelected = categoriaSelected;
        }
        private void MostrarDatos()
        {
            if (oCategoriaSelected != null)
            {
                txtIdCategoria.Text = oCategoriaSelected.IdCategoria.ToString();
                txtNombreCat.Text = oCategoriaSelected.NombreCategoria;
                txtDescripcionCat.Text = oCategoriaSelected.Descripcion;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        var oCategoria = new Categoria();
                        oCategoria.IdCategoria = int.Parse(txtIdCategoria.Text);
                        oCategoria.NombreCategoria = txtNombreCat.Text;
                        oCategoria.Descripcion = txtDescripcionCat.Text;

                        if (oCategoriaService.CrearCategoria(oCategoria))
                        {
                            MessageBox.Show("Categoria insertada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        
                                               
                        break;
                    }

                case FormMode.modificar:
                    {
                        oCategoriaSelected.IdCategoria = int.Parse(txtIdCategoria.Text);
                        oCategoriaSelected.NombreCategoria = txtNombreCat.Text;
                        oCategoriaSelected.Descripcion = txtDescripcionCat.Text;

                        if (oCategoriaService.ActualizarCategoria(oCategoriaSelected))
                        {
                            MessageBox.Show("Categoria actualizada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("Error al actualizar la categoria!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        break;
                    }

                case FormMode.eliminar:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar la categoria seleccionada?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oCategoriaService.EliminarCategoria(oCategoriaSelected))
                            {
                                MessageBox.Show("Categoria Eliminada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al eliminar la categoria!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
