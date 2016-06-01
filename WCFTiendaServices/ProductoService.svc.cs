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
            return productoDAO.Crear(productoACrear);
        }

        public void EliminarProducto(string codigo)
        {
            throw new NotImplementedException();
        }

        public ICollection<Producto> ListarProductos()
        {
            return productoDAO.ListarTodos();
        }

        public Producto ModificarProducto(Producto productoAModificar)
        {
            return productoDAO.Modificar(productoAModificar);
        }

        public Producto ObtenerProducto(string codigo)
        {
            return productoDAO.Obtener(Convert.ToInt32(codigo));
        }

       

    }
}
