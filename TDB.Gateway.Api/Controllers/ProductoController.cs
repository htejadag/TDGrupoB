using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static TDB.Gateway.Api.Routes.ApiRoutes;
using Productos = TDB.Gateway.Aplicacion.ProductosClient;
using Clientes = TDB.Gateway.Aplicacion.ClientesClient;
using TDB.Gateway.Aplicacion.Productos.Request;

namespace TDB.Gateway.Api.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly Productos.IClient _productosClient;
        //private readonly Clientes.IClient _clientesClient;

        public ProductoController(Productos.IClient productosClient)
        {
            _productosClient = productosClient;
        }

        //public ProductoController(Productos.IClient productosClient, Clientes.IClient clientesClient)
        //{
        //    _productosClient = productosClient;
        //    _clientesClient = clientesClient;
        //}

        [HttpGet(RouteProducto.GetAll)]
        public ICollection<Productos.Producto> ListarProductos()
        {
            var listaProducto = _productosClient.ApiV1ProductoAllAsync().Result;
            return listaProducto;
        }

        [HttpPost(RoutePedido.RegistrarPedido)]
        public async void RegistrarPedido(RegistrarPedidoRequest request)
        {
            
            //var cliente = _clientesClient.ApiV1ClienteAsync(request.idCliente);
            var producto = await _productosClient.ApiV1ProductoAsync(request.idProducto);

            // Llamar a PedidosClient para crear el pedido
            // Llamar a PedidosClient para crear el detalle del pedido

            var pedido = _productosClient.ApiV1ProductoUpdateStockAsync(producto);


        }
    }
}
