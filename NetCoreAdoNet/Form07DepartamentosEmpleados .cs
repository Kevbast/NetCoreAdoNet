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
        //CLASE GRAFICA ES VOID EL ASYNC
        private async void loadDepartamentos()
        {
            List<string> departamentos = await this.repo.GetNombreDepartamentosAsync();
            this.lstDepartamentos.Items.Clear();
            foreach (string departamento in departamentos)
            {
                this.lstDepartamentos.Items.Add(departamento);
            }
        }
        //CLASE GRAFICA ES VOID EL ASYNC
        //CARGAMOS LOS EMPLEADOS DE ESE DEPARTAMENTO
        private async void loadEmpleadosPorDepartamento(string nombredept)
        {
            List<string> empleados = await this.repo.GetNombreEmpleadosPorNombreDeptAsync(nombredept);
            this.lstEmpleados.Items.Clear();
            foreach (string empleado in empleados)
            {
                this.lstEmpleados.Items.Add(empleado);
            }
        }
        //CLASE GRAFICA ES VOID EL ASYNC
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //ATENTOS LOS NOMBRES
            string nombreEmp=this.lstEmpleados.SelectedItem.ToString();
            int registros =await this.repo.DeleteEmpleadoDeptAsync(nombreEmp);
            MessageBox.Show("EMPLEADOS ELIMINADOS: " + registros);
            //ESTE MÉTODO NO ES TASK,POR LO TANTO NO USAMOS AWAITT!!! ATENTOS CON ESO,podríamos crear
            //uno que sea task pero ahí si usaríamos await
            this.loadEmpleadosPorDepartamento(this.lstDepartamentos.SelectedItem.ToString());
            //se podría llamar a lstDepartamentos_SelectedIndexChanged(null,null) solo poniendo esto
        }
        //CLASE GRAFICA ES VOID EL ASYNC
        //SELECCIONAMOS EL DEPT Y PASAMOS EL NOMBRE A LA CLASE
        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = this.lstDepartamentos.SelectedItem.ToString();
            this.loadEmpleadosPorDepartamento(nombre);
        }

        //EN LOS METODOS DELEGADOS VAN LOS VOID SIEMPRE
        //LOS DEMÁS TASK,ASI QUE loadEmpleadosPorDepartamento DEBERÍA SER TASK AUNQUE FUNCIONE
    }
}
