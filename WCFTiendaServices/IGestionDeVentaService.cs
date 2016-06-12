using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTiendaServices.Dominio;
using WCFTiendaServices.Errores;

namespace WCFTiendaServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVentaService" in both code and config file together.
    [ServiceContract]
    public interface IGestionDeVentaService
    {
        [OperationContract]
        [FaultContract(typeof(ClienteInexistenteError))]
        Venta Vender(string nu_ruc, List<Item> items);

        [OperationContract]
        ClienteWS.Cliente ObtenerCliente(string nu_ruc);

        [OperationContract]
        Producto ObtenerProducto(int codigo);

        [OperationContract]
        ICollection<Venta> ListarVentas();
    }
}
