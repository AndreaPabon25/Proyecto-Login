﻿using Capa_Entidad;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class D_Users
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);


        public DataTable D_User(E_Users obje)
        {

            SqlCommand cmd = new SqlCommand("sp_logueo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", obje.usuario);
            cmd.Parameters.AddWithValue("@clave", obje.clave);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;





        }

    }
}







