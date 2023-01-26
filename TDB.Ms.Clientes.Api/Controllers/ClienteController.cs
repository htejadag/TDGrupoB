using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TDB.Ms.Clientes.Aplicacion.Cliente;
using static TDB.Ms.Clientes.Api.Routes.ApiRoutes;
using dominio = TDB.Ms.Clientes.Dominio.Entidades;

namespace TDB.Ms.Clientes.Api.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet(RouteCliente.GetAll)]
        public IEnumerable<dominio.Cliente> ListarClientes()
        {           

            var listaCliente =_service.ListarClientes();
            return listaCliente;
        }

        [HttpGet(RouteCliente.GetById)]
        public dominio.Cliente BuscarCliente(int id)
        {           
            var objCliente = _service.Cliente(id);

            return objCliente;
        }

        [HttpPost(RouteCliente.Create)]
        public ActionResult<dominio.Cliente> CrearCliente([FromBody] dominio.Cliente cliente)
        {
            _service.Registracliente(cliente);

            return Ok();
        }

        //[HttpPut(RouteCliente.Update)]
        //public ActionResult<dominio.Cliente> ModificarCliente(dominio.Cliente cliente)
        //{
        //    #region Conexión a base de datos
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("TDB_clientes");
        //    var collection = database.GetCollection<dominio.Cliente>("cliente");
        //    #endregion

        //    collection.FindOneAndReplace(x => x._id == cliente._id, cliente);

        //    //var oldCliente = collection.Find(x => x.IdCliente == cliente.IdCliente).FirstOrDefault();
        //    //oldCliente.Nombre = cliente.Nombre;
        //    //oldCliente.Precio = cliente.Precio;
        //    //oldCliente.Cantidad = cliente.Cantidad;
        //    //collection.ReplaceOne(x=>x.IdCliente == oldCliente.IdCliente, oldCliente);


        //    //Cliente clienteModificado = listaCliente.Single(x => x.IdCliente == cliente.IdCliente);
        //    //clienteModificado.Nombre = cliente.Nombre;
        //    //clienteModificado.Cantidad = cliente.Cantidad;
        //    //clienteModificado.Precio= cliente.Precio;
        //    //return CreatedAtAction("ModificarCliente", clienteModificado);
        //    return Ok();
        //}

        [HttpDelete(RouteCliente.Delete)]
        public ActionResult<dominio.Cliente> EliminarCliente(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
