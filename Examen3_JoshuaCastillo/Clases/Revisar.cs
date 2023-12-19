using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen3_JoshuaCastillo.Clases
{
    public class Revisar
    {
        private const string DbConnectionName = "DBConn";
        public DataTable ObtenerEncuestasDesdeDB()
        {
            // Utiliza la clase DBConn para obtener la conexión a la base de datos
            using (SqlConnection connection = DBConn.obtenerConexion())
            {
                DataTable dtEncuestas = new DataTable();

                // Realiza la lógica para obtener los datos de la base de datos
                string query = "SELECT ID, Nombre, Edad, correo_electronico as Correo, partido_politico as Partido FROM dbo.encuestas";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtEncuestas);
                    }
                }

                return dtEncuestas;
            }
        }
    }
}