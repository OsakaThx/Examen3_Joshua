using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Examen3_JoshuaCastillo
{
    public class AgregadorEncuestas
    {
        private const string DbConnectionName = "DBConn";

        public bool AgregarEncuesta(string nombre, int edad, string correo, string partidoSeleccionado)
        {
            // Validar restricciones
            if (edad < 17 || edad > 50)
            {
                throw new ArgumentException("La edad debe estar entre 17 y 50 años.");
            }

            if (string.IsNullOrEmpty(partidoSeleccionado))
            {
                throw new ArgumentException("Debe seleccionar un partido político.");
            }

            if (!EsCorreoValido(correo))
            {
                throw new ArgumentException("El formato del correo electrónico no es válido.");
            }

            // Realizar acciones adicionales con la información recolectada
            // ...

            // Agregar la encuesta a la base de datos
            return InsertarEncuestaEnBaseDeDatos(nombre, edad, correo, partidoSeleccionado);
        }

        private bool EsCorreoValido(string correo)
        {
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(patronCorreo);
            return regex.IsMatch(correo);
        }

        private bool InsertarEncuestaEnBaseDeDatos(string nombre, int edad, string correo, string partido)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DbConnectionName].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO dbo.encuestas (Nombre, Edad, correo_electronico, partido_politico) VALUES (@Nombre, @Edad, @Correo, @Partido); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Edad", edad);
                    command.Parameters.AddWithValue("@Correo", correo);
                    command.Parameters.AddWithValue("@Partido", partido);

                    // Obtener el nuevo valor de la clave primaria (id) generado por la base de datos
                    int nuevoId = Convert.ToInt32(command.ExecuteScalar());

                    

                    return nuevoId > 0;
                }



            }
        }
    }
}
