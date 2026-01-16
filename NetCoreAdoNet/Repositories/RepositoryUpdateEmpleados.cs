using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryUpdateEmpleados
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryUpdateEmpleados()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }
        //estavez no creamos model
        public async Task<List<string>> GetOficiosAsync()
        {
            string sql = "select distinct OFICIO from EMP";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();
            List<string> oficiosList = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string oficio = this.reader["OFICIO"].ToString();
                oficiosList.Add(oficio);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return oficiosList;//devolvemos la lista
        }

        public async Task<List<string>> GetEmpleadosByOficiosAsync(string oficio)
        {
            string sql = "select APELLIDO from EMP where OFICIO=@oficio";
            this.com.Parameters.AddWithValue("@oficio",oficio);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> apellidos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string ape = this.reader["APELLIDO"].ToString();
                apellidos.Add(ape);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            //LIMPIAMOS LOS PARAMS!!
            this.com.Parameters.Clear();
            return apellidos;//devolvemos la lista
        }

        //UPDATE SALARIO EMPLEADO
        //devolvemos el num de registros
        public async Task<int> UpdateSalarioEmpleadosAsync(string oficio,int incremento)
        {
            string sql = "update EMP set SALARIO=SALARIO + @incremento where OFICIO=@oficio";
            this.com.Parameters.AddWithValue("@incremento", incremento);
            this.com.Parameters.AddWithValue("@oficio", oficio);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            int registros = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            //limpiamos
            this.com.Parameters.Clear();
            //devolvemos el num de los registros actualizados
            return registros;
        }

        //SUMASALARIAL
        public async Task<List<string>> GetMetodosSalariosAsync(string oficio)
        {
            string sql = "SELECT SUM(SALARIO) AS SUMASALARIAL" +
                ",AVG(SALARIO) AS MEDIASALARIAL ,MAX(SALARIO) AS SALARIOMAX FROM EMP WHERE OFICIO=@oficio";
            this.com.Parameters.AddWithValue("@oficio", oficio);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> salarios = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string suma = this.reader["SUMASALARIAL"].ToString();
                string media = this.reader["MEDIASALARIAL"].ToString();
                string max = this.reader["SALARIOMAX"].ToString();
                salarios.Add(suma);
                salarios.Add(media);
                salarios.Add(max);
            }
            return salarios;
        }


    }
}
