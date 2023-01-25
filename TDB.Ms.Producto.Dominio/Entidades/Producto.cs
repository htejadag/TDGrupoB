using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace TDB.Ms.Producto.Dominio.Entidades
{
    [BsonIgnoreExtraElements]
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
    }
}
