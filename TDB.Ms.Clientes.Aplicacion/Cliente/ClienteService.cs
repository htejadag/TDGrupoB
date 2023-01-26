using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = TDB.Ms.Clientes.Dominio.Entidades;

namespace TDB.Ms.Clientes.Aplicacion.Cliente
{

    public class ClienteService : IClienteService
    {
        private readonly ICollectionContext<dominio.Cliente> _cliente;
        private readonly IBaseRepository<dominio.Cliente> _clienteR;

        public ClienteService(ICollectionContext<dominio.Cliente> cliente, 
                                IBaseRepository<dominio.Cliente> clienteR)
        {
            _cliente = cliente;
            _clienteR = clienteR;
        }

        public List<dominio.Cliente> ListarClientes()
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false;
            var items = (_cliente.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool Registracliente(dominio.Cliente cliente)
        {
            cliente.esEliminado = false;
            cliente.fechaCreacion =DateTime.Now;
            cliente.esActivo = true;

           // _cliente.Context().InsertOne(cliente);                       

            var p = _clienteR.InsertOne(cliente);

            return true;
        }

        public dominio.Cliente Cliente(int idCliente)
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.idCliente == idCliente;
            var item = (_cliente.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idCliente)
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.idCliente == idCliente;
            var item = (_cliente.Context().FindOneAndDelete(filter, null));
            
        }
    }
}
