using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CLINICA_UH.CapaModelo;

namespace CLINICA_UH.CapaNegocio
{
    public class Usuario_Logica
    {
        private readonly string connectionString = "Server=ASUS_Kevin\\KevinSQLExpress;Database=ClinicaUH;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<ClsUsuario> ObtenerUsuarios()
        {
            List<ClsUsuario> usuarios = new List<ClsUsuario>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("ObtenerUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuarios.Add(new ClsUsuario
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Cedula = reader["Cedula"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Tipo = reader["Tipo"].ToString()
                    });
                }
            }
            return usuarios;
        }

        public void InsertarUsuario(ClsUsuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InsertarUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Cedula", usuario.Cedula);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@Tipo", usuario.Tipo ?? "Paciente");

                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarUsuario(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EliminarUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
