using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text;
//using ctrlArchivos.Modelo;

namespace ctrlArchivos.Modelo
{
    public class Datos
    {
        public SqlDataReader dr { get; set; } //
        public SqlCommand cadena_sql { get; set; }
        SqlDataAdapter adapt; // data set
        SqlConnection conn; // cadena de conexion 

        public bool Conectar()
        {
            conn = new SqlConnection();

            servidor misvr = new servidor("localhost", "insunipue");
            misvr.MyCadCon ="Data Source=" +
                misvr.Svractual +
                "; Initial catalog=" +
                misvr.Bdatos +
                "; Integrated security=true";
            
            conn.ConnectionString = misvr.MyCadCon;
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al conectarse a la base de datos" + error.Message);
                return false;
            }
        }

        public void desconectar()
        {
            conn.Close();
        }

        public void construye_reader(string cadena)
        {
            cadena_sql = new SqlCommand();
            cadena_sql.Connection = conn;
            cadena_sql.CommandText = cadena;
        }

        public SqlDataReader ejecuta_reader()
        {
            try
            {
                dr = cadena_sql.ExecuteReader();
                return dr;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ejecutar el Reader" + error.Message);
                return null;
            }
        }

        public SqlCommand construye_command(string cadena)
        {
            cadena_sql = new SqlCommand(cadena, conn);
            return cadena_sql;
        }

        public int ejecutanonquery()
        {
            int afectados;
            try
            {
                afectados = cadena_sql.ExecuteNonQuery();
                return afectados;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ejecutar el reader" + error.Message);
                return 0;
            }
        }

        public SqlDataAdapter construye_adapter(string cadena)
        {
            adapt = new SqlDataAdapter(cadena, conn);
            return adapt;
        }

        public DataRow extrae_registro(SqlDataAdapter adapter, string tabla)
        {
            DataSet ds = new DataSet();
            DataRow fila;
            try
            {
                adapter.Fill(ds, tabla);
                DataTable miTabla = ds.Tables[tabla];
                fila = miTabla.Rows[0];
                return fila;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al extraer el registro" + error.Message);
                return null;
            }
        }

        public DataSet contustarDataSet(string consulta)
        {
            DataSet ds = new DataSet();
            SqlCommand comando = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            comando.CommandText = consulta;
            comando.Connection = conn;
            adapter.SelectCommand = comando;
            try
            {
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo crear el dataset" + error.Message);
                return null;
            }
        }

    }
}