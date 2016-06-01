using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFTiendaServices.Dominio;
using WCFTiendaServices.Errores;

namespace WCFTiendaServices
{
    [ServiceContract]
    public interface IProductoService
    {//STPSDSADSAD
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ProductoService", ResponseFormat = WebMessageFormat.Json)]
        Producto CrearProducto(Producto productoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ProductoService/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Producto ObtenerProducto(string codigo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "ProductoService", ResponseFormat = WebMessageFormat.Json)]
        Producto ModificarProducto(Producto productoAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "ProductoService/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarProducto(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ProductoService", ResponseFormat = WebMessageFormat.Json)]
        ICollection<Producto> ListarProductos();
    }
}
