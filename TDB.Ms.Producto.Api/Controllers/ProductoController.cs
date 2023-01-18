using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using TDB.Ms.Producto.Api.Routes;

namespace TDB.Ms.Producto.Api.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //private static List<Producto> listaProducto = new List<Producto>
        //{
        //    new Producto
        //    {
        //        IdProducto = 1,
        //        Nombre = "Arroz",
        //        Cantidad = 100,
        //        Precio = 5.5M
        //    },

        //    new Producto
        //    {
        //        IdProducto = 2,
        //        Nombre = "Leche",
        //        Cantidad = 80,
        //        Precio = 4.4M
        //    }
        //};


        [HttpGet(ApiRoutes.Producto.GetAll)]
        public IEnumerable<Producto> ListarProductos()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDC_productos");
            var dbProducto = database.GetCollection<Producto>("producto");

            var listaProducto = dbProducto.Find(x=>true).ToList();

            return listaProducto;
        }

        [HttpGet(ApiRoutes.Producto.GetById)]
        public Producto BuscarProducto(int id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDC_productos");
            var dbProducto = database.GetCollection<Producto>("producto");

            var objProducto = dbProducto.Find(x => x.IdProducto == id).FirstOrDefault();

            return objProducto;
        }

        [HttpPost(ApiRoutes.Producto.Create)]
        public ActionResult<Producto> CrearProducto(Producto producto)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDC_productos");
            var dbProducto = database.GetCollection<Producto>("producto");
            dbProducto.InsertOneAsync(producto);
            //producto.IdProducto = listaProducto.Count() + 1;
            //listaProducto.Add(producto);
            return CreatedAtAction("CrearProducto", producto);
        }

        [HttpPut(ApiRoutes.Producto.Update)]
        public ActionResult<Producto> ModificarProducto(Producto producto)
        {
            //Producto productoModificado = listaProducto.Single(x => x.IdProducto == producto.IdProducto);
            //productoModificado.Nombre = producto.Nombre;
            //productoModificado.Cantidad = producto.Cantidad;
            //productoModificado.Precio= producto.Precio;
            //return CreatedAtAction("ModificarProducto", productoModificado);
            return Ok();
        }

        [HttpDelete(ApiRoutes.Producto.Delete)]
        public ActionResult<Producto> EliminarProducto(int id)
        {
            //listaProducto.RemoveAt(id);
            return Ok(id);
        }
    }
}
