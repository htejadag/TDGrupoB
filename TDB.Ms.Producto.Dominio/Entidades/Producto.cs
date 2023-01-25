using MongoDB.Bson.Serialization.Attributes;
using TDB.Ms.Producto.Infraestructura.Common;

namespace TDB.Ms.Producto.Dominio.Entidades
{
    [CollectionName("producto")]
    [BsonIgnoreExtraElements]
    public class Producto : Base
    {
        public string nombre { get; set; }

        public decimal precio { get; set; }

        public int cantidad { get; set; }

        public List<Categoria> categorias { get; set; }
    }
}
