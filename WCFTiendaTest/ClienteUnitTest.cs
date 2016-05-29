using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFTiendaTest
{
    [TestClass]
    public class ClienteUnitTest
    {
        //[TestMethod]
        public void TestCrear()
        {
            ClienteWS.ClienteServiceClient proxy = new ClienteWS.ClienteServiceClient();
            ClienteWS.Cliente clienteCreado = null;
            try
            {
                clienteCreado = proxy.CrearCliente(new ClienteWS.Cliente()
                {
                    nu_ruc = "12457889458",
                    tx_nombre = "Eric Rodrich Torres",
                    tx_direccion = "Psj La Sombrilla 174 Surquillo"
                });
                Assert.AreEqual("12457889458", clienteCreado.nu_ruc);
                Assert.AreEqual("Eric Rodrich Torres", clienteCreado.tx_nombre);
                Assert.AreEqual("Psj La Sombrilla 174 Surquillo", clienteCreado.tx_direccion);
            }
            catch (System.ServiceModel.FaultException<ClienteWS.ClienteInexistenteError> error)
            {
                Assert.AreEqual("Error al intentar creación", error.Reason.ToString());
                Assert.AreEqual(error.Detail.CodigoError, 101);
                Assert.AreEqual(error.Detail.MensajeError, "El cliente ya existe");
            }
            
        }

        //[TestMethod]
        public void TestCrearClienteRepetido()
        {
            ClienteWS.ClienteServiceClient proxy = new ClienteWS.ClienteServiceClient();
            try
            {
                ClienteWS.Cliente clienteCreado = proxy.CrearCliente(new ClienteWS.Cliente()
                {
                    nu_ruc = "98765432112",
                    tx_nombre = "Kimberlita",
                    tx_direccion = "Av Tarapaca"
                });
            }
            catch (FaultException<ClienteWS.ClienteInexistenteError> e)
            {
                Assert.AreEqual("Error al intentar creación", e.Reason.ToString());
                Assert.AreEqual(e.Detail.CodigoError, 101);
                Assert.AreEqual(e.Detail.MensajeError, "El cliente ya existe");
            }
        }

        //[TestMethod]
        public void TestObtenerCliente()
        {
            ClienteWS.ClienteServiceClient proxy = new ClienteWS.ClienteServiceClient();
            ClienteWS.Cliente clienteObtenido = null;
            clienteObtenido = proxy.ObtenerCliente("22222222333");
            if(clienteObtenido != null)
            {
                Assert.AreEqual("22222222333", clienteObtenido.nu_ruc);
            }
            else
            {
                Assert.IsNull(clienteObtenido);
            }
            
        }
        
        //[TestMethod]
        public void TestModificarCliente()
        {
            ClienteWS.ClienteServiceClient proxy = new ClienteWS.ClienteServiceClient();
            ClienteWS.Cliente clienteCreado = proxy.ObtenerCliente("12457889458");
            clienteCreado.tx_nombre = "Deltron";
            clienteCreado.tx_direccion = "Calle Laurel Rosa 102 - Surquillo";
            ClienteWS.Cliente clienteMod = proxy.ModificarCliente(clienteCreado);
            Assert.AreEqual("12457889458", clienteCreado.nu_ruc);
            Assert.AreEqual("Deltron", clienteCreado.tx_nombre);
            Assert.AreEqual("Calle Laurel Rosa 102 - Surquillo", clienteCreado.tx_direccion);

        }

        //[TestMethod]
        public void TestEliminarCliente()
        {
            
            ClienteWS.ClienteServiceClient proxy = new ClienteWS.ClienteServiceClient();
            ClienteWS.Cliente clienteCreado = null;
            try
            {
                clienteCreado = proxy.CrearCliente(new ClienteWS.Cliente()
                {
                    nu_ruc = "22222222333",
                    tx_nombre = "Alfredo Benavides",
                    tx_direccion = "MzE Lote 8 - Los Angeles de San Rafael"
                });
            }
            catch (System.ServiceModel.FaultException<ClienteWS.ClienteInexistenteError> error)
            {
                Assert.AreEqual("Error al intentar creación", error.Reason.ToString());
                Assert.AreEqual(error.Detail.CodigoError, 101);
                Assert.AreEqual(error.Detail.MensajeError, "El cliente ya existe");
            }
            
            proxy.EliminarCliente(clienteCreado);
            ClienteWS.Cliente clienteObtenido = null;
            clienteObtenido = proxy.ObtenerCliente("22222222333");
            Assert.IsNull(clienteObtenido);
            

        }
    }
}
