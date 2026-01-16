using Microsoft.Data.SqlClient;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryDepartamento
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;
        //agregamos constructor y cadena de conexion
        public RepositoryDepartamento()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }
        //REVISAR LOS PUNTOS DE INTERRUPCIÓN
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            string sql = "select * from DEPT";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();

            //almacenaremos todos los dpts models
            List<Departamento> departamentos = new List<Departamento>();

            while (await this.reader.ReadAsync())//await
            {
                //creamos una instancia
                Departamento dept = new Departamento();
                dept.IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
                dept.Nombre = this.reader["DNOMBRE"].ToString();
                dept.Localidad = this.reader["LOC"].ToString();//REVISAR LOS NOMBRES
                departamentos.Add(dept);//añadimos los depts
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return departamentos;
        }

        //CREAMOS UN DEPT
        public async Task CreateDepartamentoAsync(int id,string nombre,string localidad)
        {
            string sql = "insert into DEPT values (@id,@nombre,@localidad)";
            SqlParameter pamId = new SqlParameter("@id",id);
            SqlParameter pamNombre = new SqlParameter("@nombre",nombre);
            SqlParameter pamLoc = new SqlParameter("@localidad",localidad);
            //añadimos
            this.com.Parameters.Add(pamId);
            this.com.Parameters.Add(pamNombre);
            this.com.Parameters.Add(pamLoc);

            //configuramos la consulta
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            //limpiamos
            this.com.Parameters.Clear();
        }

        //ATUALIZAMOS DEPT
        public async Task UpdateDepartamentoAsync(int id, string nombre, string localidad)
        {
            string sql = "update DEPT set DNOMBRE=@nombre,LOC=@localidad where DEPT_NO=@id";
            //TENEMOS UN MÉTODO EN EL COMMAND QUE NOS PERMITE AÑADIR PARAMETROS
            //SIN CREAR OBJETOS,SIEMPRE QUE SEAN DE TIPO PRIMITIVO,no acostumbrarse a ello
            this.com.Parameters.AddWithValue("@id",id);
            this.com.Parameters.AddWithValue("@nombre",nombre);
            this.com.Parameters.AddWithValue("@localidad",localidad);

            //configuramos la consulta
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            //limpiamos
            this.com.Parameters.Clear();
        }

        //DELETE DEPT

        public async Task DeleteDepartamentoAsync(int id)
        {
            string sql = "delete from DEPT where DEPT_NO=@id";
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
