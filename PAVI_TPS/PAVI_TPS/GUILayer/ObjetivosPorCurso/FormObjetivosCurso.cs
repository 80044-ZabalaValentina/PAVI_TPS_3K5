using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.BusinessLayer;
using TPS_PAVI.Entidades;
using TPS_PAVI.Entities;
using TPS_PAVI.GUILayer.ObjetivosPorCurso;

namespace TPS_PAVI.GUILayer
{
    public partial class frmObjetivosCurso : Form
    {

        private readonly ObjetivosCursoService objetivosCursoService;
        private readonly CursoService oCursoService;
        private readonly ObjetivoService oObjetivoService;

        public frmObjetivosCurso()
        {
            InitializeComponent();
            InitializeDataGridView();
            oCursoService = new CursoService();
            oObjetivoService = new ObjetivoService();
            objetivosCursoService = new ObjetivosCursoService();

        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void frmObjetivosCurso_Load(object sender, EventArgs e)
        {
            InicializarFormulario();

            LlenarCombo(cboCursos, oCursoService.ObtenerTodos(), "NombreCurso", "IdCurso");
            cboObjetivos.Enabled = false;
            txtPuntos.Enabled = false;

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var filters = new Dictionary<string, object>();

            //Validar si el combo 'curso' esta seleccionado
            if (cboCursos.Text != string.Empty)
            {
                //Recuperamos el valor de la propiedad
                filters.Add("idCurso", cboCursos.SelectedValue);

            }
            if (filters.Count > 0)
            {
                dgvObjetivosCurso.DataSource = objetivosCursoService.ConsultarConFiltro(filters);
                LlenarCombo(cboObjetivos, oObjetivoService.ObtenerTodos(), "NombreLargoObjetivo", "IdObjetivo");
                cboObjetivos.Enabled = true;
                txtPuntos.Enabled = true;
                btnConsultar.Enabled = false;
                cboCursos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe ingresar el nombre del curso", "Aviso", MessageBoxButtons.OK);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InicializarFormulario()
        {
            cboCursos.SelectedIndex = -1;
            dgvObjetivosCurso.DataSource = null;
            cboObjetivos.SelectedIndex = -1;
            txtPuntos.Text = "";
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMObjetivosCurso formulario = new frmABMObjetivosCurso();
            //Obtener el item seleccionado de la grilla
            var objetivoC = (ObjetivosCurso)dgvObjetivosCurso.CurrentRow.DataBoundItem;
            int idCurso = Convert.ToInt32(cboCursos.SelectedValue);

            formulario.InicializarFormulario(frmABMObjetivosCurso.FormMode.modificar, objetivoC, idCurso);
            formulario.ShowDialog();

            //Forzar el evento click para actualizar
            btnConsultar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMObjetivosCurso formulario = new frmABMObjetivosCurso();

            //Obtener el item seleccionado de la grilla
            var objetivo = (ObjetivosCurso)dgvObjetivosCurso.CurrentRow.DataBoundItem;
            int idCurso = Convert.ToInt32(cboCursos.SelectedValue);

            formulario.InicializarFormulario(frmABMObjetivosCurso.FormMode.eliminar, objetivo, idCurso);
            formulario.ShowDialog();
            //Forzar el evento click para actualizar
            btnConsultar_Click(sender, e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int idCurso = Convert.ToInt32(cboCursos.SelectedValue);
            int idObjetivo = Convert.ToInt32(cboObjetivos.SelectedValue);
            int? puntos = null;

            if ( ExisteEnGrilla(idObjetivo) == false)
            {
                ObjetivosCurso objetivoCurso = new ObjetivosCurso();
                objetivoCurso.Curso = new Curso();
                objetivoCurso.Curso.IdCurso = idCurso;
                objetivoCurso.Objetivo = new Objetivo();
                objetivoCurso.Objetivo.IdObjetivo = idObjetivo;
                if (txtPuntos.Text != "")
                {
                    puntos = int.Parse(txtPuntos.Text);
                    objetivoCurso.Puntos = (int)puntos;
                }

                if (objetivosCursoService.Crear(objetivoCurso))
                {
                    MessageBox.Show("Objetivo insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Forzar el evento click para actualizar
                    btnConsultar_Click(sender, e);
                    cboObjetivos.SelectedIndex = -1;
                    txtPuntos.Text = "";
                }
                else
                {
                    MessageBox.Show("Error al insertar el objetivo!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboObjetivos.SelectedIndex = -1;
                    txtPuntos.Text = "";
                }
            }
            else
            {
                MessageBox.Show("El objetivo ya se encuentra!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvObjetivosCurso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            InicializarFormulario();
            btnConsultar.Enabled = true;
            cboCursos.Enabled = true;
        }

        private bool ExisteEnGrilla(int criterioABuscar)
        {
            bool resultado = false;
            for (int i = 0; i < dgvObjetivosCurso.Rows.Count; i++)
            {
                if (dgvObjetivosCurso.Rows[i].Cells["Id Objetivo"].Value.Equals(criterioABuscar))
                {
                    resultado = true;
                    break;
                }
            }

            return resultado;
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvObjetivosCurso.ColumnCount = 4;
            dgvObjetivosCurso.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvObjetivosCurso.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvObjetivosCurso.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvObjetivosCurso.Columns[0].Name = "Id Curso";
            dgvObjetivosCurso.Columns[0].DataPropertyName = "IdCurso";
            dgvObjetivosCurso.Columns[0].Width = 100;


            dgvObjetivosCurso.Columns[1].Name = "Id Objetivo";
            dgvObjetivosCurso.Columns[1].DataPropertyName = "IdObjetivo";
            dgvObjetivosCurso.Columns[1].Width = 100;

            dgvObjetivosCurso.Columns[2].Name = "Objetivo";
            dgvObjetivosCurso.Columns[2].DataPropertyName = "Objetivo";
            dgvObjetivosCurso.Columns[2].Width = 250;


            dgvObjetivosCurso.Columns[3].Name = "Puntos";
            dgvObjetivosCurso.Columns[3].DataPropertyName = "Puntos";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvObjetivosCurso.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvObjetivosCurso.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

    }

}
