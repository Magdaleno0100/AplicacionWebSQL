using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionWeb.DAL
{
    public class Mascota
    {
        private SqlConnection con;
        private void conexion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MascotaConn"].ToString();
            con = new SqlConnection(connectionString);
        }

        public bool AgregarMascota(Models.Mascota mascota)
        {
            conexion();
            SqlCommand cmd = new SqlCommand("AgregaMascota", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", mascota.Nombre);
            cmd.Parameters.AddWithValue("@edad", mascota.Edad);
            cmd.Parameters.AddWithValue("@descripcion", mascota.Descripcion);
            cmd.Parameters.AddWithValue("@correo", mascota.CorreoContacto);
            cmd.Parameters.AddWithValue("@adoptado", 0);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Models.Mascota> ObtenerMascotas()
        {
            conexion();
            List<Models.Mascota> mascotas = new List<Models.Mascota>();

            SqlCommand cmd = new SqlCommand("ObtenerMascotas", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sda.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                mascotas.Add(
                        new Models.Mascota
                        {
                            Nombre = Convert.ToString(dr["nombre"]),
                            Edad = Convert.ToString(dr["edad"]),
                            Descripcion = Convert.ToString(dr["descripcion"]),
                            CorreoContacto = Convert.ToString(dr["correo"]),
                            Adoptada = Convert.ToBoolean(dr["adoptado"])
                        }); 
            }
            return mascotas;
        }
    }
}