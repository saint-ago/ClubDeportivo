﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
    public class Datos_SocioDeportivo
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
        
        public DataTable ListarSocioDeportivo()
        {
            DataTable tabla = new DataTable();
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_LISTARSOCIODEPORTIVO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();

            return tabla;
        }

        public void InsertarSocioDeportivo(int idSocio, string inscripcion)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARSOCIODEPORTIVO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDSOCIO", idSocio);
            cmd.Parameters.AddWithValue("@INSCRIPCION", inscripcion);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }


    }
}