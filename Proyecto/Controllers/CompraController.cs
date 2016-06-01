using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Text;
using Proyecto.Clases;

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
        public JsonResult GuardarProducto(ProductoWS.Producto objProducto)
        {
            //var objPrx = new VentaWS.GestionDeVentaServiceClient();

            //VentaWS.Venta oVenta = objPrx.Vender(objVenta.nu_ruc.nu_ruc, objVenta.Items);
            int co_productoA = objProducto.co_producto;
            string tx_descripcionA = objProducto.tx_descripcion;
            decimal nu_precioA = objProducto.nu_precio;


            //string postdata = "{\"co_producto\":\"1\",\"tx_descripcion\":\"CarteraXime\",\"nu_precio\":\"4.0\"}";
            string postdata = "{\"co_producto\":\"" + co_productoA.ToString() + "\",\"tx_descripcion\":\" "+ tx_descripcionA.ToString()+ "\",\"nu_precio\":\""+ nu_precioA.ToString() + "\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:20000/ProductoService.svc/ProductoService");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            //try
            //{
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Producto productoCreado = js.Deserialize<Producto>(productoJson);



            return Json(productoCreado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ModificarProducto(ProductoWS.Producto objProducto)
        {
            //var objPrx = new VentaWS.GestionDeVentaServiceClient();

            //VentaWS.Venta oVenta = objPrx.Vender(objVenta.nu_ruc.nu_ruc, objVenta.Items);
            int co_productoA = objProducto.co_producto;
            string tx_descripcionA = objProducto.tx_descripcion;
            decimal nu_precioA = objProducto.nu_precio;


            //string postdata = "{\"co_producto\":\"1\",\"tx_descripcion\":\"CarteraXime\",\"nu_precio\":\"4.0\"}";
            string postdata = "{\"co_producto\":\"" + co_productoA.ToString() + "\",\"tx_descripcion\":\" " + tx_descripcionA.ToString() + "\",\"nu_precio\":\"" + nu_precioA.ToString() + "\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:20000/ProductoService.svc/ProductoService");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            //try
            //{
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Producto productoModificado = js.Deserialize<Producto>(productoJson);



            return Json(productoModificado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarProducto(ProductoWS.Producto objProducto)
        {
            //var objPrx = new VentaWS.GestionDeVentaServiceClient();

            //VentaWS.Venta oVenta = objPrx.Vender(objVenta.nu_ruc.nu_ruc, objVenta.Items);
            int co_productoA = objProducto.co_producto;
            string tx_descripcionA = objProducto.tx_descripcion;
            decimal nu_precioA = objProducto.nu_precio;


            //string postdata = "{\"co_producto\":\"1\",\"tx_descripcion\":\"CarteraXime\",\"nu_precio\":\"4.0\"}";
            string postdata = "{\"co_producto\":\"" + co_productoA.ToString() + "\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
               .Create("http://localhost:20000/ProductoService.svc/ProductoService/" + objProducto.co_producto.ToString());
            req.Method = "DELETE";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            //try
            //{
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Producto productoEliminado = js.Deserialize<Producto>(productoJson);


            

            return Json(productoEliminado, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult ListarProducto()
        {
            var objPrx = new ProductoWS.ProductoServiceClient();
            List<ProductoWS.Producto>  lstProducto = new List<ProductoWS.Producto>();

            StreamReader reader1 = null;

            HttpWebRequest req1 = (HttpWebRequest)WebRequest
                      .Create("http://localhost:20000/ProductoService.svc/ProductoService");
            req1.Method = "GET";
            HttpWebResponse res1 = null;

            res1 = (HttpWebResponse)req1.GetResponse();

            reader1 = new StreamReader(res1.GetResponseStream());
            string productosJson1 = reader1.ReadToEnd();
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            lstProducto = js1.Deserialize<List<ProductoWS.Producto>>(productosJson1);

            //SOAP
            // ProductoWS.Producto oProducto = objPrx.ObtenerProducto(objProducto.co_producto.ToString());

            return Json(lstProducto, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult ObtenerProducto(int CodProd)
        //{
        //    var objPrx = new ProductoWS.ProductoServiceClient();
        //    ProductoWS.Producto oProducto = objPrx.ObtenerProducto(CodProd);

        //    return Json(oProducto, JsonRequestBehavior.AllowGet);
        //}
    }
}
