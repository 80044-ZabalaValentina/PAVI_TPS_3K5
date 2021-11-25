using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.Entidades;

namespace TPS_PAVI.AccesoADatos
{
    public class CategoriaDao
    {

        public static int GetLastCategoryId()
        {
            try
            {
                //Construimos la consulta sql para buscar el ultimo id de categorias en la base de datos.
                String consultaSql = string.Concat("SELECT MAX(id_categoria) FROM Categorias");

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

        public IList<Categoria> GetAll()
        {
            List<Categoria> listadoCate = new List<Categoria>();

            String strSql = string.Concat(" SELECT id_categoria, nombre, descripcion FROM Categorias WHERE borrado = 0 ");

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoCate.Add(ObjectMapping(row));
            }

            return listadoCate;
        }
        public Categoria GetCategory(string nombreCate)
        {
            String strSql = string.Concat(" SELECT id_categoria, nombre, descripcion FROM Categorias WHERE borrado = 0 AND nombre LIKE @nombreCatego");

            var parametros = new Dictionary<string, object>();
            parametros.Add("@nombreCatego", nombreCate);
            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Categoria> GetByFilters(Dictionary<string, object> parametros)
        {
            List<Categoria> lst = new List<Categoria>();
            String strSql = string.Concat(" SELECT id_categoria, ",
                                              "        nombre, ",
                                              "        descripcion",
                                              "   FROM Categorias",
                                              "  WHERE borrado = 0");

            if (parametros.ContainsKey("idCategoria"))
                strSql += " AND (id_categoria = @idCategoria) ";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Create(Categoria oCategoria)
        {
            string str_sql = "     INSERT INTO Categorias (nombre, descripcion, borrado)" +
                             "     VALUES (@nombre, @descripcion, 0)";

            var parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", oCategoria.NombreCategoria);
            parametros.Add("@descripcion", oCategoria.Descripcion);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        internal bool Update(Categoria oCategoria)
        {
            string str_sql = "UPDATE Categorias" +
                             "   SET nombre = @nombre," +
                             "       descripcion = @descripcion" +
                             "   WHERE id_categoria = @id_categoria";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_categoria", oCategoria.IdCategoria);
            parametros.Add("nombre", oCategoria.NombreCategoria);
            parametros.Add("descripcion", oCategoria.Descripcion);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        internal bool Delete(Categoria oCategoria)
        {
            string str_sql = "UPDATE Categorias" +
                             "   SET borrado = 1" +
                             "  WHERE id_categoria = @id_categoria";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_categoria", oCategoria.IdCategoria);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }


        private Categoria ObjectMapping(DataRow row)
        {
            Categoria oCategoria = new Categoria()
            {
                IdCategoria = Convert.ToInt32(row["id_categoria"].ToString()),
                NombreCategoria = row["nombre"].ToString(),
                Descripcion = row["descripcion"].ToString(),
            }; 
            return oCategoria;
        }
    }
}
