using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFTiendaServices.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            return "Data Source=INCAD_PC001\\SQLEXPRESS;Initial Catalog=BDProyectoTienda;Integrated Security=SSPI;User Id=Eric;";
            //return "Data Source=4d0d91c6-2d3d-41a3-b56f-a60b00947775.sqlserver.sequelizer.com;Initial Catalog=db4d0d91c62d3d41a3b56fa60b00947775;User ID=fwoetykjuanjzoyi;Password=3RVHSF2kE5eYi2MxCE4HPLvAmZoKpSCS2BY5zvQNaxMY3Gn5vh2xMxMpuuvZsq5U;";
        }
    }
}