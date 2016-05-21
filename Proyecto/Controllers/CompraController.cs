using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class CompraController : Controller
    {
        //
        // GET: /Compra/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult indexDetalle()
        {
            return View("indexDetalle");
        }

        [HttpPost]
        public JsonResult ObtenerProducto(int CodProd)
        {
            var objPrx = new ProductoWS.ProductoServiceClient();
            ProductoWS.Producto oProducto = objPrx.ObtenerProducto(CodProd);

            return Json(oProducto, JsonRequestBehavior.AllowGet);
        }
    }
}
