using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace TPS_PAVI.AccesoADatos
{
    public class UsuarioDao
    {
        public static bool ValidarUsuario(Usuario usu)
        {
            //Inicializamos la variable usuarioValido en false, para que solo si el usuario es valido retorne true
            bool usuarioValido = false;

           //La sentencia try...catch nos permite "atrapar" excepciones (Errores) y dar al usuario un mensaje más amigable.
            try
            {

                //Construimos la consulta sql para buscar el usuario en la base de datos.
                String consultaSql = string.Concat(" SELECT * ",
                                                   "   FROM Usuarios ",
                                                   "  WHERE usuario =  '", usu.NombreUsuario, "'");

                //Usando el método GetDataManager obtenemos la instancia unica de DataManager (Patrón Singleton) y ejecutamos el método ConsultaSQL()
                DataTable resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

                //Validamos que el resultado tenga al menos una fila.
                if (resultado.Rows.Count >= 1)
                {
                    //En caso de que exista el usuario, validamos que password corresponda al usuario
                    if (resultado.Rows[0]["password"].ToString() == usu.Contraseña)
                    {
                        usuarioValido = true;
                    }
                }

            }
            catch (SqlException ex)
            {
                //Mostramos un mensaje de error indicando que hubo un error en la base de datos.
                MessageBox.Show(string.Concat("Error de base de datos: ", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Retornamos el valor de usuarioValido. 
            return usuarioValido;
        }

        public IList<Usuario> GetAll()
        {
            List<Usuario> listadoCate = new List<Usuario>();

            String strSql = string.Concat("SELECT id_usuario, usuario FROM Usuarios WHERE borrado = 0");

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoCate.Add(ObjectMapping(row));
            }

            return listadoCate;
        }

        public IList<Usuario> GetByUsuario(Dictionary<string, object> parametros)
        {
            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT  au.id_usuario as id_usuario, u.usuario as usuario" +
                                          "  FROM UsuariosCursoAvance au INNER JOIN Usuarios u ON au.id_usuario = u.id_usuario" +
                                          " WHERE ");

            if (parametros.ContainsKey("IdCurso"))
                strSql += " (au.id_curso = @IdCurso) ";

            if (parametros.ContainsKey("Usuario"))
                strSql += " AND (u.usuario LIKE '%' + @Usuario + '%')";


            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        public IList<Usuario> GetByFilters(Dictionary<string, object> parametros)
        {
            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT id_usuario, usuario FROM Usuarios WHERE borrado = 0");

            if (parametros.ContainsKey("idUsuario"))
                strSql += " AND (id_usuario = @idUsuario) ";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        private Usuario ObjectMapping(DataRow row)
        {
            Usuario usu = new Usuario()
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                NombreUsuario = row["usuario"].ToString()               
            };
            return usu;
        }
    }
}
