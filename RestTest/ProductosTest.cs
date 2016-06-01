using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Net;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace RestTest
{
    [TestClass]
    public class ProductosTest
    {
        [TestMethod]
        public void CRUDTest()
        {
            string postdata = "{\"co_producto\":\"22\",\"tx_descripcion\":\"CarteraSeb\",\"nu_precio\":\"4.0\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:20000/ProductoService.svc/ProductoService");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            try
            {
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string productoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Producto productoCreado = js.Deserialize<Producto>(productoJson);
                Assert.AreEqual(1, productoCreado.co_producto);
                Assert.AreEqual("CarteraSeb", productoCreado.tx_descripcion);
                Assert.AreEqual(4.0, productoCreado.nu_precio);


            }
            catch (WebException e)
            {

                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());

                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Producto imposible", mensaje);


            }


        }

        [TestMethod]
        public void CRUDTestUpdate()
        {
            string postdata = "{\"co_producto\":\"22\",\"tx_descripcion\":\"Mochila\",\"nu_precio\":\"4.0\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                 .Create("http://localhost:20000/ProductoService.svc/ProductoService");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            try
            {
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string productoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Producto productoCreado = js.Deserialize<Producto>(productoJson);
                Assert.AreEqual(1, productoCreado.co_producto);
                Assert.AreEqual("Mochila", productoCreado.tx_descripcion);
                Assert.AreEqual(4.0, productoCreado.nu_precio);



            }

            catch (WebException e)
            {

                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());

                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Producto imposible", mensaje);


            }



        }

        [TestMethod]
        public void CRUDTestDelete()
        {
            string postdata = "{\"co_producto\":\"6\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                  .Create("http://localhost:20000/ProductoService.svc/ProductoService/" + "6");
            req.Method = "DELETE";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();

            Producto productoCreado = js.Deserialize<Producto>(productoJson);
            Assert.AreEqual(6, productoCreado.co_producto);


        }
    }
}
