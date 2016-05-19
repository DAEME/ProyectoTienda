using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFTiendaServices.Dominio
{
    [DataContract]
    public class Venta
    {
        [DataMember]
        public int nu_venta { get; set; }
        [DataMember]
        public string nu_ruc { get; set; }
        [DataMember]
        public DateTime dt_fecha { get; set; }
        [DataMember]
        public decimal nu_total { get; set; }
    }
}