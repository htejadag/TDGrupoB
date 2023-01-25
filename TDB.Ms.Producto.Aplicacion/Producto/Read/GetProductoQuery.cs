//using MongoDB.Driver;
//using TDB.Ms.Producto.Infraestructura.DBRepository;
//using dominio = TDB.Ms.Producto.Dominio.Entidades;

//namespace TDB.Ms.Producto.Aplicacion.Producto.Read
//{
//    public class GetProductoQuery
//    {
//        internal DBRepository _repository = new DBRepository();
//        private IMongoCollection<dominio.Producto> _producto;

//        public GetProductoQuery()
//        {
//            _producto = _repository.db.GetCollection<dominio.Producto>("producto");
//        }

//        public IEnumerable<dominio.Producto> ListarProductos()
//        {
//            return _producto.Find(x => true).ToList();
//        }
//    }
//}
