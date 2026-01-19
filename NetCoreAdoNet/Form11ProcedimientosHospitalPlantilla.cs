using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#region PROCEDIMIENTOS ALMACENADOS
/*
 create procedure SP_ALL_HOSPITALES
as
	select * from HOSPITAL
go

create procedure SP_UPDATE_PLANTILLA_HOSPITAL(@nombre as NVARCHAR(50),@incremento int)
as
	declare @hospitalcod int
	select @hospitalcod=HOSPITAL_COD from HOSPITAL where NOMBRE=@nombre
	update PLANTILLA set SALARIO = SALARIO + @incremento where HOSPITAL_COD=@hospitalcod
go

create procedure SP_PLANTILLA_HOSPITAL(@nombre nvarchar(50))
as
	select PLANTILLA.* from PLANTILLA inner join HOSPITAL on HOSPITAL.HOSPITAL_COD=PLANTILLA.HOSPITAL_COD
	where HOSPITAL.NOMBRE=@nombre
go
 */
#endregion
namespace NetCoreAdoNet
{
    public partial class Form11ProcedimientosHospitalPlantilla : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form11ProcedimientosHospitalPlantilla()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadHospitales();
        }
        //creamos método cargar hospi
        private async Task LoadHospitales()
        {
            string sql = "SP_ALL_HOSPITALES";//nombre del procedimiento
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.cmbHospitales.Items.Clear();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                this.cmbHospitales.Items.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
        }

        //Es void,no task
        private async void btnModificarSalarios_Click(object sender, EventArgs e)
        {
            //SI TENEMOS PARAMETROS DEBEMOS INCLUIRLOS EN EL COM,NO EN LA CONSULTA
            string sql = "SP_UPDATE_PLANTILLA_HOSPITAL";
            string nombreHospital = this.cmbHospitales.SelectedItem.ToString();
            int incremento = int.Parse(this.txtIncremento.Text);
            this.com.Parameters.AddWithValue("@nombre",nombreHospital);
            this.com.Parameters.AddWithValue("@incremento", incremento);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            int registros = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            await this.LoadPlantilla(nombreHospital);//lo creamos ahora este método
            MessageBox.Show("REGISTROS MODIFICADOS: "+ registros);
        }

        private async Task LoadPlantilla(string nombreHospital)
        {
            string sql = "SP_PLANTILLA_HOSPITAL";//nombre del procedimiento
            this.com.Parameters.AddWithValue("@nombre", nombreHospital);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.lstPlantilla.Items.Clear();
            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                string salario = this.reader["SALARIO"].ToString();
                this.lstPlantilla.Items.Add(apellido +" - " + salario);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            //LIMPIAMOS PARAMS
            this.com.Parameters.Clear();

        }

    }
}
