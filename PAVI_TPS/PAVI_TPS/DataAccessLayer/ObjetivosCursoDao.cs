using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using TPS_PAVI.Entidades;
using TPS_PAVI.Entities;

namespace TPS_PAVI.DataAccessLayer
{
     class ObjetivosCursoDao
    {

        internal bool Create(ObjetivosCurso objetivosCurso)
        {
            var string_conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=TPS_BugTracker;Integrated Security=true;";

            //Se utiliza para sentenias SQL del tipo "Insert/Update/Delete"
            SqlConnection dbConnection = new SqlConnection();
            SqlTransaction dbTransaction = null;
            try
            {
                dbConnection.ConnectionString = string_conexion;
                dbConnection.Open();
                //Genero la transacción
                dbTransaction = dbConnection.BeginTransaction();

                //DELETE (lógico) de los objetivos anteriores del curso
                SqlCommand insertObjetivo = new SqlCommand();
                insertObjetivo.Connection = dbConnection;
                insertObjetivo.CommandType = CommandType.Text;
                insertObjetivo.Transaction = dbTransaction;
                // Establece la instrucción a ejecutar
                insertObjetivo.CommandText = " INSERT INTO ObjetivosCursos (id_objetivo, id_curso, puntos, borrado ) VALUES (@id_objetivo, @id_curso, @puntos, @borrado)";

                //Agregamos los parámetros
                insertObjetivo.Parameters.AddWithValue("@id_curso", objetivosCurso.Curso.IdCurso);
                insertObjetivo.Parameters.AddWithValue("@id_objetivo", objetivosCurso.Objetivo.IdObjetivo);
                insertObjetivo.Parameters.AddWithValue("@puntos", objetivosCurso.Puntos);
                insertObjetivo.Parameters.AddWithValue("@borrado", 0);

                insertObjetivo.ExecuteNonQuery();

                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw;
            }
            return true;
        }
    

        public IList<ObjetivosCurso> GetByFilters(Dictionary<string, object> parametros)
        {
            List<ObjetivosCurso> lst = new List<ObjetivosCurso>();
            String strSql = string.Concat(" SELECT o.id_objetivo as 'Id Objetivo', oc.id_curso as 'Id Curso', o.nombre_largo as 'Objetivo', oc.puntos",
                                              "  FROM ObjetivosCursos oc INNER JOIN Objetivos o ON oc.id_objetivo = o.id_objetivo ",
                                              "  WHERE oc.borrado = 0");

            if (parametros.ContainsKey("idCurso"))
                strSql += " AND (oc.id_curso = @idCurso)";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Update(ObjetivosCurso objetivosCurso)
        {
            string str_sql = "UPDATE ObjetivosCursos" +
                             "   SET puntos = @Puntos " +
                             "   WHERE id_curso = @id_Curso AND id_objetivo = @id_Objetivo";

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_Curso", objetivosCurso.Curso.IdCurso);
            parametros.Add("@id_Objetivo", objetivosCurso.Objetivo.IdObjetivo);
            parametros.Add("@Puntos", objetivosCurso.Puntos);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        internal bool Delete(ObjetivosCurso objetivosCurso)
        {
            string str_sql = "DELETE ObjetivosCursos" +
                             "  WHERE id_curso = @id_curso AND id_objetivo = @id_objetivo";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_curso", objetivosCurso.Curso.IdCurso);
            parametros.Add("id_objetivo", objetivosCurso.Objetivo.IdObjetivo);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }


        internal bool UpdateObjetivosCurso(int id_Curso, DataGridView dgvObjetivos)      
        {
            var string_conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=TPS_BugTracker;Integrated Security=true;";

            //Se utiliza para sentenias SQL del tipo "Insert/Update/Delete"
            SqlConnection dbConnection = new SqlConnection();
            SqlTransaction dbTransaction = null;
            try
            {
                dbConnection.ConnectionString = string_conexion;
                dbConnection.Open();
                //Genero la transacción
                dbTransaction = dbConnection.BeginTransaction();

                //DELETE (lógico) de los objetivos anteriores del curso
                SqlCommand deleteObjetivosCurso = new SqlCommand();
                deleteObjetivosCurso.Connection = dbConnection;
                deleteObjetivosCurso.CommandType = CommandType.Text;
                deleteObjetivosCurso.Transaction = dbTransaction;
                // Establece la instrucción a ejecutar
                deleteObjetivosCurso.CommandText = "DELETE ObjetivosCursos " +
                                                   "  WHERE id_curso = @id_curso";


                //Agregamos los parámetros
                deleteObjetivosCurso.Parameters.AddWithValue("@id_curso", id_Curso);

                deleteObjetivosCurso.ExecuteNonQuery();

                SqlCommand insertObjetivo = new SqlCommand();
                insertObjetivo.Connection = dbConnection;
                insertObjetivo.CommandType = CommandType.Text;
                insertObjetivo.Transaction = dbTransaction;

                insertObjetivo.CommandText = "INSERT INTO ObjetivosCursos id_objetivo, id_curso, puntos, borrado VALUES (@id_objetivo, @id_curso, @puntos, @borrado)";

                foreach (DataGridViewRow row in dgvObjetivos.Rows)
                {
                    insertObjetivo.Parameters.Clear();

                    insertObjetivo.Parameters.AddWithValue("@id_objetivo", Convert.ToInt32(row.Cells["Id"].Value));
                    insertObjetivo.Parameters.AddWithValue("@id_curso", id_Curso);
                    insertObjetivo.Parameters.AddWithValue("@puntos", Convert.ToInt32(row.Cells["Puntos"].Value));
                    insertObjetivo.Parameters.AddWithValue("@borrado", 0);

                    insertObjetivo.ExecuteNonQuery();
                }
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw;
            }
            return true;
        }

        public IList<ObjetivosCurso> GetAll()
        {
            List <ObjetivosCurso> listadoObjetivosCurso = new List<ObjetivosCurso>();

            String strSql = string.Concat(" SELECT id_objetivo, id_curso, puntos FROM ObjetivosCursos WHERE borrado = 0 ");

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoObjetivosCurso.Add(ObjectMapping(row));
            }

            return listadoObjetivosCurso;
        }

        
        private ObjetivosCurso ObjectMapping(DataRow row)
        {
            ObjetivosCurso objetivosCurso = new ObjetivosCurso();
            objetivosCurso.Objetivo = new Objetivo();            
            objetivosCurso.Objetivo.IdObjetivo = Convert.ToInt32(row["Id Objetivo"]);
            objetivosCurso.Objetivo.NombreLargoObjetivo = row["Objetivo"].ToString();
            objetivosCurso.Curso = new Curso();
            objetivosCurso.Curso.IdCurso = Convert.ToInt32(row["Id Curso"]);
            objetivosCurso.Puntos = Convert.ToInt32(row["Puntos"]);

            return objetivosCurso;
        }
    }
  

}
