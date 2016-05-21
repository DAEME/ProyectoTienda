using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WCFTiendaTest
{
    [TestClass]
    public class UnitTestCrearVenta
    {
        [TestMethod]

        public void TestCrearVenta()
        {
            GestionDeVentaWS.Item item1 = new GestionDeVentaWS.Item();
            item1.co_producto = 2;
            item1.nu_cantidad = 1;
            GestionDeVentaWS.Item item2 = new GestionDeVentaWS.Item();
            item2.co_producto = 6;
            item2.nu_cantidad = 2;
            GestionDeVentaWS.Item[] items = new GestionDeVentaWS.Item[2];
            items[0] = item1;
            items[1] = item2;
            GestionDeVentaWS.GestionDeVentaServiceClient proxy = new GestionDeVentaWS.GestionDeVentaServiceClient();
            proxy.Vender("20549588469", items);
        }
    }
}
