using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TDB.Ms.Producto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private static readonly List<Producto> listaProducto = new List<Producto>
        {
            new Producto
            {
                IdProducto = 1,
                Nombre = "Arroz",
                Cantidad = 100,
                Precio = 5.5M
            },

            new Producto
            {
                IdProducto = 2,
                Nombre = "Leche",
                Cantidad = 80,
                Precio = 4.4M
            }
        };


        [HttpGet(Name = "GetProducto")]
        public IEnumerable<Producto> Get()
        {
            //List<Producto> listaProducto = new List<Producto>
            //{
            //    new Producto
            //    {
            //        IdProducto = new Guid(),
            //        Nombre = "Arroz",
            //        Cantidad = 100,
            //        Precio = 5.5M
            //    },

            //    new Producto
            //    {
            //        IdProducto = new Guid(),
            //        Nombre = "Leche",
            //        Cantidad = 80,
            //        Precio = 4.4M
            //    }
            //};

            return listaProducto;
        }

        [HttpPost(Name = "CrearProducto")]
        public ActionResult<Producto> CrearProducto(Producto producto)
        {
            producto.IdProducto = listaProducto.Count() + 1;
            listaProducto.Add(producto);
            return CreatedAtAction("CrearProducto", producto);
        }
    }
}
