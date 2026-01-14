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
    public partial class Form04EliminarPlantilla : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form04EliminarPlantilla()
        {
            InitializeComponent();
            //3.creamos los objetos
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            //cargamos la lista de la plantilla
            this.LoadPlantilla();
        }
        //2.creamos un método para cargar los empleados de la plantilla
        private void LoadPlantilla()
        {
            string sql = "select*from PLANTILLA";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            //abrimos la conexion
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstPlantilla.Items.Clear();
            while (this.reader.Read())
            {
                string empno = this.reader["EMPLEADO_NO"].ToString();
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstPlantilla.Items.Add(empno + " -- " + apellido);
            }
            //cerramos
            this.reader.Close();
            this.cn.Close();

        }

        private void btnEliminarEmpPlantilla_Click(object sender, EventArgs e)
        {
            //4.Pasamos al método
            string empno = this.txtEmpNoPlantilla.Text;
            string sql = "delete from PLANTILLA where EMPLEADO_NO=" + empno;
            //siempre lo mismo
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();//ABRIMOS LA CONEXIÓN
            //LAS CONSULTAS DE ACCION DEVUELVEN UN int CON EL NUMER DE REGISTROS AFECTADOS
            int registros = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.LoadPlantilla();
            MessageBox.Show("EMPLEADOS ELIMINADOS: "+ registros);
        }
    }
}
