using System;
using System.Collections.Generic;
using System.Text;
using TPS_PAVI.AccesoADatos;
using TPS_PAVI.Entidades;

namespace TPS_PAVI.BusinessLayer
{
    public class ObjetivoService
    {
        private ObjetivoDao oObjetivoDao;
        public ObjetivoService()
        {
            oObjetivoDao = new ObjetivoDao();
        }
        public IList<Objetivo> ObtenerTodos()
        {
            return oObjetivoDao.GetAll();
        }


        internal bool CrearObjetivo(Objetivo oObjetivo)
        {
            return oObjetivoDao.Create(oObjetivo);
        }

        internal bool ActualizarObjetivo(Objetivo oObjetivoSelected)
        {
            return oObjetivoDao.Update(oObjetivoSelected);
        }

        internal bool EliminarObjetivo(Objetivo oObjetivoSelected)
        {
            return oObjetivoDao.Delete(oObjetivoSelected);
        }

        internal object ObtenerObjetivo(string nombreCorto)
        {
            return oObjetivoDao.GetCategory(nombreCorto);
        }

        internal IList<Objetivo> ConsultarConFiltro(Dictionary<string, object> filtros)
        {
            return oObjetivoDao.GetByFilters(filtros);
        }
    }
}
