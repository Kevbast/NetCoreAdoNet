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
                this.lstDepartamentos.Items.Add(dept.IdDepartamento+"--"+
                    dept.Nombre+"--"+dept.Localidad);
            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }
    }
}
