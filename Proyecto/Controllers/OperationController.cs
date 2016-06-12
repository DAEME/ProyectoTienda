using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class OperationController : Controller
    {
        //
        // GET: /Operation/

        public ActionResult Index()
        {
            return View("menu");
        }

        public ActionResult indexClientelistado()
        {
            return View("indexClientelistado");
        }

        [HttpPost]
        public JsonResult Listado()
        {
            var objPrx = new ClienteWS.ClienteServiceClient();

            ICollection<ClienteWS.Cliente> lst = new List<ClienteWS.Cliente>();

            lst = objPrx.ListarClientes();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

    }
}
