using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace TDB.Ms.Clientes.Dominio.Entidades
{
    [CollectionProperty("cliente")]
    [BsonIgnoreExtraElements]
    public class Cliente : EntityToLower<ObjectId>
    {
        public int idCliente { get; set; }

        public string tipoDocumento { get; set; }

        public string numeroDocumento { get; set; }

        public string nombres { get; set; }

        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }

        public string celular { get; set; }

    }
}
