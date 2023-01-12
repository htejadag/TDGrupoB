using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TDB.Ms.Producto.Api.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ProductoController : ControllerBase
    {
        private static List<Producto> listaProducto = new List<Producto>
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


        //[HttpGet(Name = "ListarProductos")]
        //public IEnumerable<Producto> ListarProductos()
        //{           
        //    return listaProducto;
        //}

        [HttpGet(Name = "BuscarProducto")]
        public Producto BuscarProducto(int id)
        {
            return listaProducto.Single(x => x.IdProducto == id);
        }

        [HttpPost(Name = "CrearProducto")]
        public ActionResult<Producto> CrearProducto(Producto producto)
        {
            producto.IdProducto = listaProducto.Count() + 1;
            listaProducto.Add(producto);
            return CreatedAtAction("CrearProducto", producto);
        }

        [HttpPut(Name = "ModificarProducto")]
        public ActionResult<Producto> ModificarProducto(Producto producto)
        {
            Producto productoModificado = listaProducto.Single(x => x.IdProducto == producto.IdProducto);
            productoModificado.Nombre = producto.Nombre;
            productoModificado.Cantidad = producto.Cantidad;
            productoModificado.Precio= producto.Precio;
            return CreatedAtAction("ModificarProducto", productoModificado);
        }

        [HttpDelete(Name = "EliminarProducto")]
        public ActionResult<Producto> EliminarProducto(int id)
        {
            listaProducto.RemoveAt(id);
            return Ok(id);
        }
    }
}
