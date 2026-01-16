using NetCoreAdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCoreAdoNet
{
    public partial class Form10UpdateEmpleadosOficios : Form
    {
        RepositoryUpdateEmpleados repo;
        public Form10UpdateEmpleadosOficios()
        {
            InitializeComponent();
            this.repo = new RepositoryUpdateEmpleados();
            this.LoadOficios();
        }
        //cargamos los oficios y los empleados de ese oficio
        private async Task LoadOficios()
        {
            List<string> oficios = await this.repo.GetOficiosAsync();
            this.lstOficios.Items.Clear();

            foreach (string ofi in oficios)
            {
                this.lstOficios.Items.Add(ofi);
            }

        }
        //ES UN ASYNC VOID!! RECUERDA
        private async void lstOficios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.lstOficios.SelectedIndex;
            if (index!=-1)
            {
                string oficio = this.lstOficios.SelectedItem.ToString();
                List<string> apellidos = await this.repo.GetEmpleadosByOficiosAsync(oficio);
                this.lstEmpleados.Items.Clear();
                //metemos los empleados
                foreach (string ape in apellidos)
                {
                    this.lstEmpleados.Items.Add(ape);
                }

                int SumaSalarial =0;

            }
        }
        //ES UN ASYNC VOID!! RECUERDA
        private async void btnSubirSalario_Click(object sender, EventArgs e)
        {
            int incremento = int.Parse(this.txtIncrementoSalario.Text);
            string oficio = this.lstOficios.SelectedItem.ToString();
            int registros = await this.repo.UpdateSalarioEmpleadosAsync(oficio,incremento);
            MessageBox.Show("REGISTROS AFECTADOS: "+ registros);

            List<string> num = await this.repo.GetMetodosSalariosAsync(oficio);

            this.lblSumaSalarial.Text= "SumaSalarial:"+num[0];
            this.lblMediaSalarial.Text= "Media Salarial:"+num[1];
            this.lblSalarioMaximo.Text= "Salario máximo:"+num[2];

        }

        
    }
}
