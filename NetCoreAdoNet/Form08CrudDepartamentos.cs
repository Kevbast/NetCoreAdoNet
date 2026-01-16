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
    public partial class Form08CrudDepartamentos : Form
    {
        RepositoryDepartamento repo;
        public Form08CrudDepartamentos()
        {
            InitializeComponent();
            repo = new RepositoryDepartamento();
            this.LoadDepartamentos();
        }

        //creamos un dept siempre con task!!
        //Revisar el Task si falla con punto de interrupción
        private async Task LoadDepartamentos()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            this.lstDepartamentos.Items.Clear();
            //FOREACH CON MODEL
            foreach (Departamento dept in departamentos)
            {
                this.lstDepartamentos.Items.Add(dept.IdDepartamento + "--" +
                    dept.Nombre + "--" + dept.Localidad);
            }

        }

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;

            await this.repo.CreateDepartamentoAsync(id,nombre,localidad);
            await this.LoadDepartamentos();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;

            await this.repo.UpdateDepartamentoAsync(id, nombre, localidad);
            await this.LoadDepartamentos();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            await this.repo.DeleteDepartamentoAsync(id);
            await this.LoadDepartamentos();

        }
    }
}
