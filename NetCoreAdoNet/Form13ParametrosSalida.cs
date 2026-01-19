using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#region STORED PROCEDURE
/*
 create procedure SP_ALL_DEPARTAMENTOS
as
	select * from DEPARTAMENTOS
go

create procedure SP_EMPLEADOS_DEPARTAMENTOS_OUT
(@nombre NVARCHAR(50),
@suma int OUT,
@media int OUT,
@personas int OUT)
as
	declare @iddept int
	select @iddept = DEPT_NO from DEPT where DNOMBRE=@nombre
	--LA CONSULTA DEL PROCEDIMIENTO
	select * from EMP where DEPT_NO=@iddept
	--RELLENAMOS LAS VARIABLES DE SALIDA OUT
	select @suma=SUM(SALARIO),@media=AVG(SALARIO),@personas=COUNT(EMP_NO) from EMP where DEPT_NO=@iddept
go
 */
#endregion
namespace NetCoreAdoNet
{
    public partial class Form13ParametrosSalida : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form13ParametrosSalida()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadDepartamentos();
        }
        private async Task LoadDepartamentos()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.cmbDepartamentos.Items.Clear();

            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                this.cmbDepartamentos.Items.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
        }

        private async void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            string sql = "SP_EMPLEADOS_DEPARTAMENTOS_OUT";
            //TENEOS UN PARAMETRO DE ENTRADA,POR DEFECTO TODOS SON DE ENTRADA,
            //PODEMOS SEGUIR UTILIZANDO ADDWITHVALUE CON DICHO PARAMETRO
            string nombre = this.cmbDepartamentos.SelectedItem.ToString();
            //this.com.Parameters.AddWithValue("@nombre",nombre);//esto vale tmb
            SqlParameter pamNombre = new SqlParameter();
            pamNombre.ParameterName = "@nombre";
            pamNombre.Value = nombre;
            this.com.Parameters.Add(pamNombre);
            //LOS PARAMETROS DE SALIDA DEBEMOS CREARLOS DE FORMA EXPLICITA.
            //EN ESTE EJEMPLO, NO HEMOS PUESTO VALORES POR DEFECTO A LOS PARAMETROS POR LO QUE SN OBLIGATORIOS
            SqlParameter pamSuma = new SqlParameter();
            pamSuma.ParameterName = "@suma";
            pamSuma.Value = 0;//tendremos que hacerlo para que no nos de error string[1]
            //QUÉ VALUE ENVIAMOS AL PROCEDIMIENTO??
            pamSuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamSuma);

            SqlParameter pamMedia = new SqlParameter();
            pamMedia.ParameterName = "@media";
            pamMedia.Value = 0;//tendremos que hacerlo para que no nos de error string[1]
            //QUÉ VALUE ENVIAMOS AL PROCEDIMIENTO??
            pamMedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamMedia);

            SqlParameter pamPersonas = new SqlParameter();
            pamPersonas.ParameterName = "@personas";
            pamPersonas.Value = 0;//tendremos que hacerlo para que no nos de error string[1]
            //QUÉ VALUE ENVIAMOS AL PROCEDIMIENTO??
            pamPersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamPersonas);

            //A JUGAR
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.lstEmpleados.Items.Clear();

            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEmpleados.Items.Add(apellido);
            }
            await this.reader.CloseAsync();//SE CAMBIA DE ORDEN EL READER
            //DIBUJAMOS LOS PARAMETROS
            this.txtSumaSalarial.Text = pamSuma.Value.ToString();
            this.txtMediaSalarial.Text = pamMedia.Value.ToString();
            this.txtPersonas.Text = pamPersonas.Value.ToString();

            //LIBERAMOS LOS RECURSOS Y LA CONEXION

            
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

        }
    }
}
