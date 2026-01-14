using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCoreAdoNet
{
    public partial class Form05UpdateSalas : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form05UpdateSalas()
        {
            InitializeComponent();
            //3.creamos los objetos
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            //cargamos la lista sala
            this.CargarSalas();
        }
        private void CargarSalas()
        {
            string sql = "select distinct NOMBRE from SALA";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            //abrimos conexion y limpiamos salas
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstSalas.Items.Clear();
            while (this.reader.Read())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                this.lstSalas.Items.Add(nombre);
            }
            this.reader.Close();
            this.cn.Close();
        }

        private void btnUpdateSalas_Click(object sender, EventArgs e)
        {
            string sql = "update SALA set NOMBRE=@newname where NOMBRE=@oldname";
            string newname = this.txtNombre.Text;
            string oldname = this.lstSalas.SelectedItem.ToString();
            SqlParameter pamNew = new SqlParameter("@newname",newname);
            SqlParameter pamOld = new SqlParameter("@oldname",oldname);
            this.com.Parameters.Add(pamNew);
            this.com.Parameters.Add(pamOld);
            //pasamos a lo de siempre
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            //los registros
            int registros = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            MessageBox.Show("Salas modificadas: "+ registros);
            //cargamos las salas
            this.CargarSalas();

        }
    }
}
