using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace WCFTiendaTest
{

    [TestClass]
    public class ProductoUnitTest
    {

        //[TestMethod]
        public void CrearTest()
        {
            ProductoWS.ProductoServiceClient proxy = new ProductoWS.ProductoServiceClient();
            ProductoWS.Producto productoCreado = null;
            try
            {
                productoCreado = proxy.CrearProducto(new ProductoWS.Producto()
                {
                    co_producto = 201,
                    tx_descripcion = "Alienware 14",
                    nu_precio = 850.20m
                });
            }
            catch (System.ServiceModel.FaultException<ProductoWS.ClienteInexistenteError> error)
            {
                Assert.AreEqual("Error al intentar creación", error.Reason.ToString());
                Assert.AreEqual(error.Detail.CodigoError, 101);
                Assert.AreEqual(error.Detail.MensajeError, "El producto ya existe");
            }
            Assert.AreEqual(201, productoCreado.co_producto);
            Assert.AreEqual("Alienware 14", productoCreado.tx_descripcion);
            Assert.AreEqual(850.20m, productoCreado.nu_precio);
        }

        [TestMethod]
        public void CrearProductoRepetidoTest()
        {
            ProductoWS.ProductoServiceClient proxy = new ProductoWS.ProductoServiceClient();
            ProductoWS.Producto productoACrear = null;
            try
            {
                productoACrear = proxy.CrearProducto(new ProductoWS.Producto()
                {
                    co_producto = 201,
                    tx_descripcion = "Impresora HP",
                    nu_precio = 450.32m
                });
            }catch (FaultException<ProductoWS.ClienteInexistenteError> e)
            {
                Assert.AreEqual("Error al intentar creación", e.Reason.ToString());
                Assert.AreEqual(101, e.Detail.CodigoError);
                Assert.AreEqual("El producto ya existe", e.Detail.MensajeError);
            }
        }
        
    }
}