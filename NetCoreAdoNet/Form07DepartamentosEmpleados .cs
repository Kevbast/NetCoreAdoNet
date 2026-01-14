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
    public partial class Form07DepartamentosEmpleados : Form
    {
        RepositoryDepartamentosEmpleados repo;
        public Form07DepartamentosEmpleados()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentosEmpleados();
            //llamamos a los departamentos
            this.loadDepartamentos();
        }
        private async void loadDepartamentos()
        {
            List<string> departamentos = await this.repo.GetNombreDepartamentosAsync();
            this.lstDepartamentos.Items.Clear();
            foreach (string departamento in departamentos)
            {
                this.lstDepartamentos.Items.Add(departamento);
            }
        }

        //CARGAMOS LOS EMPLEADOS DE ESE DEPARTAMENTO
        private async void loadEmpleadosPorDepartamento(string nombredept)
        {
            List<string> empleados = await this.repo.getNombreEmpleadosPorNombreDeptAsync(nombredept);
            this.lstEmpleados.Items.Clear();
            foreach (string empleado in empleados)
            {
                this.lstEmpleados.Items.Add(empleado);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //ATENTOS LOS NOMBRES
            string nombreEmp=this.lstEmpleados.SelectedItem.ToString();
            int registros =await this.repo.deleteEmpleadoDeptAsync(nombreEmp);
            MessageBox.Show("EMPLEADOS ELIMINADOS: " + registros);

            this.loadEmpleadosPorDepartamento(this.lstDepartamentos.SelectedItem.ToString());
        }

        //SELECCIONAMOS EL DEPT Y PASAMOS EL NOMBRE A LA CLASE
        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = this.lstDepartamentos.SelectedItem.ToString();
            this.loadEmpleadosPorDepartamento(nombre);
        }
    }
}
