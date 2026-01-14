using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAdoNet.Models
{//CREAREMOS EN REPO RepositoryDepartamento
    public class Departamento
    {
        public int IdDepartamento { get; set; }//no recomendable llamar Id solo
        public string Nombre { get; set; }
        public string Localidad { get; set; }

    }
}
