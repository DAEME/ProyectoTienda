using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            ProductoWS.Producto oProducto = objPrx.ObtenerProducto(objProducto.co_producto);
            return Json(oProducto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerCliente(ClienteWS.Cliente objCliente)
        {
            var objPrx = new ClienteWS.ClienteServiceClient();

            ClienteWS.Cliente oCliente = objPrx.ObtenerCliente(objCliente.nu_ruc);
            return Json(oCliente, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GestionarVenta(VentaWS.Venta objVenta)
        {
            var objPrx = new VentaWS.VentaServiceClient();

            VentaWS.Venta oVenta = objPrx.Vender(objVenta.nu_ruc.nu_ruc, objVenta.Detalles);
            return Json(oVenta, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Listado()
        {
            var objPrx = new VentaWS.VentaServiceClient();

            ICollection<VentaWS.Venta> lst = new List<VentaWS.Venta>();

            lst = objPrx.ListarVentas();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

    }
}
