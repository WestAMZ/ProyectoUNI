using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Web;
using PAEDUCA.Controllers.Configuraciones;
using System.Data.Entity.Infrastructure;

namespace PAEDUCA.DAL
{
    public class Conexion
    {

        public string conexion = null;
        private EntityConnectionStringBuilder builder = null;
        public  Conexion()
        { 
            if(builder==null)
            {
                builder = new EntityConnectionStringBuilder();
                //builder.Provider = "System.Data.SqlClient";
                builder.ProviderConnectionString = "Data Source="+Configuraciones.USUARIO_BD+";Initial Catalog=+"+Configuraciones.NOMBRE_BD+";User ID="+Configuraciones.USUARIO_BD+";Password="+Configuraciones.PASS_BD+";multipleactiveresultsets=True;application name=EntityFramework";
                //builder.Metadata = "res://*/PAEDUCA.csdl|res://*/PAEDUCA.ssdl|res://*/PAEDUCA.msl";
            }

            conexion =  builder.ToString();
        }

    }
}