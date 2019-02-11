using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Web;
using PAEDUCA.Controllers.AppConfigs;

namespace PAEDUCA.Models
{
    public class Conexion
    {

        private static EntityConnectionStringBuilder conexion = null;
        private static String obtenerConexion() 
        { 
            if(conexion==null)
            {
                conexion = new EntityConnectionStringBuilder();
                conexion.Provider = "System.Data.SqlClient";
                conexion.ProviderConnectionString = "Data Source="+Configuraciones.USUARIO_BD+";Initial Catalog=+"+Configuraciones.NOMBRE_BD+";User ID="+Configuraciones.USUARIO_BD+";Password="+Configuraciones.PASS_BD+";multipleactiveresultsets=True;application name=EntityFramework";
                conexion.Metadata = "res://*/EF_PAEDUCA.csdl|res://*/EF_PAEDUCA.ssdl|res://*/EF_PAEDUCA.msl";
            }

            return conexion.ToString();
        }

    }
}