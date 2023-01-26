using dominio = TDB.Ms.Clientes.Dominio.Entidades;

namespace TDB.Ms.Clientes.Aplicacion.Cliente
{
    public interface IClienteService
    {
        List<dominio.Cliente> ListarClientes();
        bool Registracliente(dominio.Cliente cliente);
        dominio.Cliente Cliente(int idCliente);
        void Eliminar(int idCliente);
    }
}
