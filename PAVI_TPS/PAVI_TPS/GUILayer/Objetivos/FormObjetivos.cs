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
    public partial class FormObjetivos : Form
    {
        private ObjetivoService oObjetivoService;

        public FormObjetivos()
        {
            InitializeComponent();
            InitializeDataGridView();
            oObjetivoService = new ObjetivoService();
        }

        private void FormObjetivos_Load(object sender, EventArgs e)
        {
            LlenarCombo(cmbNombre, oObjetivoService.ObtenerTodos(), "NombreLargoObjetivo", "IdObjetivo");
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
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

        private void btnBuscarObj_Click(object sender, EventArgs e)
        {
            var filters = new Dictionary<string, object>();

            if (chkTodos.Checked)
            {
                gdrObjetivos.DataSource = oObjetivoService.ObtenerTodos();
            }
            else
            {
                //Validar si el combo 'nombre' esta seleccionado
                if (cmbNombre.Text != string.Empty)
                {
                    //Recuperamos el valor de la propiedad
                    filters.Add("idObjetivo", cmbNombre.SelectedValue);
                }
                if (filters.Count > 0)
                {
                    gdrObjetivos.DataSource = oObjetivoService.ConsultarConFiltro(filters);
                }
                else
                {
                    MessageBox.Show("Debe ingresar el nombre del objetivo", "Aviso", MessageBoxButtons.OK);
                }
            }
        }

        private void gdrCategorias_CellClick(System.Object sender, System.EventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnAgregarObj_Click(object sender, EventArgs e)
        {
            frmABMObjetivo ventana = new frmABMObjetivo();
            ventana.ShowDialog();

            //Forzamos el evento Click para actualizar la grilla.
            btnBuscarObj_Click(sender, e);
        }

        private void btnModificarObj_Click(object sender, EventArgs e)
        {
            frmABMObjetivo formulario = new frmABMObjetivo();

            //Obtener el item seleccionado de la grilla
            var objetivo = (Objetivo)gdrObjetivos.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMObjetivo.FormMode.modificar, objetivo);
            formulario.ShowDialog();

            //Forzar el evento click para actualizar
            btnBuscarObj_Click(sender, e);
        }

        private void btnEliminarObj_Click(object sender, EventArgs e)
        {
            frmABMObjetivo formulario = new frmABMObjetivo();

            //Obtener el item seleccionado de la grilla
            var objetivo = (Objetivo)gdrObjetivos.CurrentRow.DataBoundItem;

            formulario.InicializarFormulario(frmABMObjetivo.FormMode.eliminar, objetivo);
            formulario.ShowDialog();

            //Forzar el evento click para actualizar
            btnBuscarObj_Click(sender, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            gdrObjetivos.ColumnCount = 3;
            gdrObjetivos.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            gdrObjetivos.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            gdrObjetivos.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            gdrObjetivos.Columns[0].Name = "Id";
            gdrObjetivos.Columns[0].DataPropertyName = "IdObjetivo";
            // Definimos el ancho de la columna.

            gdrObjetivos.Columns[1].Name = "Nombre corto";
            gdrObjetivos.Columns[1].DataPropertyName = "NombreCortoObjetivo";
            gdrObjetivos.Columns[1].Width = 175;

            gdrObjetivos.Columns[2].Name = "Nombre Largo";
            gdrObjetivos.Columns[2].DataPropertyName = "NombreLargoObjetivo";
            gdrObjetivos.Columns[2].Width = 200;


            // Cambia el tamaño de la altura de los encabezados de columna.
            gdrObjetivos.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            gdrObjetivos.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
