using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFTiendaServices.Dominio
{
    [DataContract]
    public class Producto
    {
        [DataMember]
        public int co_producto { get; set; }
        [DataMember]
        public string tx_descripcion { get; set; }
        [DataMember]
        public decimal nu_precio { get; set; }
    }
}