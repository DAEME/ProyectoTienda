using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFTiendaServices.Dominio;

namespace WCFTiendaServices.Persistencia
{
    public class VentaDAO:BaseDAO<Venta,int>
    {
    }

    public class VentaDetalleDAO : BaseDAO<VentaDetalle, VentaDetallePK>
    {
    }
}