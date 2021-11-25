using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.Entidades;

namespace TPS_PAVI.AccesoADatos
{
    public class CursoDao
    {
        public static int GetLastCursoId()
        {
            try
            {
                //Construimos la consulta sql para buscar el ultimo id de categorias en la base de datos.
                String consultaSql = string.Concat("SELECT MAX(id_curso) FROM Cursos");

                //Usando el método GetDataManager obtenemos la instancia unica de DataManager (Patrón Singleton) y ejecutamos el método ConsultaSQL()
                int resultado = (int)DataManager.GetInstance().ConsultaSQLScalar(consultaSql);

                return resultado;

            }
            catch (SqlException ex)
            {
                //Mostramos un mensaje de error indicando que hubo un error en la base de datos.
                MessageBox.Show(string.Concat("Error de base de datos: ", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -2;
            }
        }

        public IList<Curso> GetAll()
        {
            List<Curso> listadoCursos = new List<Curso>();

            String strSql = string.Concat("SELECT  c.id_curso, " ,
                                              "    c.nombre, ",
                                              "    c.descripcion, ",
                                              "    c.fecha_vigencia, ",
                                              "    cat.nombre as Categoria ",
                                              " FROM Cursos c  ",
                                              " JOIN Categorias cat ON c.id_categoria = cat.id_categoria ",
                                              " WHERE c.borrado = 0");


            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoCursos.Add(ObjectMapping(row));
            }

            return listadoCursos;
        }
        public Curso GetCurso(string nombreCurso)
        {
            String strSql = string.Concat(" SELECT id_curso, nombre, descripcion, fecha_vigencia, id_categoria FROM Cursos WHERE borrado = 0 AND nombre LIKE '%' + @nombre + '%'");

            var parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", nombreCurso);
            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Curso> GetByFilters(Dictionary<string, object> parametros)
        {
            List<Curso> lst = new List<Curso>();
            String strSql = string.Concat(" SELECT  c.id_curso, " ,
                                              "     c.nombre,",
                                              "     c.descripcion, ",
                                              "     c.fecha_vigencia, ",
                                              "     cat.nombre as 'categoria'",
                                              "   FROM Cursos c  ",
                                              "  INNER JOIN Categorias cat ON c.id_categoria = cat.id_categoria ",
                                              "  WHERE c.borrado = 0 ");

            if (parametros.ContainsKey("IdCurso"))
                strSql += " AND (c.id_curso = @IdCurso) ";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        public Curso GetCursoById(int idCurso)
        {
            string strSql = " SELECT c.id_curso, " +
                         "     c.nombre,"+
                        "     c.descripcion, "+
                        "     c.fecha_vigencia, "+
                       "     cat.nombre as 'categoria'"+
                       "   FROM Cursos c  "+
                     "  INNER JOIN Categorias cat ON c.id_categoria = cat.id_categoria "+
                     "  WHERE c.borrado = 0 AND c.id_curso = " + idCurso.ToString();

            DataTable fila = DataManager.GetInstance().ConsultaSQL(strSql);
            if (fila.Rows.Count > 0)
                //return MappingCliente(DataManager.GetInstance().ConsultaSQL(strSql).Rows[0]);
                return ObjectMapping(fila.Rows[0]);
            else
                return null;
        }

        internal bool Create(Curso oCurso)
        {
            string str_sql = "     INSERT INTO Cursos (nombre, descripcion, fecha_vigencia, id_categoria, borrado)" +
                             "     VALUES (@nombre, @descripcion, @fecha_vigencia, @id_categoria, 0)";

            var parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", oCurso.NombreCurso);
            parametros.Add("@descripcion", oCurso.Descripcion);
            parametros.Add("@fecha_vigencia", oCurso.FechaVigencia);
            parametros.Add("id_categoria", oCurso.Categoria_Curso.IdCategoria);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        internal bool Update(Curso oCurso)
        {
            string str_sql = "UPDATE  Cursos" +
                             "   SET nombre = @nombre," +
                             "       descripcion = @descripcion," +
                             "       fecha_vigencia = @fecha_vigencia," +
                             "       id_categoria = @id_categoria" +
                             "   WHERE id_curso = @id_curso";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_curso", oCurso.IdCurso);
            parametros.Add("nombre", oCurso.NombreCurso);
            parametros.Add("descripcion", oCurso.Descripcion);
            parametros.Add("fecha_vigencia", oCurso.FechaVigencia);
            parametros.Add("id_categoria", oCurso.Categoria_Curso.IdCategoria);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        internal bool Delete(Curso oCurso)
        {
            string str_sql = "UPDATE  Cursos" +
                             "   SET borrado = 1" +
                             "   WHERE id_curso = @id_curso";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_curso", oCurso.IdCurso);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }


        private Curso ObjectMapping(DataRow row)
        {
            Curso oCurso = new Curso();
            oCurso.IdCurso = Convert.ToInt32(row["id_curso"].ToString());
            oCurso.NombreCurso = row["nombre"].ToString();
            oCurso.Descripcion = row["descripcion"].ToString();
            oCurso.FechaVigencia = Convert.ToDateTime(row["fecha_vigencia"].ToString());
            oCurso.Categoria_Curso = new Categoria();
            oCurso.Categoria_Curso.NombreCategoria = (row["categoria"].ToString());
            
            return oCurso;
        }
    }
}
