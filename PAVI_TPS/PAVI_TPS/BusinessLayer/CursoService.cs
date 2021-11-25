using System;
using System.Collections.Generic;
using System.Text;
using TPS_PAVI.AccesoADatos;
using TPS_PAVI.Entidades;

namespace TPS_PAVI.BusinessLayer
{
    public class CursoService
    {
        private CursoDao oCursoDao;
        public CursoService()
        {
            oCursoDao = new CursoDao();
        }
        public IList<Curso> ObtenerTodos()
        {
            return oCursoDao.GetAll();
        }
        internal bool CrearCurso(Curso oCurso)
        {
            return oCursoDao.Create(oCurso);
        }

        internal bool ActualizarCurso(Curso oCursoSelected)
        {
            return oCursoDao.Update(oCursoSelected);
        }

        internal bool EliminarCurso(Curso oCursoSelected)
        {
            return oCursoDao.Delete(oCursoSelected);
        }

        internal object ObtenerCurso(string nombreCurso)
        {
            return oCursoDao.GetCurso(nombreCurso);
        }

        internal IList<Curso> ConsultarConFiltro(Dictionary<string, object> filtros)
        {
            return oCursoDao.GetByFilters(filtros);
        }
        public Curso ConsultarPorId(int idCurso)
        {
            return oCursoDao.GetCursoById(idCurso);
        }
    }
}
