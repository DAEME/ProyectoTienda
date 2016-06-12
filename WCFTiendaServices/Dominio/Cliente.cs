using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFTiendaServices.Dominio
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public string nu_ruc { get; set; }
        [DataMember]
        public string tx_nombre { get; set; }
        [DataMember]
        public string tx_direccion { get; set; }
        [DataMember]
        public int bcatalogoid { get; set; }
    }
}