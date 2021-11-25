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
using TPS_PAVI.FormulariosABM.Categorias;

namespace TPS_PAVI
{
    public partial class frmCategorias : Form
    {        
        private CategoriaService oCategoriaService;

        public frmCategorias()
        {
            InitializeComponent();
            InitializeDataGridView();
            oCategoriaService = new CategoriaService();
        }

       
        private void frmCategorias_Load(object sender, EventArgs e)
        {
            LlenarCombo(cmbNombre, oCategoriaService.ObtenerTodos(), "NombreCategoria", "IdCategoria");            
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            frmABMCategoria formulario = new frmABMCategoria();
            //Obtener el item seleccionado de la grilla
            var categoria = (Categoria)gdrCategorias.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMCategoria.FormMode.modificar, categoria);
            formulario.ShowDialog();

            //Forzar el evento click para actualizar
            btnBuscar_Click(sender, e);
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            frmABMCategoria formulario = new frmABMCategoria();

            //Obtener el item seleccionado de la grilla
            var categoria = (Categoria)gdrCategorias.CurrentRow.DataBoundItem;

            formulario.InicializarFormulario(frmABMCategoria.FormMode.eliminar, categoria);
            formulario.ShowDialog();
            //Forzar el evento click para actualizar
            btnBuscar_Click(sender, e);
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            frmABMCategoria ventana = new frmABMCategoria();
            ventana.ShowDialog();

            //Forzamos el evento Click para actualizar la grilla.
            btnBuscar_Click(sender, e);
        }

        private void gdrCategorias_CellClick(System.Object sender, System.EventArgs e)
        {
            btnModificarCategoria.Enabled = true;
            btnEliminarCategoria.Enabled = true;
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (chkTodos.Checked)
                {
                    cmbNombre.Enabled = false;
                }
                else
                {
                    cmbNombre.Enabled = true;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var filters = new Dictionary<string, object>();
            
            if (chkTodos.Checked)
            {
                gdrCategorias.DataSource = oCategoriaService.ObtenerTodos();
            }
            else
            {
                //Validar si el combo 'nombre' esta seleccionado
                if (cmbNombre.Text != string.Empty)
                {
                    //Recuperamos el valor de la propiedad
                    filters.Add("idCategoria", cmbNombre.SelectedValue);
                }
                if (filters.Count > 0)
                {
                    gdrCategorias.DataSource = oCategoriaService.ConsultarConFiltro(filters);
                }
                else
                {
                    MessageBox.Show("Debe ingresar el nombre de la categoria", "Aviso", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            gdrCategorias.ColumnCount = 3;
            gdrCategorias.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            gdrCategorias.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            gdrCategorias.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            gdrCategorias.Columns[0].Name = "Id";
            gdrCategorias.Columns[0].DataPropertyName = "IdCategoria";
            // Definimos el ancho de la columna.

            gdrCategorias.Columns[1].Name = "Nombre";
            gdrCategorias.Columns[1].DataPropertyName = "NombreCategoria";

            gdrCategorias.Columns[2].Name = "Descripcion";
            gdrCategorias.Columns[2].DataPropertyName = "Descripcion";

            // Cambia el tamaño de la altura de los encabezados de columna.
            gdrCategorias.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            gdrCategorias.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
