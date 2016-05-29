using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFTiendaServices.Dominio
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int co_producto { get; set; }
        [DataMember]
        public int nu_cantidad { get; set; }
    }
}