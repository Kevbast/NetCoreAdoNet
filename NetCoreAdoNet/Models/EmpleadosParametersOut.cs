using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAdoNet.Models
{
    public class EmpleadosParametersOut
    {
        public List<string> Apellidos { get; set; }

        public int SumaSalarial { get; set; }
        public int MediaSalarial { get; set; }
        public int Personas { get; set; }

        //declaramos en el constructor
        public EmpleadosParametersOut()
        {
            Apellidos = new List<string>();
        }

    }
}
