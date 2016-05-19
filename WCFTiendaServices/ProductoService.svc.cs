using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTiendaServices.Dominio;
using WCFTiendaServices.Errores;
using WCFTiendaServices.Persistencia;

namespace WCFTiendaServices
{
      public class ProductoService : IProductoService     
    {
        private ProductoDAO productoDAO = new ProductoDAO();

        public Producto CrearProducto(Producto productoACrear)
        {
            if (productoDAO.Obtener(productoACrear.co_producto) != null)
            {
                throw new FaultException<ClienteInexistenteError>(

                    new ClienteInexistenteError()
                    {
                        CodigoError = 101,
                        MensajeError = "El producto ya existe"
                    },
                    new FaultReason("Error al intentar creación"));
            }

            return productoDAO.Crear(productoACrear);
        }

        public Producto ObtenerProducto(int co_producto)
        {
            return productoDAO.Obtener(co_producto);
        }

        public Producto ModificarProducto(Producto productoAModificar)
        {
            return productoDAO.Modificar(productoAModificar);
        }
      
        public void EliminarProducto(Producto productoAEliminar)
        {
            productoDAO.Eliminar(productoAEliminar);
        }

        public ICollection<Producto> ListarProductos()
        {
            return productoDAO.ListarTodos();
        }

    }
}
