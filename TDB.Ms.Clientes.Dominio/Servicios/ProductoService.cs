//using MongoDB.Driver;
//using TDB.Ms.Producto.Infraestructura.DBSettings;
//using dominio = TDB.Ms.Producto.Dominio.Entidades;

//namespace TDB.Ms.Producto.Dominio.Servicios
//{
//    public class ProductoService
//    {
//        private IMongoCollection<dominio.Producto> _producto;

//        public ProductoService(IDBSettings dBSettings)
//        {
//            var cliente = new MongoClient(dBSettings.Server);
//            var database = cliente.GetDatabase(dBSettings.Database);
//            _producto = database.GetCollection<dominio.Producto>(dBSettings.Collection);
//        }

//        public List<dominio.Producto> ListarProductos()
//        {
//            return _producto.Find(x => true).ToList();
//        }
//    }
//}
