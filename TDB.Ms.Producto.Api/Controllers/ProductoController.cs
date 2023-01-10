using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TDB.Ms.Producto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProducto")]
        public IEnumerable<Producto> Get()
        {
            List<Producto> listaProducto = new List<Producto>
            {
                new Producto
                {
                    IdProducto = new Guid(),
                    Nombre = "Arroz",
                    Cantidad = 100,
                    Precio = 5.5M
                },

                new Producto
                {
                    IdProducto = new Guid(),
                    Nombre = "Leche",
                    Cantidad = 80,
                    Precio = 4.4M
                }
            };

            return listaProducto;
        }
    }
}
