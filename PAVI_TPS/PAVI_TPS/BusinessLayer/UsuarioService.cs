using System;
using System.Collections.Generic;
using System.Text;
using TPS_PAVI.AccesoADatos;

namespace TPS_PAVI.BusinessLayer
{
    public class UsuarioService
    {
        public UsuarioDao usuarioDao;

        public UsuarioService()
        {
            usuarioDao = new UsuarioDao();
        }

        public IList<Usuario> ObtenerTodos()
        {
            return usuarioDao.GetAll();
        }
        internal IList<Usuario> ConsultarConFiltro(Dictionary<string, object> filtros)
        {
            return usuarioDao.GetByFilters(filtros);
        }
    }
}
