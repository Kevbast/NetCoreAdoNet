using NetCoreAdoNet.Models;
using NetCoreAdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetCoreAdoNet
{
    public partial class Form09CrudHospital : Form
    {
        RepositoryHospitales repo;
        public Form09CrudHospital()
        {
            InitializeComponent();
            this.repo = new RepositoryHospitales();
            this.LoadHospitales();
        }
        //creamos un dept siempre con task!!
        //Revisar el Task si falla con punto de interrupción
        private async Task LoadHospitales()
        {
            List<Hospitales> hospitales = await this.repo.GetHospitalesAsync();
            this.lstHospitales.Items.Clear();
            //FOREACH CON MODEL
            foreach (Hospitales hospi in hospitales)
            {
                this.lstHospitales.Items.Add(hospi.IdHospital + "--" +
                    hospi.Nombre + "--" + hospi.Direccion + "--" + hospi.Telefono
                    + "--" + hospi.NumeroCamas);
            }

        }

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtIdHospital.Text);
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;
            int numcamas = int.Parse(this.txtNumCamas.Text);

            await this.repo.CreateHospitalAsync(id,nombre,direccion,telefono,numcamas);
            await this.LoadHospitales();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtIdHospital.Text);
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;
            int numcamas = int.Parse(this.txtNumCamas.Text);

            await this.repo.UpdateHospitalesAsync(id, nombre, direccion, telefono, numcamas);
            await this.LoadHospitales();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtIdHospital.Text);
            await this.repo.DeleteHospitalAsync(id);
            await this.LoadHospitales();
        }
    }
}
