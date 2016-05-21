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
   public class GestionDeVentaService : IGestionDeVentaService
    {
        private ClienteDAO clienteDAO = new ClienteDAO();
        private ProductoDAO productoDAO = new ProductoDAO();
        private VentaDAO ventaDAO = new VentaDAO();
        private VentaDetalleDAO ventaDetalleDAO = new VentaDetalleDAO();

        public Venta Vender(string nu_ruc, List<Item> items)
        {
            
            Cliente cliente = clienteDAO.Obtener(nu_ruc);
            if (cliente == null) // cliente inexistente
                throw new FaultException<ClienteInexistenteError>(
                    new ClienteInexistenteError()
                    {
                        CodigoError = 10,
                        MensajeError = "El cliente con RUC " + nu_ruc + " no existe"
                    });

            Venta venta = new Venta()
            {
                nu_ruc = cliente,
                dt_fecha = DateTime.Now,
                nu_total = 0m
            };

            venta = ventaDAO.Crear(venta);

            Producto producto = null;
            VentaDetalle ventaDetalle = null;
            decimal total = 0m;
            foreach (Item item in items)
            {
                producto = productoDAO.Obtener(Convert.ToInt32(item.co_producto));
                ventaDetalle = new VentaDetalle()
                {
                    Pk = new VentaDetallePK()
                    {
                        nu_venta = venta.nu_venta,
                        co_producto = producto
                    },
                    nu_cantidad = item.nu_cantidad,
                    nu_subtotal = item.nu_cantidad * producto.nu_precio
                };
                total = total + ventaDetalle.nu_subtotal;
                ventaDetalleDAO.Crear(ventaDetalle);
            }
            venta.nu_total = total;
            venta = ventaDAO.Modificar(venta);
            return venta;

        }

        public ICollection<Venta> ListarVentas()
        {
            return ventaDAO.ListarTodos();
        }
    }
}

