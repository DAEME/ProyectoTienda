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

        [TestMethod]
        public void CrearTest()
        {
            string postdata = "{\"nu_precio\":\"750\",\"tx_descripcion\":\"Laptop HP\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:20000/ProductoService.svc/ProductoService");
            req.ContentLength = data.Length;
            req.Method = "POST";
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Producto productoCreado = js.Deserialize<Producto>(productoJson);
            Assert.AreEqual(750, productoCreado.nu_precio);
            Assert.AreEqual("Laptop HP", productoCreado.tx_descripcion);
        }

        //[TestMethod]
        public void CrearProductoRepetidoTest()
        {
            
        }
        
    }
}