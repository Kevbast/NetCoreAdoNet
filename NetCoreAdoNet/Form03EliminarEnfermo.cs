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
    public partial class Form03EliminarEnfermo : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form03EliminarEnfermo()
        {
            InitializeComponent();
            //creamos los objetos
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            //cargamos
            this.LoadEnfermos();
        }

        //creamos método para cargar los enfermos
        private void LoadEnfermos()
        {
            string sql = "select*from ENFERMO";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            //abrimos conexión
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstEnfermos.Items.Clear();

            while (this.reader.Read())
            {
                string inscripcion = this.reader["INSCRIPCION"].ToString();
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEnfermos.Items.Add(inscripcion+" -- "+ apellido);
            }
            //liberamos los recursos
            this.reader.Close();
            this.cn.Close();
        }

        private void btnEliminarEnfermo_Click(object sender, EventArgs e)
        {//LOS PARAMETROS DEBEN SER DEL MISMO TIPO DE DATO QUE LA COLUMNA
            int inscripcion = int.Parse(this.txtInscripcion.Text);

            //NCESITAMOS EL DATO DE INSCRIPCIÓN CONCATENADO
            //string inscripcion = this.txtInscripcion.Text;
            string sql = "delete from ENFERMO where INSCRIPCION=@inscripcion";//+inscripcion;
            //DEBEMOS CONFIGURAR UNO O VARIOS PARAMETROS
            SqlParameter pamIns = new SqlParameter();
            //EL NOMBRE DEL PARAMETRO DE LA CONSULTA NO PUEDE ESTAR REPETIDO
            pamIns.ParameterName = "@inscripcion";
            pamIns.DbType = DbType.Int32;
            //POR DEFECTO LA DIRECCION ES INPUT
            pamIns.Direction = ParameterDirection.Input;
            //EL VALOR DEL PARAMETRO PARA SUSTITUIR LA CONSULTA
            pamIns.Value = inscripcion;
            //agregamos el parametro a la colección
            this.com.Parameters.Add(pamIns);


            //luego pasamos a hacer siempre lo mismo
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            //LAS CONSULTAS DE ACCION DEVUELVEN UN int CON EL NUMER DE REGISTROS AFECTADOS
            int registros = this.com.ExecuteNonQuery();
            this.cn.Close();

            //LIBERAMOS LOS PARAMETROS DE COLECCION
            this.com.Parameters.Clear();

            this.LoadEnfermos();
            MessageBox.Show("ENFERMOS ELIMINADOS "+ registros);
        }
    }
}
