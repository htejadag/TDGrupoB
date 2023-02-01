using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static TDB.Gateway.Api.Routes.ApiRoutes;
using Productos = TDB.Gateway.Aplicacion.ProductosClient;

namespace TDB.Gateway.Api.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly Productos.IClient _client;

        public ProductoController(Productos.Client client)
        {
            _client = client;
        }

        [HttpGet(RouteProducto.GetAll)]
        public Task<ICollection<Productos.Producto>> ListarProductos()
        {
            var listaProducto = _client.ApiV1ProductoAllAsync();
            return listaProducto;
        }        
    }
}
