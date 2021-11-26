using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.BusinessLayer;
using TPS_PAVI.Entities;
using TPS_PAVI.GUILayer.AvanceUsuariosXCurso;

namespace TPS_PAVI.GUILayer
{
    public partial class frmAvanceUsuarioCurso : Form
    {
        private readonly CursoService oCursoService;
        private readonly AvanceUsuariosCursoService avanceUsuarioService;
        private readonly UsuarioService usuarioService;

        public frmAvanceUsuarioCurso()
        {
            InitializeComponent();
            InitializeDataGridView();
            oCursoService = new CursoService();
            avanceUsuarioService = new AvanceUsuariosCursoService();
            usuarioService = new UsuarioService();
        }

        private void frmAvanceUsuarioCurso_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
            LlenarCombo(cboCursos, oCursoService.ObtenerTodos(), "NombreCurso", "IdCurso");            
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void InicializarFormulario()
        {
            dgvUsuariosCurso.DataSource = avanceUsuarioService.ObtenerTodos();
            cboCursos.SelectedIndex = -1;
            cboCursos.Enabled = true;
            txtUsuario.Text = "";
            txtUsuario.Enabled = false;
            btnFiltrar.Enabled = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var filters = new Dictionary<string, object>();

            //Validar si el combo 'curso' esta seleccionado
            if (cboCursos.Text != string.Empty)
            {
                //Recuperamos el valor de la propiedad
                filters.Add("IdCurso", cboCursos.SelectedValue);               

            }
            
            if (filters.Count > 0)
            {
                dgvUsuariosCurso.DataSource = avanceUsuarioService.ObtenerPorCurso(filters);
                cboCursos.Enabled = false;
                btnConsultar.Enabled = false;
                txtUsuario.Enabled = true;
                btnFiltrar.Enabled = true;
        
            }
            else
            {
                MessageBox.Show("Debe ingresar el nombre del curso", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var filters = new Dictionary<string, object>();

            //Validar si solo el combo 'usuarios' esta seleccionado
            if (txtUsuario.Text != string.Empty)
            {
                //Recuperamos el valor de la propiedad
                filters.Add("IdCurso", cboCursos.SelectedValue);
                string usu = txtUsuario.Text;
                filters.Add("Usuario", usu);
            }
            if (filters.Count > 0)
            {
                dgvUsuariosCurso.DataSource = avanceUsuarioService.ConsultarConFiltro(filters);
            }
            else
            {
                MessageBox.Show("Debe ingresar el nombre del usuario", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            InicializarFormulario();
            btnConsultar.Enabled = true;
            btnActualizarAvance.Enabled = false;
            txtUsuario.Enabled = false;
            btnFiltrar.Enabled = false;
        }

        private void dgvUsuariosCurso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizarAvance.Enabled = true;
        }

        private void btnActualizarAvance_Click(object sender, EventArgs e)
        {
            frmActualizarAvance formulario = new frmActualizarAvance();
            //Obtener el item seleccionado de la grilla
            var avanceU = (AvanceUsuario)dgvUsuariosCurso.CurrentRow.DataBoundItem;
          
            formulario.InicializarFormulario(avanceU);
            formulario.ShowDialog();

            //Forzar el evento click para actualizar
            btnFiltrar_Click(sender, e);
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvUsuariosCurso.ColumnCount = 7;
            dgvUsuariosCurso.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvUsuariosCurso.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvUsuariosCurso.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvUsuariosCurso.Columns[0].Name = "Id Curso";
            dgvUsuariosCurso.Columns[0].DataPropertyName = "IdCurso";
            dgvUsuariosCurso.Columns[0].Width = 75;


            dgvUsuariosCurso.Columns[1].Name = "Curso";
            dgvUsuariosCurso.Columns[1].DataPropertyName = "NombreCurso";
            dgvUsuariosCurso.Columns[1].Width = 150;

            dgvUsuariosCurso.Columns[2].Name = "Id Usuario";
            dgvUsuariosCurso.Columns[2].DataPropertyName = "IdUsuario";
            dgvUsuariosCurso.Columns[2].Width = 75;


            dgvUsuariosCurso.Columns[3].Name = "Usuario";
            dgvUsuariosCurso.Columns[3].DataPropertyName = "NombreUsuario";
            dgvUsuariosCurso.Columns[3].Width = 150;


            dgvUsuariosCurso.Columns[4].Name = "Inicio";
            dgvUsuariosCurso.Columns[4].DataPropertyName = "Inicio";
            dgvUsuariosCurso.Columns[4].Width = 75;

            dgvUsuariosCurso.Columns[5].Name = "Fin";
            dgvUsuariosCurso.Columns[5].DataPropertyName = "Fin";
            dgvUsuariosCurso.Columns[5].Width = 75;

            dgvUsuariosCurso.Columns[6].Name = "Porcentaje Avance";
            dgvUsuariosCurso.Columns[6].DataPropertyName = "PorcentajeAvance";
            dgvUsuariosCurso.Columns[6].Width = 145;


            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvUsuariosCurso.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvUsuariosCurso.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
