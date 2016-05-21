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
    [ServiceContract]
    public interface IProductoService
    {//
        [FaultContract(typeof(ClienteInexistenteError))]
        [OperationContract]
        Producto CrearProducto(Producto productoACrear); 

        [OperationContract]
        Producto ObtenerProducto(int co_producto);

        [OperationContract]
        Producto ModificarProducto(Producto productoAModificar);

        [OperationContract]
        void EliminarProducto(Producto productoAEliminar);

        [OperationContract]
        ICollection<Producto> ListarProductos();
    }
}
