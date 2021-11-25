using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.Entidades;

namespace TPS_PAVI.AccesoADatos
{
    public class ObjetivoDao
    {
        public static int GetLastObjetivoId()
        {
            try
            {
                //Construimos la consulta sql para buscar el ultimo id de categorias en la base de datos.
                String consultaSql = string.Concat("SELECT MAX(id_objetivo) FROM Objetivos");

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

        public IList<Objetivo> GetAll()
        {
            List<Objetivo> listadoCate = new List<Objetivo>();

            String strSql = string.Concat(" SELECT id_objetivo, nombre_corto, nombre_largo FROM Objetivos WHERE borrado = 0 ");

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoCate.Add(ObjectMapping(row));
            }

            return listadoCate;
        }
        public Objetivo GetCategory(string nombreLargo)
        {
            String strSql = string.Concat(" SELECT id_objetivo, nombre_corto, nombre_largo FROM Objetivos WHERE borrado = 0 AND nombre_largo LIKE @nombreLargo");

            var parametros = new Dictionary<string, object>();
            parametros.Add("@nombreLargo", nombreLargo);
            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Objetivo> GetByFilters(Dictionary<string, object> parametros)
        {
            List<Objetivo> lst = new List<Objetivo>();
            String strSql = string.Concat(" SELECT id_objetivo, ",
                                              "     nombre_corto, ",
                                              "     nombre_largo",
                                              "   FROM Objetivos",
                                              "  WHERE borrado = 0");

            if (parametros.ContainsKey("idObjetivo"))
                strSql += " AND (id_objetivo = @idObjetivo) ";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Create(Objetivo oObjetivo)
        {
            string str_sql = "     INSERT INTO Objetivos (nombre_corto, nombre_largo, borrado)" +
                             "     VALUES (@nombre_corto, @nombre_largo, 0)";

            var parametros = new Dictionary<string, object>();
            parametros.Add("@nombre_corto", oObjetivo.NombreCortoObjetivo);
            parametros.Add("@nombre_largo", oObjetivo.NombreLargoObjetivo);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        internal bool Update(Objetivo oObjetivo)
        {
            string str_sql = "UPDATE Objetivos" +
                             "   SET nombre_corto = @nombre_corto," +
                             "       nombre_largo = @nombre_largo" +
                             "   WHERE id_objetivo = @id_objetivo";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_objetivo", oObjetivo.IdObjetivo);
            parametros.Add("nombre_corto", oObjetivo.NombreCortoObjetivo);
            parametros.Add("nombre_largo", oObjetivo.NombreLargoObjetivo);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        internal bool Delete(Objetivo oObjetivo)
        {
            string str_sql = "UPDATE Objetivos" +
                             "   SET borrado = 1" +
                             "  WHERE id_objetivo = @id_objetivo";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_objetivo", oObjetivo.IdObjetivo);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }


        private Objetivo ObjectMapping(DataRow row)
        {
            Objetivo oObjetivo = new Objetivo()
            {
                IdObjetivo = Convert.ToInt32(row["id_objetivo"].ToString()),
                NombreCortoObjetivo = row["nombre_corto"].ToString(),
                NombreLargoObjetivo = row["nombre_largo"].ToString(),
            };
            return oObjetivo;
        }
    }
}
