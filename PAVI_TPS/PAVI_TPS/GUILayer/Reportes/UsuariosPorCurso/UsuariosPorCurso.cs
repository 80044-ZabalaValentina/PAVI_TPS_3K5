using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPS_PAVI;
using TPS_PAVI.BusinessLayer;

namespace PAVI_TPS.GUILayer.Reportes
{
    public partial class frmUsuariosPorCurso : Form
    {
        private CursoService oCursoService;
        public frmUsuariosPorCurso()
        {
            InitializeComponent();
            oCursoService = new CursoService();
        }

        private void frmUsuariosPorCurso_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboCursos, oCursoService.ObtenerTodos(), "NombreCurso", "IdCurso");
            this.rpvUsuarios.RefreshReport();
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT uc.id_curso as idCurso, c.nombre, u.usuario, uca.inicio, uca.fin, uca.porc_avance as avance" +
                            " FROM UsuariosCursoAvance uca, Cursos c, Usuarios u, UsuariosCurso uc" +
                            " WHERE uc.id_curso = c.id_curso" +
                            " AND (uc.id_curso = uca.id_curso AND uc.id_usuario = uca.id_usuario)" +
                            " AND uc.id_usuario = u.id_usuario " +
                            " AND uc.id_curso = @idCurso" +
                            " GROUP BY uc.id_curso, c.nombre, u.usuario, uca.inicio, uca.fin, uca.porc_avance";

            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (cboCursos.Text != string.Empty)
            {
                int idCurso = Convert.ToInt32(cboCursos.SelectedValue);
                parametros.Add("idCurso", idCurso.ToString());

                rpvUsuarios.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("prIdCurso", idCurso.ToString()) });

            }
            //DATASOURCE
            rpvUsuarios.LocalReport.DataSources.Clear();
            rpvUsuarios.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataManager.GetInstance().ConsultaSQL(strSql, parametros)));
            rpvUsuarios.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
