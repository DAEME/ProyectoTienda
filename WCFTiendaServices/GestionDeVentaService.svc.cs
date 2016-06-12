using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
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
        ClienteWS.ClienteServiceClient objPrx = new ClienteWS.ClienteServiceClient();
        ClienteWS.Cliente cliente = new ClienteWS.Cliente();
        Cliente cli = null;
        ClienteWS.ClienteServiceClient clienteProxy = new ClienteWS.ClienteServiceClient();
        ClienteWS.Cliente clienteWS = null;


        public ClienteWS.Cliente ObtenerCliente(string nu_ruc)
        {

            if (clienteDAO.Obtener(nu_ruc) == null)
            {
                throw new FaultException<ClienteInexistenteError>(
                   new ClienteInexistenteError()
                   {
                       CodigoError = 101,
                       MensajeError = "El cliente no existe"
                   },
                   new FaultReason("El cliente no existe"));

            }
            
            return clienteWS = clienteProxy.ObtenerCliente(nu_ruc);
        }
        public Producto ObtenerProducto(int co_producto)
        {
            HttpWebResponse res1 = null;
            StreamReader reader1 = null;
            HttpWebRequest req1 = (HttpWebRequest)WebRequest
                      .Create("http://localhost:20000/ProductoService.svc/ProductoService/" + co_producto.ToString());
            req1.Method = "GET";
            try
            {
                res1 = (HttpWebResponse)req1.GetResponse();
            }
            catch (WebException e)
            {
                throw new WebFaultException<string>("Producto no existe", HttpStatusCode.Conflict);
            }

            reader1 = new StreamReader(res1.GetResponseStream());
            string productosJson1 = reader1.ReadToEnd();
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            return js1.Deserialize<Producto>(productosJson1);
        }


        //private void enviarMensaje(Venta ventaAGuardar)
        //{
        //    IList<Item> items = null;
        //    string rutaCola = @".\private$\venta";
        //    if (!MessageQueue.Exists(rutaCola))
        //    {
        //        MessageQueue.Create(rutaCola);
        //    }
        //    MessageQueue cola = new MessageQueue(rutaCola);
        //    Message mensaje = new Message();
        //    mensaje.Label = "Nueva Venta";
        //    //mensaje.Body = new Venta() { nu_venta = ventaAGuardar.nu_venta,nu_ruc = ventaAGuardar.nu_ruc, dt_fecha = ventaAGuardar.dt_fecha, nu_total = ventaAGuardar.nu_total,Items = items };
        //    mensaje.Body = ventaAGuardar;
        //        //new Venta() { ventaAGuardar };
        //    cola.Send(mensaje);
        //}

        public Venta Vender(string nu_ruc, List<Item> items)
        {

            //Cliente cliente = clienteDAO.Obtener(nu_ruc);

            

                cliente = objPrx.ObtenerCliente(nu_ruc);

                if (cliente == null) // cliente inexistente
                {
                    throw new FaultException<ClienteInexistenteError>(
                        new ClienteInexistenteError()
                        {
                            CodigoError = 10,
                            MensajeError = "El cliente con RUC " + nu_ruc + " no existe"
                        });
                }
                else
                {
                    cli = new Cliente()
                    {
                        nu_ruc = cliente.nu_ruc,
                        tx_nombre = cliente.tx_nombre,
                        tx_direccion = cliente.tx_direccion

                    };

                }


                Venta venta = new Venta()
                {
                    nu_ruc = cli,
                    dt_fecha = DateTime.Now,
                    nu_total = 0m
                };

            //try
            //{
                
                venta = ventaDAO.Crear(venta);
               // throw new Exception();

            //}
            //catch (Exception ex)
            //{
            //    enviarMensaje(venta);
            //}


                Producto producto = null;
                VentaDetalle ventaDetalle = null;
                decimal total = 0m;
                foreach (Item item in items)
                {
                producto = ObtenerProducto(Convert.ToInt32(item.co_producto));

                    //StreamReader reader1 = null;
                    //HttpWebRequest req1 = (HttpWebRequest)WebRequest
                    //          .Create("http://localhost:20000/ProductoService.svc/ProductoService/" + item.co_producto.ToString());
                    //req1.Method = "GET";
                    //HttpWebResponse res1 = null;
                    //res1 = (HttpWebResponse)req1.GetResponse();
                    //reader1 = new StreamReader(res1.GetResponseStream());
                    //string productosJson1 = reader1.ReadToEnd();
                    //JavaScriptSerializer js1 = new JavaScriptSerializer();
                    //producto = js1.Deserialize<Producto>(productosJson1);

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

