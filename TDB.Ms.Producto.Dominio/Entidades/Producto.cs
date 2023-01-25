using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace TDB.Ms.Producto.Dominio.Entidades
{
    [CollectionProperty("producto")]
    [BsonIgnoreExtraElements]
    public class Producto : EntityToLower<ObjectId>
    {        
        public int idProducto { get; set; }

        public string nombre { get; set; }

        public decimal precio { get; set; }

        public int cantidad { get; set; }
    }
}
