using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFTiendaServices.Errores
{
    //[DataContract]
    public class ClienteInexistenteError
    {
        //[DataMember]
        public int CodigoError { get; set; }
        //[DataMember]
        public string MensajeError { get; set; }
    }
}