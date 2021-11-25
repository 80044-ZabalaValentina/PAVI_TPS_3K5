using System;
using System.Collections.Generic;
using System.Text;
using TPS_PAVI.DataAccessLayer;
using TPS_PAVI.Entities;

namespace TPS_PAVI.BusinessLayer
{
    public class AvanceUsuariosCursoService
    {
        private AvanceUsuariosCursoDao avanceUsuarioDao;
        public AvanceUsuariosCursoService()
        {
            avanceUsuarioDao = new AvanceUsuariosCursoDao();
        }
        public IList<AvanceUsuario> ObtenerTodos()
        {
            return avanceUsuarioDao.GetAll();
        }

        internal bool ActualizarPorcentaje(AvanceUsuario avanceUsuarioSelected)
        {
            return avanceUsuarioDao.Update(avanceUsuarioSelected);
        }

        internal IList<AvanceUsuario> ConsultarConFiltro(Dictionary<string, object> filtros)
        {
            return avanceUsuarioDao.GetByFilters(filtros);
        }

        internal IList<AvanceUsuario> ObtenerPorCurso(Dictionary<string, object> filtros)
        {
            return avanceUsuarioDao.GetByCurso(filtros);
        }
    }
}
