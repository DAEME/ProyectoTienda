using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFTiendaTest;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.ServiceModel;

namespace WCFTiendaTest
{

    [TestClass]
    public class VentaUnitTest
    {

        private string ruc = "98765432112";
        public VentasWS.Item[] items = new VentasWS.Item[2];


        [TestMethod]
        public void CrearVentaTest()
        {
            items[0] = new VentasWS.Item()
            {
                co_producto = 1,
                nu_cantidad = 1
            };
            items[1] = new VentasWS.Item()
            {
                co_producto = 2,
                nu_cantidad = 1
            };

            VentasWS.GestionDeVentaServiceClient proxy = new VentasWS.GestionDeVentaServiceClient();
            VentasWS.Venta ventaRealizada = proxy.Vender(ruc, items);
            Assert.AreEqual(ruc, ventaRealizada.nu_ruc.nu_ruc);
            Assert.AreEqual(4150, ventaRealizada.nu_total);
        }
        //[TestMethod]
        public void CodigoProductoErroneoTest()
        {
            items[0] = new VentasWS.Item()
            {
                co_producto = 20,
                nu_cantidad = 1
            };
            try
            {
                VentasWS.GestionDeVentaServiceClient proxy = new VentasWS.GestionDeVentaServiceClient();
                VentasWS.Venta ventaRealizada = proxy.Vender(ruc, items);
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
        //[TestMethod]
        public void ClienteErroneoTest()
        {
            items[0] = new VentasWS.Item()
            {
                co_producto = 2,
                nu_cantidad = 1
            };
            try
            {
                VentasWS.GestionDeVentaServiceClient proxy = new VentasWS.GestionDeVentaServiceClient();
                VentasWS.Venta ventaRealizada = proxy.Vender("55554444", items);
            }
            catch (FaultException e)
            {
                Assert.AreEqual("Error al intentar obtener cliente", e.Reason.ToString());

            }
        }

    }
}
