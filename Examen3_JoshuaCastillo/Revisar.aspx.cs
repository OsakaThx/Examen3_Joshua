using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Examen3_JoshuaCastillo.Clases;

namespace Examen3_JoshuaCastillo


{
    public partial class Revisar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Al cargar la página, llenar el GridView con las encuestas
                BindEncuestas();
            }
        }

        private void BindEncuestas()
        {
            // Aquí, obtienes los datos de la base de datos y los asignas al GridView
            DataTable dtEncuestas = ObtenerEncuestasDesdeDB();
            gvEncuestas.DataSource = dtEncuestas;
            gvEncuestas.DataBind();
        }

        private DataTable ObtenerEncuestasDesdeDB()
        {
            // Aquí, utilizas la clase DBConn para obtener la conexión
            using (SqlConnection connection = DBConn.obtenerConexion())
            {
                DataTable dtEncuestas = new DataTable();

                // Aquí, realizas la lógica para obtener los datos de la base de datos
                // y devolverlos como un DataTable
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