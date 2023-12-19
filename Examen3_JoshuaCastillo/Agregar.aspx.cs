using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Examen3_JoshuaCastillo.Clases;

namespace Examen3_JoshuaCastillo
{
    public partial class Agregar : System.Web.UI.Page
    {
        private static int numeroFormulario = 1;
        private DBConn dbConn = new DBConn(); // Crea una instancia de tu clase DBConn

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNumeroFormulario.Text += numeroFormulario;
                BindPartidos();
            }
        }

        private void BindPartidos()
        {
            DataTable dtPartidos = new DataTable();
            dtPartidos.Columns.Add("Partido");
            dtPartidos.Rows.Add("PLN");
            dtPartidos.Rows.Add("PUSC");
            dtPartidos.Rows.Add("PAC");

            gvPartidos.DataSource = dtPartidos;
            gvPartidos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener valores ingresados por el usuario
                string nombre = txtNombre.Text;
                int edad = int.Parse(txtEdad.Text);
                string correo = txtCorreo.Text;
                string partidoSeleccionado = ObtenerPartidoSeleccionado();


                // Crear una instancia de AgregadorEncuestas y agregar la encuesta
                AgregadorEncuestas agregador = new AgregadorEncuestas();
                bool encuestaAgregada = agregador.AgregarEncuesta(nombre, edad, correo, partidoSeleccionado);

                if (encuestaAgregada)
                {
                    // Encuesta agregada con éxito

                    // Obtener el número de formulario actual y mostrarlo
                    int numeroFormulario = Convert.ToInt32(Application["NumeroFormulario"]);
                    lblNumeroFormulario.Text = numeroFormulario.ToString();

                    // Incrementar el número de formulario para el próximo usuario
                    Application["NumeroFormulario"] = numeroFormulario + 1;

                    // Ahora, puedes utilizar la instancia de DBConn para insertar en la base de datos
                    using (SqlConnection connection = DBConn.obtenerConexion())
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.encuestas (Nombre, Edad, correo_electronico, partido_politico) VALUES (@Nombre, @Edad, @Correo, @Partido)", connection))
                        {
                            cmd.Parameters.AddWithValue("@Nombre", nombre);
                            cmd.Parameters.AddWithValue("@Edad", edad);
                            cmd.Parameters.AddWithValue("@Correo", correo);
                            cmd.Parameters.AddWithValue("@Partido", partidoSeleccionado);

                            cmd.ExecuteNonQuery();
                        }
                    }


                    // ...

                    // Incrementar el número de formulario para el próximo usuario
                    numeroFormulario++;

                    // Limpiar campos después de agregar
                    LimpiarCampos();
                }
                else
                {
                    // Error al agregar la encuesta
                    // ...
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
        }

        private string ObtenerPartidoSeleccionado()
        {
            foreach (GridViewRow row in gvPartidos.Rows)
            {
                RadioButton rbPartido = row.FindControl("rbPartido") as RadioButton;
                if (rbPartido.Checked)
                {
                    Label lblPartido = row.FindControl("lblPartido") as Label;
                    return lblPartido.Text;
                }
            }
            return string.Empty;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            lblError.Text = string.Empty;

            foreach (GridViewRow row in gvPartidos.Rows)
            {
                RadioButton rbPartido = row.FindControl("rbPartido") as RadioButton;
                rbPartido.Checked = false;
            }
        }
    }
}