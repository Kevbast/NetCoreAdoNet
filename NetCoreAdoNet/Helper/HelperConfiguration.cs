using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAdoNet.Helper
{
    public class HelperConfiguration
    {
        //TENEMOS VARIAS OPCIONES
        //DEPENDIENDO DEL TIPO DE LÓGICA,PODEMOS PENSAR DE UNA FORMA O DE OTRA
        //QUEREMOS RECUPERAR EL OBJETO CONFIGURATION
        public static IConfigurationRoot GetConfiguration()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            //DEBEMOS INDICAR LA UBICACIÓN DEL FICHERO
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);//false,execp si no lo encuentra
            //NECESITAMOS EL OBJETO PARA RECUPERAR LAS KEYS
            IConfigurationRoot configuration = builder.Build();

            return configuration;
        }
    }
}
