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

namespace TPS_PAVI.FormulariosABMC.Cursos
{
    public partial class frmABMCurso : Form
    {
        private FormMode formMode = FormMode.nuevo;

        private readonly CursoService oCursoService;
        private readonly CategoriaService oCategoriaService;
        private Curso oCursoSelected;

        public frmABMCurso()
        {
            InitializeComponent();
            oCursoService = new CursoService();
            oCategoriaService = new CategoriaService();
        }
        public enum FormMode
        {
            nuevo,          //Alta
            eliminar = 99,    //Baja
            modificar       //Modificacion
        }

        private string IdCursoNuevo()
        {
            int id = CursoDao.GetLastCursoId();
            txtIdCurso.Text = (id + 1).ToString();
            return txtIdCurso.Text;
        }
        private void AgregarCurso_Load(object sender, EventArgs e)
        {
            txtIdCurso.Text = IdCursoNuevo();
            LlenarCombo(cmbCategoria, oCategoriaService.ObtenerTodos(), "NombreCategoria", "IdCategoria");
           
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo curso";
                        break;
                    }
                case FormMode.modificar:
                    {
                        this.Text = "Actualizar curso";
                        // Recuperar curso seleccionada en la grilla 
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtDescripcion.Enabled = true;
                        txtFechaVigencia.Enabled = true;
                        cmbCategoria.Enabled = true;
  
                        break;
                    }

                case FormMode.eliminar:
                    {
                        MostrarDatos();
                        this.Text = "Eliminar Categoria";
                        txtNombre.Enabled = false;
                        txtDescripcion.Enabled = false;
                        txtFechaVigencia.Enabled = false;
                        cmbCategoria.Enabled = false;
                        break;
                    }
            }
        }

        public void InicializarFormulario(FormMode op, Curso cursoSelected)
        {
            formMode = op;
            oCursoSelected = cursoSelected;
        }
        private void MostrarDatos()
        {
            if (oCursoSelected != null)
            {
                txtIdCurso.Text = oCursoSelected.IdCurso.ToString();
                txtNombre.Text = oCursoSelected.NombreCurso;
                txtDescripcion.Text = oCursoSelected.Descripcion;
                string dia = oCursoSelected.FechaVigencia.Day.ToString();
                if (dia.Length == 1)
                {
                    dia = "0" + dia;
                }
                string mes = oCursoSelected.FechaVigencia.Month.ToString();
                if (mes.Length == 1)
                {
                    mes = "0" + mes;
                }
                string año = oCursoSelected.FechaVigencia.Year.ToString();
                txtFechaVigencia.Text = dia + mes + año;
                //txtFechaVigencia.Text = oCursoSelected.FechaVigencia.ToString();
                cmbCategoria.Text = oCursoSelected.Categoria_Curso.NombreCategoria;
            }
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private bool ExisteCurso()
        {
            return oCursoService.ObtenerCurso(txtNombre.Text) != null;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        if (ExisteCurso() == false)
                        {
                            var oCurso = new Curso();
                            oCurso.IdCurso = int.Parse(txtIdCurso.Text);
                            oCurso.NombreCurso = txtNombre.Text;
                            oCurso.Descripcion = txtDescripcion.Text;
                            oCurso.FechaVigencia = DateTime.Parse(txtFechaVigencia.Text);
                            oCurso.Categoria_Curso = new Categoria();
                            oCurso.Categoria_Curso.IdCategoria = (int)cmbCategoria.SelectedValue;

                            if (oCursoService.CrearCurso(oCurso))
                            {
                                MessageBox.Show("Curso insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else
                            MessageBox.Show("Curso encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.modificar:
                    {
                        oCursoSelected.IdCurso = int.Parse(txtIdCurso.Text);
                        oCursoSelected.NombreCurso = txtNombre.Text;
                        oCursoSelected.Descripcion = txtDescripcion.Text;
                        oCursoSelected.FechaVigencia = DateTime.Parse(txtFechaVigencia.Text);
                        oCursoSelected.Categoria_Curso = new Categoria();
                        oCursoSelected.Categoria_Curso.IdCategoria = (int)cmbCategoria.SelectedValue;

                        if (oCursoService.ActualizarCurso(oCursoSelected))
                        {
                            MessageBox.Show("Curso actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("Error al actualizar el curso!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    }

                case FormMode.eliminar:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el curso seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oCursoService.EliminarCurso(oCursoSelected))
                            {
                                MessageBox.Show("Curso Eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al eliminar el curso!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
