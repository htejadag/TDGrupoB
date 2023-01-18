using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using TDB.Ms.Producto.Infraestructura.DBRepository;
using TDB.Ms.Producto.Infraestructura.DBSettings;
using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Producto.Aplicacion.Producto.Read
{
    public class ProductoQueryAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Producto> _producto;

        public ProductoQueryAll()
        {
            _producto = _repository.db.GetCollection<dominio.Producto>("producto");
        }

        public IEnumerable<dominio.Producto> ListarProductos()
        {
            return _producto.Find(x => true).ToList();
        }
    }
}
