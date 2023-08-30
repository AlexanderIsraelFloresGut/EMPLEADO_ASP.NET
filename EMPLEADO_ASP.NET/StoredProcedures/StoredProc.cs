using EMPLEADO_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EMPLEADO_ASP.NET.StoredProcedures
{
    public class StoredProc
    {
        string conString = ConfigurationManager.ConnectionStrings["Mi_EmpresaEntities1"].ToString().Split('"')[1];

        public bool InsertEmpleado(Empleado empleado)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("Guardar_Empleado", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cédula", empleado.Cédula);
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                cmd.Parameters.AddWithValue("@Fecha_Nacimiento", empleado.Fecha_Nacimiento);
                cmd.Parameters.AddWithValue("@Teléfono", empleado.Teléfono);
                cmd.Parameters.AddWithValue("@Dirección", empleado.Dirección);
                cmd.Parameters.AddWithValue("@Sexo", empleado.Sexo);

                connection.Open();
                id = cmd.ExecuteNonQuery();
                connection.Close();

            }

            if (id > 0)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }

        public bool UpdateEmpleado(Empleado empleado)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("Actualizar_Empleado", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cédula", empleado.Cédula);
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                cmd.Parameters.AddWithValue("@Fecha_Nacimiento", empleado.Fecha_Nacimiento);
                cmd.Parameters.AddWithValue("@Teléfono", empleado.Teléfono);
                cmd.Parameters.AddWithValue("@Dirección", empleado.Dirección);
                cmd.Parameters.AddWithValue("@Sexo", empleado.Sexo);

                connection.Open();
                id = cmd.ExecuteNonQuery();
                connection.Close();

            }

            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteEmpleado(string cédula)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("Eliminar_Empleado", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cédula", cédula);

                connection.Open();
                id = cmd.ExecuteNonQuery();
                connection.Close();

            }

            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}