using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen3_JoshuaCastillo.Clases
{
    public class DBConn
    {
        public static SqlConnection obtenerConexion()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

            SqlConnection conexion = new SqlConnection(connectionString);
        conexion.Open();
            return conexion;
        }
    }
}