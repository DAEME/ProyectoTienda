using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCFTiendaTest
{
    [TestClass]
    public class TestCliente
    {
        [TestMethod]
        public void Test1CrearCliente()
        {
            ClienteWS.ClienteServiceClient proxy = new ClienteWS.ClienteServiceClient();
            ClienteWS.Cliente clienteCreado = proxy.CrearCliente(new ClienteWS.Cliente()
            {
                nu_ruc = "98765432112",
                tx_nombre = "Kimberlita",
                tx_direccion = "Av Tarapaca"
            });
            Assert.AreEqual("98765432112", clienteCreado.nu_ruc);
            Assert.AreEqual("Kimberlita", clienteCreado.tx_nombre);
            Assert.AreEqual("Av Tarapaca", clienteCreado.tx_direccion);
        }

        [TestMethod]
        public void Test2CrearClienteRepetido()
        {
            ClienteWS.ClienteServiceClient proxy = new ClienteWS.ClienteServiceClient();
            try
            {
                ClienteWS.Cliente clienteCreado = proxy.CrearCliente(new ClienteWS.Cliente()
                {
                    nu_ruc = "45678912365",
                    tx_nombre = "SAC",
                    tx_direccion = "av peru"
                });
            }
            catch (System.ServiceModel.FaultException<ClienteWS.ClienteInexistenteError> error)
            {
                Assert.AreEqual("Error al intentar creación", error.Reason.ToString());
                Assert.AreEqual(error.Detail.CodigoError, 101);
                Assert.AreEqual(error.Detail.MensajeError, "El cliente ya existe");
            }
        }

        [TestMethod]
        public void Test3EliminarCliente()
        {
            ClienteWS.ClienteServiceClient proxy = new ClienteWS.ClienteServiceClient();
            ClienteWS.Cliente productoCreado = proxy.CrearCliente(new ClienteWS.Cliente()
            {
                nu_ruc = "12345678987",
                tx_nombre = "name1",
                tx_direccion = "dir1"
            });
            proxy.EliminarCliente(productoCreado);
            try
            {
                proxy.ObtenerCliente("12345678987");
            }
            catch (System.ServiceModel.FaultException<ClienteWS.ClienteInexistenteError> error)
            {
                Assert.AreEqual("El cliente ha sido eliminado", error.Reason.ToString());
                Assert.AreEqual(error.Detail.CodigoError, 102);
                Assert.AreEqual(error.Detail.MensajeError, "El cliente no existe");
            }
        }
    }
}
