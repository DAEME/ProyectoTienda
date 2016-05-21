using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCFTiendaTest
{
    [TestClass]
    public class TestProducto
    {
        [TestMethod]
        public void Test1CrearProducto()
        {
            ProductoWS.ProductoServiceClient proxy = new ProductoWS.ProductoServiceClient();
            ProductoWS.Producto productoCreado = proxy.CrearProducto(new ProductoWS.Producto()
            {
                co_producto = 6,
                tx_descripcion = "teclado",
                nu_precio = 60m
            });
            Assert.AreEqual(6, productoCreado.co_producto);
            Assert.AreEqual("teclado", productoCreado.tx_descripcion);
            Assert.AreEqual(60, productoCreado.nu_precio);
        }

        [TestMethod]
        public void Test2CrearProductoRepetido()
        {
            ProductoWS.ProductoServiceClient proxy = new ProductoWS.ProductoServiceClient();
            try
            {
                ProductoWS.Producto productoCreado = proxy.CrearProducto(new ProductoWS.Producto()
                {
                    co_producto = 6,
                    tx_descripcion = "teclado",
                    nu_precio = 60m
                });
            }
            catch (System.ServiceModel.FaultException<ProductoWS.ClienteInexistenteError> error)
            {
                Assert.AreEqual("Error al intentar creación", error.Reason.ToString());
                Assert.AreEqual(error.Detail.CodigoError, 101);
                Assert.AreEqual(error.Detail.MensajeError, "El producto ya existe");
            }
        }

        [TestMethod]
        public void Test3EliminarProducto()
        {
            ProductoWS.ProductoServiceClient proxy = new ProductoWS.ProductoServiceClient();
            ProductoWS.Producto productoCreado = proxy.CrearProducto(new ProductoWS.Producto()
            {
                co_producto = 8,
                tx_descripcion = "CPU",
                nu_precio = 650m
            });
            proxy.EliminarProducto(productoCreado);
            try
            {
                proxy.ObtenerProducto(8);
            }
            catch (System.ServiceModel.FaultException<ClienteWS.ClienteInexistenteError> error)
            {
                Assert.AreEqual("El producto ha sido eliminado", error.Reason.ToString());
                Assert.AreEqual(error.Detail.CodigoError, 102);
                Assert.AreEqual(error.Detail.MensajeError, "El producto no existe");
            }
        }
    }
}
