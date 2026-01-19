using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


#region PROCEDIMIENTOS DEPARTAMENTOS
/*
 create procedure SP_ALL_DEPARTAMENTOS
as
	select * from DEPARTAMENTOS
go

---------------
create procedure SP_INSERT_DEPARTAMENTO (@numero int, @nombre nvarchar(50), @localidad nvarchar(50))
as
	insert into DEPARTAMENTOS values(@numero,@nombre,@localidad)
go

------ALTERAMOS PARA VER LAS RESTRICCIONES NUEVAS EN EL SQL
alter procedure SP_INSERT_DEPARTAMENTO (@numero int, @nombre nvarchar(50), @localidad nvarchar(50))
as
	if(UPPER(@localidad)='TERUEL')
		begin 
			print 'TERUEL NO EXISTE'
		end 
	else
		begin
			insert into DEPARTAMENTOS values(@numero,@nombre,@localidad)
		end
go
 */
#endregion
namespace NetCoreAdoNet
{
    public partial class Form12MensajesServidor : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form12MensajesServidor()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            //AGREGAMOS EL EVENTO PARA CAPTURAR MENSAJES
            this.cn.InfoMessage += Cn_InfoMessage;
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadDepartamentos();
        }

        private async void Cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.lblServidor.Text = e.Message;
        }

        private async Task LoadDepartamentos()
        {
            string sql="SP_ALL_DEPARTAMENTOS";
            //IMPORTANTE EL COMMAND TYPE
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.lstDepartamentos.Items.Clear();

            while (await this.reader.ReadAsync())
            {
                string deptno = this.reader["DEPT_NO"].ToString();
                string nombre = this.reader["DNOMBRE"].ToString();
                string loc = this.reader["LOC"].ToString();
                this.lstDepartamentos.Items.Add(deptno+"-"+nombre+"-"+loc);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            this.lblServidor.Text = "";
            //NUEVO DEPARTAMENTO LO INSERTAMOS 
            string sql = "SP_INSERT_DEPARTAMENTO";
            int deptno = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;
            this.com.Parameters.AddWithValue("@numero",deptno);//que sería dept_no
            this.com.Parameters.AddWithValue("@nombre",nombre);
            this.com.Parameters.AddWithValue("@localidad",localidad);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            int registros = this.com.ExecuteNonQuery();//await lo quitamos por ahora por infomessage
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            await this.LoadDepartamentos();//await si es async task
            MessageBox.Show("REGISTROS INSERTADOS: " + registros);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        
    }
}
