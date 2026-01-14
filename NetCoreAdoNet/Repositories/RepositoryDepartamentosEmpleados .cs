using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryDepartamentosEmpleados
    {
        //1.ESTABLACEMOS CONEXION
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public RepositoryDepartamentosEmpleados()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
        }
        //como lo vamos a hacer asincrono las clases serán con TASK
        public async Task<List<string>> GetNombreDepartamentosAsync()
        {//METODO QUE NOS DEVUELVE UNA CONEXION
            string sql = "select distinct DNOMBRE from DEPT";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            //CREAMOS UNA COLECCION PARA DEPT
            List<string> departamentos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                departamentos.Add(nombre);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return departamentos;

        }

        //CARGAMOS LOS EMPLEADOS DEL DEPARTAMENTO ESCOGIDO

        public async Task<List<string>> getNombreEmpleadosPorNombreDeptAsync(string nombredept)
        {
            string sql = "select APELLIDO from EMP inner join DEPT on DEPT.DEPT_NO=EMP.DEPT_NO " +
                "where DNOMBRE=@nombredept";
            SqlParameter pamName = new SqlParameter("@nombredept", nombredept);
            this.com.Parameters.Add(pamName);//AÑADIMOS EL PARAM
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            //CREAMOS UNA COLECCION PARA DEPT
            List<string> empleados = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["APELLIDO"].ToString();
                empleados.Add(nombre);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            //LIMPIAMOS LOS PARAMS
            this.com.Parameters.Clear();
            return empleados;

        }

        public async Task<int> deleteEmpleadoDeptAsync(string nombreEmp)
        {
            string sql = "delete from EMP where APELLIDO=@nombreEmp"; 
            SqlParameter pamName = new SqlParameter("@nombreEmp", nombreEmp);
            this.com.Parameters.Add(pamName);//añadimos el param
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            //LAS CONSULTAS DE ACCION DEVUELVEN UN int CON EL NUMERO DE  
            //REGISTROS AFECTADOS 
             int registros = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            //limpiamos los params
            this.com.Parameters.Clear();
            return registros;
        }


    }
}
