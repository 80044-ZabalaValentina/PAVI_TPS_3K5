using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.DataAccessLayer;
using TPS_PAVI.Entidades;
using TPS_PAVI.Entities;

namespace TPS_PAVI.BusinessLayer
{
    public class ObjetivosCursoService
    {
        private ObjetivosCursoDao oObjetivosCursoDao;
        public ObjetivosCursoService()
        {
            oObjetivosCursoDao = new ObjetivosCursoDao();
        }
        public IList<ObjetivosCurso> ObtenerTodos()
        {
            return oObjetivosCursoDao.GetAll();
        }
        internal bool Crear(ObjetivosCurso objetivosCurso)
        {
            return oObjetivosCursoDao.Create(objetivosCurso);
        }

        internal IList<ObjetivosCurso> ConsultarConFiltro(Dictionary<string, object> filtros)
        {
            return oObjetivosCursoDao.GetByFilters(filtros);
        }

        internal bool ActualizarObjetivos(int id_Curso, DataGridView dgvObjetivos)
        {
            return oObjetivosCursoDao.UpdateObjetivosCurso(id_Curso, dgvObjetivos);
        }

        internal bool ActualizarPuntos(ObjetivosCurso objetivosCursoSelected)
        {
            return oObjetivosCursoDao.Update(objetivosCursoSelected);
        }

        internal bool EliminarObjetivo(ObjetivosCurso objetivosCursoSelected)
        {
            return oObjetivosCursoDao.Delete(objetivosCursoSelected);
        }

    }
}
