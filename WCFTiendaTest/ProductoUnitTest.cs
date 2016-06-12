using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace WCFTiendaTest
{

    [TestClass]
    public class ProductoUnitTest
    {
        Producto productoACrear = new Producto()
        {
            nu_precio = 400,
            tx_descripcion = "Impresora Epson"
        };
        Producto productoExistente = new Producto()
        {
            co_producto = 1,
            nu_precio = 400,
            tx_descripcion = "Monitor Samsung"
        };

        JavaScriptSerializer js = new JavaScriptSerializer();

        [TestMethod]
        public void CrearTest()
        {
            //string postdata = "{\"nu_precio\":\""+productoACrear.nu_precio+"\",\"tx_descripcion\":\""+productoACrear.tx_descripcion+"\"}";
            string postdata = js.Serialize(productoACrear);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:20000/ProductoService.svc/ProductoService");
            req.ContentLength = data.Length;
            req.Method = "POST";
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            //Respuesta
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productoJson = reader.ReadToEnd();
            Producto productoCreado = js.Deserialize<Producto>(productoJson);
            //Asserts
            Assert.AreEqual(productoACrear.nu_precio, productoCreado.nu_precio);
            Assert.AreEqual(productoACrear.tx_descripcion, productoCreado.tx_descripcion);
        }

        [TestMethod]
        public void CrearProductoRepetidoTest()
        {
            string postdata = js.Serialize(productoExistente);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:20000/ProductoService.svc/ProductoService");
            req.ContentLength = data.Length;
            req.Method = "POST";
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            //Respuesta
            try
            {
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string productoJsonRechazado = reader.ReadToEnd();
                Producto productoRechazado = js.Deserialize<Producto>(productoJsonRechazado);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Codigo de Producto en uso", mensaje);
            }

        }

        [TestMethod]
        public void ObtenerProductoTest()
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:20000/ProductoService.svc/ProductoService/200");
                req.Method = "GET";
                //Respuesta
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string productoRaw = reader.ReadToEnd();
                Producto productoEncontrado = js.Deserialize<Producto>(productoRaw);
                Assert.AreEqual(1, productoEncontrado.co_producto);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Producto no existe", mensaje);
            }

        }

        [TestMethod]
        public void ModificarProductoTest()
        {
            //Obteniendo un producto para duplicar su precio
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:20000/ProductoService.svc/ProductoService/1");
            req.Method = "GET";
            // //Respuesta
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productoRaw = reader.ReadToEnd();
            Producto productoAModificar = js.Deserialize<Producto>(productoRaw);
            // Modificando precio
            productoAModificar.nu_precio = productoAModificar.nu_precio * 2;
            //--------------------------------------------------------------
            //--------------------------------------------------------------
            //Enviando POST para guardar producto modificado
            string postdata = js.Serialize(productoAModificar);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:20000/ProductoService.svc/ProductoService");
            req2.ContentLength = data.Length;
            req2.Method = "PUT";
            req2.ContentType = "application/json";
            var reqStream = req2.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            //Respuesta al PUT
            var res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader readerRespuesta = new StreamReader(res2.GetResponseStream());
            string productoJsonModificado = readerRespuesta.ReadToEnd();
            Producto productoModificado = js.Deserialize<Producto>(productoJsonModificado);
            //Asserts
            Assert.AreEqual(productoAModificar.nu_precio, productoModificado.nu_precio);

        }
        [TestMethod]
        public void EliminarProductoTest()
        {
            string postdata = "{\"co_producto\":\"2\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
               .Create("http://localhost:20000/ProductoService.svc/ProductoService/2");
            req.Method = "DELETE";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            req.GetResponse();

        }

    }
}