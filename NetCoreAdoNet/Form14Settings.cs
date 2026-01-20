using Microsoft.Extensions.Configuration;
using NetCoreAdoNet.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCoreAdoNet
{
    public partial class Form14Settings : Form
    {
        public Form14Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//LEER SETTINGS BUTTON
            //NECESITAMOS UN CONSTRUCTOR DE CONFIGURACIONES
            ConfigurationBuilder builder = new ConfigurationBuilder();
            //EN ESTE ENTORNO DE PROYECTO,SETTINGS NO ES NATIVO,ES DECIR
            //A PESAR DE LLAMARLO appsettings.json, NO LO RECONOCE
            //DEBEMOS INDICAR LA UBICACIÓN DEL FICHERO
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);//false,execp si no lo encuentra
            //NECESITAMOS EL OBJETO PARA RECUPERAR LAS KEYS
            IConfigurationRoot configuration = builder.Build();
            //EXISTEN KEYS YA CONFIGURADAS Y PODEMOS RECUPERARLAS CON METODOS NATIVOS
            //LAS KEYS DIFERENCIA MAYUSCULAS Y MINUSCULAS
            string connectionString = configuration.GetConnectionString("SqlLocalTajamar");

            this.lblConexion.Text = connectionString;
            //SI NO SON KEYS CONOCIDAS,DEBEMOS NAVEGAR HASTA ELLAS,LA NAVEGACIÓN SE 
            //ESTABLECE MEDIANTE:
            //Keyprincipal:subkey
            //Keyprincipal:subkey:otrasubkey
            string imagen1 = configuration.GetSection("Imagenes:imagen1").Value;
            string imagen2 = configuration.GetSection("Imagenes:imagen2").Value;
            string colorLetra = configuration.GetSection("Colores:letra").Value;
            string colorFondo = configuration.GetSection("Colores:fondo").Value;

            //CARGAMOSS
            this.pictureBox1.Load(imagen1);
            this.pictureBox2.Load(imagen2);

            this.BackColor = Color.FromName(colorFondo);
            this.lblConexion.ForeColor = Color.FromName(colorLetra);

        }

        private void btnLeerHelperConfiguration_Click(object sender, EventArgs e)
        {
            IConfigurationRoot configuration = HelperConfiguration.GetConfiguration();

            string connectionString = configuration.GetConnectionString("SqlLocalTajamar");

            this.lblConexion.Text = connectionString;
            //SI NO SON KEYS CONOCIDAS,DEBEMOS NAVEGAR HASTA ELLAS,LA NAVEGACIÓN SE 
            //ESTABLECE MEDIANTE:
            //Keyprincipal:subkey
            //Keyprincipal:subkey:otrasubkey
            string imagen1 = configuration.GetSection("Imagenes:imagen1").Value;
            string imagen2 = configuration.GetSection("Imagenes:imagen2").Value;
            string colorLetra = configuration.GetSection("Colores:letra").Value;
            string colorFondo = configuration.GetSection("Colores:fondo").Value;

            //CARGAMOSS
            this.pictureBox1.Load(imagen1);
            this.pictureBox2.Load(imagen2);

            this.BackColor = Color.FromName(colorFondo);
            this.lblConexion.ForeColor = Color.FromName(colorLetra);
        }
    }
}
