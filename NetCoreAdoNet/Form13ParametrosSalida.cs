using Microsoft.Data.SqlClient;
using NetCoreAdoNet.Models;
using NetCoreAdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace NetCoreAdoNet
{
    public partial class Form13ParametrosSalida : Form
    {
        RepositoryParametersOut repo;
        public Form13ParametrosSalida()
        {
            InitializeComponent();
            this.repo = new RepositoryParametersOut();
            this.LoadDepartamentos();
        }
        private async Task LoadDepartamentos()
        {
            List<string> departamentos = await this.repo.GetDepartamentosAsync();
            this.cmbDepartamentos.Items.Clear();
            foreach (string nombre in departamentos)
            {
                this.cmbDepartamentos.Items.Add(nombre);
            }

        }

        private async void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            string nombre = this.cmbDepartamentos.SelectedItem.ToString();
            EmpleadosParametersOut model = await this.repo.GetEmpleadosModelAsync(nombre);

            this.lstEmpleados.Items.Clear();

            foreach (string ape in model.Apellidos)
            {
                this.lstEmpleados.Items.Add(ape);
            }
            this.txtSumaSalarial.Text = model.SumaSalarial.ToString();
            this.txtMediaSalarial.Text = model.MediaSalarial.ToString();
            this.txtPersonas.Text = model.Personas.ToString();
        }
    }
}
