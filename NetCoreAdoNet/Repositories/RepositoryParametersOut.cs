using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NetCoreAdoNet.Helper;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
----------------------------
ALTER procedure SP_EMPLEADOS_DEPARTAMENTOS_OUT
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
	select @suma=ISNULL(SUM(SALARIO),0),@media=ISNULL(AVG(SALARIO),0),@personas=COUNT(EMP_NO) from EMP where DEPT_NO=@iddept
go  
 */
#endregion

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryParametersOut
    {//NOS LLEVAMOS AQUÍ LA LÓGICA
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryParametersOut()
        {
            //Implementamos método static
            IConfigurationRoot configuration = HelperConfiguration.GetConfiguration();
            string connectionString = configuration.GetConnectionString("SqlLocalTajamar");
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetDepartamentosAsync()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            //Creamos list
            List<string> departamentos = new List<string>();

            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                departamentos.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return departamentos;//devolvemos
        }

        //Método que nos devuelva el model de empleados

        public async Task<EmpleadosParametersOut> 
            GetEmpleadosModelAsync(string nombredepartamento)
        {
            string sql = "SP_EMPLEADOS_DEPARTAMENTOS_OUT";
            //TENEOS UN PARAMETRO DE ENTRADA,POR DEFECTO TODOS SON DE ENTRADA,
            //PODEMOS SEGUIR UTILIZANDO ADDWITHVALUE CON DICHO PARAMETRO
            //this.com.Parameters.AddWithValue("@nombre",nombre);//esto vale tmb
            SqlParameter pamNombre = new SqlParameter();
            pamNombre.ParameterName = "@nombre";
            pamNombre.Value = nombredepartamento;//cambiamos a nombredept
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

            //creamosobjeto q es el model
            EmpleadosParametersOut model = new EmpleadosParametersOut();
            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                model.Apellidos.Add(apellido);
            }
            await this.reader.CloseAsync();//SE CAMBIA DE ORDEN EL READER
            //DIBUJAMOS LOS PARAMETROS,sustituimos por model aquí tmb
            //ESTABLECEMOS LOS DATOS
            model.SumaSalarial = int.Parse(pamSuma.Value.ToString());
            model.MediaSalarial = int.Parse(pamMedia.Value.ToString());
            model.Personas = int.Parse(pamPersonas.Value.ToString());

            //LIBERAMOS LOS RECURSOS Y LA CONEXION
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            //al final devolvemos el model
            return model;
        }


    }
}
