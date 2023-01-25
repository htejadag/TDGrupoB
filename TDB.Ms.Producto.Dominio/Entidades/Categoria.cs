using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace TDB.Ms.Producto.Dominio.Entidades
{
    [CollectionProperty("categoria")]
    [BsonIgnoreExtraElements]
    public class Categoria : EntityToLower<ObjectId>
    {
        public int idCategoria { get; set; }
        public string nombre { get; set; }
    }
}
