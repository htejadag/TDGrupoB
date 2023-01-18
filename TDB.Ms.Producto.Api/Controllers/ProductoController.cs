﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using TDB.Ms.Producto.Api.Routes;
using TDB.Ms.Producto.Aplicacion.Read;
using static TDB.Ms.Producto.Api.Routes.ApiRoutes;
using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Producto.Api.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoQueryAll db = new ProductoQueryAll();
        
        [HttpGet(ApiRoutes.Producto.GetAll)]
        public IEnumerable<dominio.Producto> ListarProductos()
        {
            //var client = new MongoClient("mongodb://localhost:27017");
            //var database = client.GetDatabase("TDB_productos");
            //var dbProducto = database.GetCollection<dominio.Producto>("producto");

            //var listaProducto = dbProducto.Find(x => true).ToList();
            var listaProducto = db.ListarProductos();
            return listaProducto;
        }

        [HttpGet(ApiRoutes.Producto.GetById)]
        public dominio.Producto BuscarProducto(int id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDB_productos");
            var dbProducto = database.GetCollection<dominio.Producto>("producto");

            var objProducto = dbProducto.Find(x => x.IdProducto == id).FirstOrDefault();

            return objProducto;
        }

        [HttpPost(ApiRoutes.Producto.Create)]
        public ActionResult<dominio.Producto> CrearProducto(dominio.Producto producto)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDB_productos");
            var dbProducto = database.GetCollection<dominio.Producto>("producto");
            dbProducto.InsertOne(producto);
            //producto.IdProducto = listaProducto.Count() + 1;
            //listaProducto.Add(producto);
            return Ok();
        }

        [HttpPut(ApiRoutes.Producto.Update)]
        public ActionResult<dominio.Producto> ModificarProducto(dominio.Producto producto)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDB_productos");
            var dbProducto = database.GetCollection<dominio.Producto>("producto");

            dbProducto.FindOneAndReplace(x => x.IdProducto == producto.IdProducto, producto);

            //Producto productoModificado = listaProducto.Single(x => x.IdProducto == producto.IdProducto);
            //productoModificado.Nombre = producto.Nombre;
            //productoModificado.Cantidad = producto.Cantidad;
            //productoModificado.Precio= producto.Precio;
            //return CreatedAtAction("ModificarProducto", productoModificado);
            return Ok();
        }

        [HttpDelete(ApiRoutes.Producto.Delete)]
        public ActionResult<dominio.Producto> EliminarProducto(int id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDB_productos");
            var dbProducto = database.GetCollection<dominio.Producto>("producto");

            dbProducto.FindOneAndDelete(x => x.IdProducto == id);
            //listaProducto.RemoveAt(id);
            return Ok(id);
        }
    }
}
