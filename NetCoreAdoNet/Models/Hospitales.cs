using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAdoNet.Models
{
    public class Hospitales
    {
        public int IdHospital { get; set;}
        public string Nombre { get; set;}
        public string Direccion { get; set;}
        public string Telefono { get; set;}
        public int NumeroCamas { get; set; }

    }
}
