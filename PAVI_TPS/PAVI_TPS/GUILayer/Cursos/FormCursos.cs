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
    public partial class FormCursos : Form
    {
        private CursoService oCursoService;
        private CategoriaService oCategoriaService;


        public FormCursos()
        {
            InitializeComponent();
            InitializeDataGridView();
            oCursoService= new CursoService();
            oCategoriaService = new CategoriaService();
        }

        private void FormCursos_Load(object sender, EventArgs e)
        {
            LlenarCombo(cmbNombre, oCursoService.ObtenerTodos(), "NombreCurso", "IdCurso");
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var filters = new Dictionary<string, object>();

            if (chkTodos.Checked)
            {
                gdrCursos.DataSource = oCursoService.ObtenerTodos();
            }
            else
            {
                //Validar si el combo 'nombre' esta seleccionado
                if (cmbNombre.Text != string.Empty)
                {
                    //Recuperamos el valor de la propiedad
                    filters.Add("IdCurso", cmbNombre.SelectedValue);
                }
                if (filters.Count > 0)
                {
                    gdrCursos.DataSource = oCursoService.ConsultarConFiltro(filters);
                }
                else
                {
                    MessageBox.Show("Debe ingresar el nombre del curso", "Aviso", MessageBoxButtons.OK);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmABMCurso formulario = new frmABMCurso();
            //Obtener el item seleccionado de la grilla
            var curso = (Curso)gdrCursos.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMCurso.FormMode.modificar, curso);
            formulario.ShowDialog();

            //Forzar el evento click para actualizar
            btnBuscar_Click(sender, e);
        } 
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmABMCurso ventana = new frmABMCurso();
            ventana.ShowDialog();

            //Forzamos el evento Click para actualizar la grilla.
            btnBuscar_Click(sender, e);
        }

        private void gdrCategorias_CellClick(System.Object sender, System.EventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMCurso formulario = new frmABMCurso();

            //Obtener el item seleccionado de la grilla
            var curso = (Curso)gdrCursos.CurrentRow.DataBoundItem;

            formulario.InicializarFormulario(frmABMCurso.FormMode.eliminar, curso);
            formulario.ShowDialog();

            //Forzamos el evento Click para actualizar la grilla.
            btnBuscar_Click(sender, e);
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            gdrCursos.ColumnCount = 5;
            gdrCursos.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            gdrCursos.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            gdrCursos.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            gdrCursos.Columns[0].Name = "Id";
            gdrCursos.Columns[0].DataPropertyName = "IdCurso";

            gdrCursos.Columns[1].Name = "Nombre";
            gdrCursos.Columns[1].DataPropertyName = "NombreCurso";

            gdrCursos.Columns[2].Name = "Descripcion";
            gdrCursos.Columns[2].DataPropertyName = "Descripcion";

            gdrCursos.Columns[3].Name = "Fecha Vigencia";
            gdrCursos.Columns[3].DataPropertyName = "FechaVigencia";

            gdrCursos.Columns[4].Name = "Categoria";
            gdrCursos.Columns[4].DataPropertyName = "Categoria_Curso";

            // Cambia el tamaño de la altura de los encabezados de columna.
            gdrCursos.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            gdrCursos.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
