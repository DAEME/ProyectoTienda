using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFTiendaServices.Dominio
{
    [DataContract]
    public class VentaDetalle
    {
        [DataMember]
        public VentaDetallePK pk { get; set; }
        [DataMember]
        public int nu_cantidad { get; set; }
        [DataMember]
        public decimal nu_subtotal { get; set; }
    }

    [DataContract]
    public class VentaDetallePK
    {
        [DataMember]
        public Venta nu_venta { get; set; }
        [DataMember]
        public Producto co_producto { get; set; }
    }
}