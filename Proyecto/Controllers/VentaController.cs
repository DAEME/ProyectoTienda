using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.ServiceModel;

namespace Proyecto.Controllers
{
    public class VentaController : Controller
    {
        //
        // GET: /Venta/

        public ActionResult Index()
        {
            return View("index");
        }

        public ActionResult indexListado()
        {
            return View("indexListado");
        }


        [HttpPost]
        public JsonResult ObtenerProducto(ProductoWS.Producto objProducto)
        {
            var objPrx = new ProductoWS.ProductoServiceClient();
            ProductoWS.Producto oProducto = new ProductoWS.Producto();
            string mensajeError = "";
            StreamReader reader1 = null;

            try
            {
                HttpWebRequest req1 = (HttpWebRequest)WebRequest
                          .Create("http://localhost:20000/ProductoService.svc/ProductoService/" + objProducto.co_producto.ToString());
                req1.Method = "GET";
                HttpWebResponse res1 = null;
                res1 = (HttpWebResponse)req1.GetResponse();
                reader1 = new StreamReader(res1.GetResponseStream());
                string productosJson1 = reader1.ReadToEnd();
                JavaScriptSerializer js1 = new JavaScriptSerializer();
                oProducto = js1.Deserialize<ProductoWS.Producto>(productosJson1);

            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());

                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                mensajeError = js.Deserialize<string>(error);
               // Assert.AreEqual("Producto imposible", mensaje);

            }

            return Json(new { oProducto, mensajeError }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerCliente(ClienteWS.Cliente objCliente)
        {
            var objPrx = new VentaWS.GestionDeVentaServiceClient();
            //ClienteWS.Cliente oCliente = new ClienteWS.Cliente();
            VentaWS.Cliente oCliente = new VentaWS.Cliente();

            ClienteWS.ClienteInexistenteError error2 = new ClienteWS.ClienteInexistenteError();

            try {

                oCliente = objPrx.ObtenerCliente(objCliente.nu_ruc);
                
            }
           catch(FaultException e)
            {
                 error2.MensajeError = e.Reason.ToString();
            }
            
            return Json(new { oCliente, error2 } , JsonRequestBehavior.AllowGet);

            
        }

        [HttpPost]
        public JsonResult GestionarVenta(VentaWS.Venta objVenta)
        {
            var objPrx = new VentaWS.GestionDeVentaServiceClient();

            VentaWS.Venta oVenta = objPrx.Vender(objVenta.nu_ruc.nu_ruc, objVenta.Items);
            return Json(oVenta, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Listado()
        {
            var objPrx = new VentaWS.GestionDeVentaServiceClient();

            ICollection<VentaWS.Venta> lst = new List<VentaWS.Venta>();

            lst = objPrx.ListarVentas();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

    }
}
