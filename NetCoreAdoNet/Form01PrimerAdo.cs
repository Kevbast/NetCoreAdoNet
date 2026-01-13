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
    public partial class Form01PrimerAdo : Form
    {
        //SOTA,CABALLO,REY siempre lo mismo
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        string connectionString;

        public Form01PrimerAdo()
        {
            InitializeComponent();
            //COPIAMOS LA CONECTION STRING 
            this.connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(this.connectionString);
            this.com = new SqlCommand();
            //recuperamos la conexión
            this.cn.StateChange += Cn_StateChange;
        }

        private void Cn_StateChange(object sender, StateChangeEventArgs e)
        {
            this.lblConexion.Text = "La conexion está pasando de " + e.OriginalState + " a " + e.CurrentState;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            //this.cn.ConnectionString = this.connectionString; lo ponemos en el inialice
            //CONTROL DE EXCEPCIONES
            try
            {
                if (this.cn.State == ConnectionState.Closed)
                {

                    this.cn.Open();
                    this.lblConexion.BackColor = Color.LightGreen;
                    //this.lblConexion.Text = "Base de Datos conectada";
                }
            }
            catch (SqlException ex)
            {
                this.lblConexion.Text = "Error con la conexion de la BD" + ex;
            }
            catch (Exception ex)
            {
                this.lblConexion.Text = "Error: " + ex;
            }


        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            this.cn.Close();
            this.lblConexion.BackColor = Color.LightCoral;
            //this.lblConexion.Text = "Base de Datos desconectada";
        }

        private void btnRead_Click(object sender, EventArgs e)
        {//PARA LEER REGISTROS LA CONEXIÓN SIEMPRE OPEN
            string sql="select * from EMP";
            //INDICAMOS LA CONEXION DEL COMAND
            this.com.Connection = this.cn;//la conexión a utilizar
            //TIPO DE CONSULTA A REALIZAR 
            this.com.CommandType = CommandType.Text;
            //INCLUIMOS LA CONSULTA EN EL COMMAND
            this.com.CommandText = sql;
            //AQUÍ DEBERÍAMOS ABRIR LA CONEXIÓN,PERO COMO ESTÁ SEPARADO NO LO HARÍAMOS POR AHORA
            //EJECUTAMOS LA CONSULTA.COMO ES UN SELECT
            //UTILIZAMOS ExecuteReader() QUE DEVUELVE UN DataReader
            this.reader = this.com.ExecuteReader();
            //PARA LA ESTRUCTURA DE LA TABLA SE UTILIZA for
            for (int i = 0; i < this.reader.FieldCount; i++)
            {
                //metemos dentro los gets
                //LEEMOS LA PRIMERA COLUMNA DE LA CONSULTA
                string columna = this.reader.GetName(i);//dame el nombre de la primera columna
                                                        //LEEMOS EL TIPO DE DATO DE LA PRIMERA COLUMNA
                string tipo = this.reader.GetDataTypeName(i);
                this.lstColumnas.Items.Add(columna);
                this.lstTipos.Items.Add(tipo);
            }

            //DEBEMOS INDICAR EL METODO READ PARA LEER REGISTROS
            while (this.reader.Read())
            {             
                //LEMOS EL PRIMER REGISTRO(APELLIDO)
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstApellidos.Items.Add(apellido);
            }

            //SIEMPRE DEBEMOS SALIR,CERRAR
            this.reader.Close();
        }
    }
}
