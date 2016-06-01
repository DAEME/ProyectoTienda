using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFTiendaServices.Errores
{
    
    public class ClienteInexistenteError
    {
        
        public int CodigoError { get; set; }
        
        public string MensajeError { get; set; }
    }
}