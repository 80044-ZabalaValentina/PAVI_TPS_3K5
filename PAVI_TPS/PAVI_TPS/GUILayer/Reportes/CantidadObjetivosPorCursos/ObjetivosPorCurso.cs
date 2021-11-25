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

namespace PAVI_TPS.GUILayer.Reportes.CantidadObjetivosPorCursos
{
    public partial class frmObjetivosPorCurso : Form
    {
        public frmObjetivosPorCurso()
        {
            InitializeComponent();
        }

        private void ObjetivosPorCurso_Load(object sender, EventArgs e)
        {

            this.rpvObjetivos.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT oc.id_curso as idCurso, c.nombre as curso ,COUNT(*) as cantidad" +
                            " FROM ObjetivosCursos oc, Objetivos o, Cursos c" +
                            " WHERE oc.id_objetivo = o.id_objetivo" +
                            " AND oc.id_curso = c.id_curso " +
                            " AND oc.borrado = @borrado" +
                            " GROUP BY  oc.id_curso,c.nombre";

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("borrado", 0);
            //Data source
            rpvObjetivos.LocalReport.DataSources.Clear();
            rpvObjetivos.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", DataManager.GetInstance().ConsultaSQL(strSql,parametros)));
                    
        }
    }
}
