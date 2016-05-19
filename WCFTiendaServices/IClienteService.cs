using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTiendaServices.Dominio;
using WCFTiendaServices.Errores;

namespace WCFTiendaServices
{
    [ServiceContract]
    
    public interface IClienteService
    {
        [FaultContract(typeof(ClienteInexistenteError))]
        [OperationContract]
        Cliente CrearCliente(Cliente clienteACrear);

        [OperationContract]
        Cliente ObtenerCliente(string nu_ruc);

        [OperationContract]
        Cliente ModificarCliente(Cliente clienteAModificar);

        [OperationContract]
        void EliminarCliente(Cliente clienteAEliminar);
        //void EliminarCliente(string nu_ruc);

        [OperationContract]
        ICollection<Cliente> ListarClientes();

    }
}
