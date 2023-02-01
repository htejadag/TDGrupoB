using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TDB.Ms.Producto.Aplicacion.Producto;
using static TDB.Ms.Producto.Api.Routes.ApiRoutes;
using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Producto.Api.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet(RouteProducto.GetAll)]
        public IEnumerable<dominio.Producto> ListarProductos()
        {           

            var listaProducto =_service.ListarProductos();
            return listaProducto;
        }

        [HttpGet(RouteProducto.GetById)]
        public dominio.Producto BuscarProducto(int id)
        {           
            var objProducto = _service.BuscarPorId(id);

            return objProducto;
        }

        [HttpPost(RouteProducto.Create)]
        public ActionResult<dominio.Producto> CrearProducto([FromBody] dominio.Producto producto)
        {
            _service.Registrar(producto);
            return Ok();
        }

        [HttpPost(RouteProducto.UpdateStock)]
        public ActionResult<dominio.Producto> UpdateStock([FromBody] dominio.Producto producto)
        {
            _service.ActualizarStock(producto.idProducto, producto.cantidad);
            return Ok();
        }

        //[HttpPut(RouteProducto.Update)]
        //public ActionResult<dominio.Producto> ModificarProducto(dominio.Producto producto)
        //{
        //    #region Conexión a base de datos
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("TDB_productos");
        //    var collection = database.GetCollection<dominio.Producto>("producto");
        //    #endregion

        //    collection.FindOneAndReplace(x => x._id == producto._id, producto);

        //    //var oldProducto = collection.Find(x => x.IdProducto == producto.IdProducto).FirstOrDefault();
        //    //oldProducto.Nombre = producto.Nombre;
        //    //oldProducto.Precio = producto.Precio;
        //    //oldProducto.Cantidad = producto.Cantidad;
        //    //collection.ReplaceOne(x=>x.IdProducto == oldProducto.IdProducto, oldProducto);


        //    //Producto productoModificado = listaProducto.Single(x => x.IdProducto == producto.IdProducto);
        //    //productoModificado.Nombre = producto.Nombre;
        //    //productoModificado.Cantidad = producto.Cantidad;
        //    //productoModificado.Precio= producto.Precio;
        //    //return CreatedAtAction("ModificarProducto", productoModificado);
        //    return Ok();
        //}

        [HttpDelete(RouteProducto.Delete)]
        public ActionResult<dominio.Producto> EliminarProducto(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
