using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTiendaServices.Dominio;
using WCFTiendaServices.Errores;
using WCFTiendaServices.Persistencia;

namespace WCFTiendaServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClienteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClienteService.svc or ClienteService.svc.cs at the Solution Explorer and start debugging.
    public class ClienteService : IClienteService
    {
        private ClienteDAO clienteDAO = new ClienteDAO();

        public Cliente CrearCliente(Cliente clienteACrear)
        {
            if (clienteDAO.Obtener(clienteACrear.nu_ruc) != null)
            {
                throw new FaultException<ClienteInexistenteError>(
                    new ClienteInexistenteError()
                    {
                        CodigoError = 101,
                        MensajeError = "El cliente ya existe"
                    },
                    new FaultReason("Error al intentar creación"));
            }
            return clienteDAO.Crear(clienteACrear);
        }

        public Cliente ObtenerCliente(string nu_ruc)
        {

            if (clienteDAO.Obtener(nu_ruc) == null)
            {
                throw new FaultException<ClienteInexistenteError>(
                   new ClienteInexistenteError()
                   {
                       CodigoError = 101,
                       MensajeError = "El cliente no existe"
                   },
                   new FaultReason("El cliente no existe"));

            }



            return clienteDAO.Obtener(nu_ruc);
        }

        public Cliente ModificarCliente(Cliente clienteAModificar)
        {
            return clienteDAO.Modificar(clienteAModificar);
        }

              public void EliminarCliente(Cliente clienteAEliminar)
              {
                   clienteDAO.Eliminar(clienteAEliminar);
              }


        /*  public void EliminarCliente(string nu_ruc)
          {
              clienteDAO.EliminarSimple(nu_ruc);
          }*/

        private void recibirMensajes()
        {
            //Cliente c = new Cliente();
            ICollection<Cliente> clie = new List<Cliente>();
            clie = clienteDAO.ListarTodos();
            //Catalogo pedidosEnCola = null;
            string rutaCola = @".\private$\catalogo";
            if (!MessageQueue.Exists(rutaCola))
            {
                MessageQueue.Create(rutaCola);
            }
            MessageQueue cola = new MessageQueue(rutaCola);
            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Catalogo) });

            if (cola.GetAllMessages().Count() > 0)
            { 

            Message mensajes = cola.Receive();

            
            Catalogo cat = (Catalogo)mensajes.Body;

            if (cat.bcatalogoid == 1)
            {
                foreach (Cliente c in clie)
                {
                    c.bcatalogoid = 1;

                    clienteDAO.Modificar(c);

                }


            }

            }


            //  return pedidosEnCola;
        }

        public ICollection<Cliente> ListarClientes()
        {
            recibirMensajes();
            return clienteDAO.ListarTodos();

        }
    }
}
