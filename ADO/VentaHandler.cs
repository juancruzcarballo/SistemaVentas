using Tarea3JuanCruzCarballo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tarea3JuanCruzCarballo.ADO
{
    public static class VentaHandler
    {
        public static string ConnectionString = "Data Source=(DESKTOP-IHFL947)\\Servidor alina; Initial Catalog = carballo_Sistema_Gestion; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Venta> GetVentas(int id)
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = @"select * from Venta
                                                where IdUsuario = @idUsuario;";

                    sqlCommand.Parameters.AddWithValue("@idUsuario", id);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table); //Se ejecuta el Select

                    foreach (DataRow row in table.Rows)
                    {
                        Venta venta = new Venta();
                        venta.Id = Convert.ToInt32(row["Id"]);
                        venta.Comentarios = row["Comentarios"].ToString();
                        venta.IdUsuario = Convert.ToInt32(row["IdUsuario"]);

                        ventas.Add(venta);
                    }
                    sqlCommand.Connection.Close();
                }
            }
            return ventas;
        }

      
    }
}
