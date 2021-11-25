using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TPS_PAVI.Entidades;
using TPS_PAVI.Entities;

namespace TPS_PAVI.DataAccessLayer
{
    public class AvanceUsuariosCursoDao
    {
        public IList<AvanceUsuario> GetAll()
        {
            List<AvanceUsuario> listadoAvanceUsu = new List<AvanceUsuario>();

            String strSql = string.Concat(" SELECT au.id_curso, c.nombre, au.id_usuario, u.usuario, au.inicio, au.fin, au.porc_avance" +
                "                           FROM UsuariosCursoAvance au " +
                "                           INNER JOIN Usuarios u ON au.id_usuario = u.id_usuario" +
                "                           INNER JOIN Cursos c ON au.id_curso = c.id_curso");

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoAvanceUsu.Add(ObjectMapping(row));
            }

            return listadoAvanceUsu;
        }

        public IList<AvanceUsuario> GetByFilters(Dictionary<string, object> parametros)
        {
            List<AvanceUsuario> lst = new List<AvanceUsuario>();
            String strSql = string.Concat(" SELECT  au.id_curso, c.nombre, au.id_usuario, u.usuario, au.inicio, au.fin, au.porc_avance" +
                                          "  FROM UsuariosCursoAvance au INNER JOIN Usuarios u ON au.id_usuario = u.id_usuario" +
                                          "  INNER JOIN Cursos c ON au.id_curso = c.id_curso" +
                                          " WHERE ");

            if (parametros.ContainsKey("IdCurso"))
                strSql += " (au.id_curso = @IdCurso) ";

            if (parametros.ContainsKey("IdUsuario"))
                strSql += " AND (au.id_usuario = @IdUsuario) ";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        public IList<AvanceUsuario> GetByCurso(Dictionary<string, object> parametros)
        {
            List<AvanceUsuario> lst = new List<AvanceUsuario>();
            String strSql = string.Concat(" SELECT  au.id_curso, c.nombre, au.id_usuario, u.usuario, au.inicio, au.fin, au.porc_avance " +
                                          "  FROM UsuariosCursoAvance au INNER JOIN Usuarios u ON au.id_usuario = u.id_usuario " +
                                          "  INNER JOIN Cursos c ON au.id_curso = c.id_curso " +
                                          "  WHERE ");


            if (parametros.ContainsKey("IdCurso"))
                strSql += " au.id_curso = @IdCurso ";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }


        internal bool Update(AvanceUsuario avanceUsu)
        {
            string str_sql = "UPDATE UsuariosCursoAvance "+
                            " SET porc_avance = @porc_avance"+
                            " WHERE id_curso = @id_curso AND id_usuario = @id_usuario";

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_curso", avanceUsu.Curso.IdCurso);
            parametros.Add("@id_usuario", avanceUsu.Usuario.IdUsuario);
            parametros.Add("@porc_avance", avanceUsu.PorcentajeAvance);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        private AvanceUsuario ObjectMapping(DataRow row)
        {
            AvanceUsuario avanceU = new AvanceUsuario();
            avanceU.Curso = new Curso();
            avanceU.Curso.IdCurso = Convert.ToInt32(row["id_curso"].ToString());
            avanceU.Curso.NombreCurso = row["nombre"].ToString();
            avanceU.Usuario = new Usuario();
            avanceU.Usuario.IdUsuario = Convert.ToInt32(row["id_usuario"].ToString());
            avanceU.Usuario.NombreUsuario = row["usuario"].ToString();
            avanceU.Inicio = Convert.ToDateTime(row["inicio"].ToString());
            avanceU.Fin = Convert.ToDateTime(row["fin"].ToString());
            avanceU.PorcentajeAvance = Convert.ToInt32(row["porc_avance"].ToString());

            return avanceU;
        }
    }
}
