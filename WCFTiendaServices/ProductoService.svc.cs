using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFTiendaServices.Dominio;
using WCFTiendaServices.Errores;
using WCFTiendaServices.Persistencia;

namespace WCFTiendaServices
{
      public class ProductoService : IProductoService     
    {
        private ProductoDAO productoDAO = new ProductoDAO();

        private void enviarMensaje()
        {
            string rutaCola = @".\private$\catalogo";
            if (!MessageQueue.Exists(rutaCola))
            {
                MessageQueue.Create(rutaCola);
            }
            MessageQueue cola = new MessageQueue(rutaCola);
            Message mensaje = new Message();
            mensaje.Label = "Nuevo Precio";
            mensaje.Body = new Catalogo() {bcatalogoid = 1 };
            cola.Send(mensaje);
        }

        public Producto CrearProducto(Producto productoACrear)
        {
            Producto objProd = new Producto();
            objProd = productoDAO.Obtener(Convert.ToInt32(productoACrear.co_producto));

            if (productoACrear.co_producto != 0)
            { 
                if (productoACrear.tx_descripcion == objProd.tx_descripcion)
                {
                    throw new WebFaultException<string>(
                       "El producto ya existe", HttpStatusCode.InternalServerError);

                }
            }

            return productoDAO.Crear(productoACrear);
        }

        public void EliminarProducto(string codigo)
        {
            productoDAO.EliminarN(Convert.ToInt32(codigo));
        }

        public ICollection<Producto> ListarProductos()
        {
            return productoDAO.ListarTodos();
        }

        public Producto ModificarProducto(Producto productoAModificar)
        {
            Producto prodAnterior = new Producto();
            prodAnterior = ObtenerProducto(productoAModificar.co_producto.ToString());

            
            if (productoAModificar.nu_precio < prodAnterior.nu_precio)
            {
                enviarMensaje();
            }

            return productoDAO.Modificar(productoAModificar);
        }

        public Producto ObtenerProducto(string codigo)
        {
            if (productoDAO.Obtener(Convert.ToInt32(codigo)) == null)
            {
                throw new WebFaultException<string>(
                   "El producto no existe", HttpStatusCode.InternalServerError);
            }

            return productoDAO.Obtener(Convert.ToInt32(codigo));
        }

       

    }
}
