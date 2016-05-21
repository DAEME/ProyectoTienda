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
        public VentaDetallePK Pk { get; set; }
        [DataMember]
        public int nu_cantidad { get; set; }
        [DataMember]
        public decimal nu_subtotal { get; set; }
        [DataMember]
        public Producto co_producto { get; set; }
    }

    [DataContract]
    public class VentaDetallePK
    {
        [DataMember]
        public int nu_venta { get; set; }

        [DataMember]
        public Producto co_producto { get; set; }
        
        public override bool Equals(object obj)
        {
            if (nu_venta == ((VentaDetallePK)obj).nu_venta ||
                co_producto == ((VentaDetallePK)obj).co_producto)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return nu_venta;
        }
    }
}