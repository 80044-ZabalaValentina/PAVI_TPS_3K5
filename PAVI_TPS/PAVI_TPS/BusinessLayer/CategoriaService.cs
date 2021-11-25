using System;
using System.Collections.Generic;
using System.Text;
using TPS_PAVI.AccesoADatos;
using TPS_PAVI.Entidades;

namespace TPS_PAVI.BusinessLayer
{
    public class CategoriaService
    {
        private CategoriaDao oCategoriaDao;
        public CategoriaService()
        {
            oCategoriaDao = new CategoriaDao();
        }
        public IList<Categoria> ObtenerTodos()
        {
            return oCategoriaDao.GetAll();
        }

       
        internal bool CrearCategoria(Categoria oCategoria)
        {
            return oCategoriaDao.Create(oCategoria);
        }

        internal bool ActualizarCategoria(Categoria oCategoriaSelected)
        {
            return oCategoriaDao.Update(oCategoriaSelected);
        }

        internal bool EliminarCategoria(Categoria oCategoriaSelected)
        {
            return oCategoriaDao.Delete(oCategoriaSelected);
        }

        internal object ObtenerCategoria(string nombreCate)
        {
            return oCategoriaDao.GetCategory(nombreCate);
        }

        internal IList<Categoria> ConsultarConFiltro(Dictionary<string, object> filtros)
        {
            return oCategoriaDao.GetByFilters(filtros);
        }

    }
}
