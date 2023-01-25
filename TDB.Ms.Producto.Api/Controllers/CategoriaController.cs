using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TDB.Ms.Producto.Aplicacion.Categoria;
using static TDB.Ms.Producto.Api.Routes.ApiRoutes;
using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Categoria.Api.Controllers
{
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet(RouteCategoria.GetAll)]
        public IEnumerable<dominio.Categoria> ListarCategorias()
        {

            var listaCategoria = _service.ListarCategorias();
            return listaCategoria;
        }

        [HttpGet(RouteCategoria.GetById)]
        public dominio.Categoria BuscarCategoria(int id)
        {
            var objCategoria = _service.Categoria(id);

            return objCategoria;
        }

        [HttpPost(RouteCategoria.Create)]
        public ActionResult<dominio.Categoria> CrearCategoria([FromBody] dominio.Categoria producto)
        {
            _service.RegistrarCategoria(producto);

            return Ok();
        }

        //[HttpPut(RouteCategoria.Update)]
        //public ActionResult<dominio.Categoria> ModificarCategoria(dominio.Categoria producto)
        //{
        //    #region Conexión a base de datos
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("TDB_productos");
        //    var collection = database.GetCollection<dominio.Categoria>("producto");
        //    #endregion

        //    collection.FindOneAndReplace(x => x._id == producto._id, producto);

        //    //var oldCategoria = collection.Find(x => x.IdCategoria == producto.IdCategoria).FirstOrDefault();
        //    //oldCategoria.Nombre = producto.Nombre;
        //    //oldCategoria.Precio = producto.Precio;
        //    //oldCategoria.Cantidad = producto.Cantidad;
        //    //collection.ReplaceOne(x=>x.IdCategoria == oldCategoria.IdCategoria, oldCategoria);


        //    //Categoria productoModificado = listaCategoria.Single(x => x.IdCategoria == producto.IdCategoria);
        //    //productoModificado.Nombre = producto.Nombre;
        //    //productoModificado.Cantidad = producto.Cantidad;
        //    //productoModificado.Precio= producto.Precio;
        //    //return CreatedAtAction("ModificarCategoria", productoModificado);
        //    return Ok();
        //}

        [HttpDelete(RouteCategoria.Delete)]
        public ActionResult<dominio.Categoria> EliminarCategoria(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
