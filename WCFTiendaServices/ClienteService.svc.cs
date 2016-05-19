using System;
using System.Collections.Generic;
using System.Linq;
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

        public ICollection<Cliente> ListarClientes()
        {
            return clienteDAO.ListarTodos();

        }
    }
}
