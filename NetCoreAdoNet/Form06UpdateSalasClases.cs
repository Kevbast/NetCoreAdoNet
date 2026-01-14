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
    public partial class Form06UpdateSalasClases : Form
    {
        //instanciamos el repositorio
        RepositorySalas repo;
        public Form06UpdateSalasClases()
        {
            InitializeComponent();
            this.repo = new RepositorySalas();
            this.LoadSalas();
        }
        //COMO ES UNA CLASE GRÁFICA NO PONGO TASK
        private async void LoadSalas()
        {
            List<string> salas = await this.repo.GetNombreSalasAsync();
            this.lstSalas.Items.Clear();
            foreach (string nombre in salas)
            {
                this.lstSalas.Items.Add(nombre); 
            }
        }
        //COMO ES UNA CLASE GRÁFICA NO PONGO TASK
        private async void btnUpdateSalas_Click(object sender, EventArgs e)
        {
            string newName = this.txtNombre.Text;
            string oldName = this.lstSalas.SelectedItem.ToString();
            int registros = await this.repo.UpdateSalaAsync(newName,oldName);
            MessageBox.Show("Modificados: "+ registros);
            this.LoadSalas();
        }
    }
}
