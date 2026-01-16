using Microsoft.Data.SqlClient;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryHospitales
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        //agregamos un constructor y una cadena de conexion
        public RepositoryHospitales()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        //creamos el primer método cargar hospitales

        public async Task<List<Hospitales>> GetHospitalesAsync()
        {
            string sql = "select * from HOSPITAL";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            //ALMACENAMOS TODOS LOS HOSPITALES MODELS
            List<Hospitales> hospitales = new List<Hospitales>();

            while (await this.reader.ReadAsync())
            {
                //creamos una instancia
                Hospitales hospi = new Hospitales();
                //REVISAR LOS NOMBRES
                hospi.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospi.Nombre = this.reader["NOMBRE"].ToString();
                hospi.Direccion = this.reader["DIRECCION"].ToString();
                hospi.Telefono = this.reader["TELEFONO"].ToString();
                hospi.NumeroCamas = int.Parse(this.reader["NUM_CAMA"].ToString());

                hospitales.Add(hospi);

            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return hospitales;
        }

        //CREAMOS UN HOSPITAL
        public async Task CreateHospitalAsync
            (int id, string nombre,string direccion,string telefono,int numcamas)
        {
            string sql = "insert into HOSPITAL values(@id,@nombre,@direccion,@telefono,@numcamas)";
            SqlParameter pamId = new SqlParameter("@id", id);
            SqlParameter pamNombre = new SqlParameter("@nombre", nombre);
            SqlParameter pamDireccion = new SqlParameter("@direccion", direccion);
            SqlParameter pamTelefono = new SqlParameter("@telefono", telefono);
            SqlParameter pamNumCamas = new SqlParameter("@numcamas", numcamas);
            //añadimos
            this.com.Parameters.Add(pamId);
            this.com.Parameters.Add(pamNombre);
            this.com.Parameters.Add(pamDireccion);
            this.com.Parameters.Add(pamTelefono);
            this.com.Parameters.Add(pamNumCamas);

            //configuramos la consulta
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            //limpiamos los params
            this.com.Parameters.Clear();

        }
        
        //ACTUALIZAMOS
        public async Task UpdateHospitalesAsync
            (int id, string nombre, string direccion, string telefono, int numcamas)
        {
            string sql = "update HOSPITAL set NOMBRE=@nombre," +
                "DIRECCION=@direccion,TELEFONO=@telefono,NUM_CAMA=@numcamas where HOSPITAL_COD=@id";
            //TENEMOS UN MÉTODO EN EL COMMAND QUE NOS PERMITE AÑADIR PARAMETROS
            //SIN CREAR OBJETOS,SIEMPRE QUE SEAN DE TIPO PRIMITIVO,no acostumbrarse a ello
            this.com.Parameters.AddWithValue("@id", id);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@direccion", direccion);
            this.com.Parameters.AddWithValue("@telefono", telefono);
            this.com.Parameters.AddWithValue("@numcamas", numcamas);

            //configuramos la consulta
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            //limpiamos
            this.com.Parameters.Clear();
        }
        //DELETE HOSPITAL
        public async Task DeleteHospitalAsync(int id)
        {
            string sql = "delete from HOSPITAL where HOSPITAL_COD=@id";
            this.com.Parameters.AddWithValue("@id", id);

            //configuramos la consulta
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            //limpiamos
            this.com.Parameters.Clear();
        }

    }
}
