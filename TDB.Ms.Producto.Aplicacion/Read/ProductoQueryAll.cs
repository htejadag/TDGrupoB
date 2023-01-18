using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDB.Ms.Producto.Infraestructura;
using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Producto.Aplicacion.Read
{
    public class ProductoQueryAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Producto> Collection;

        public ProductoQueryAll()
        {
            Collection = _repository.db.GetCollection<dominio.Producto>("producto");
        }

        public IEnumerable<dominio.Producto> ListarProductos()
        {
            return Collection.Find(x => true).ToList();
        }
    }
}
