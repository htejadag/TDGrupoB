using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDB.Ms.Producto.Dominio
{
    public class Document : IDocument, IDocument<Guid>
    {
        [BsonId]
        public Guid Id { get; set; }

        public DateTime AddedAtUtc { get; set; }

        public Document()
        {
            Id = Guid.NewGuid();
            AddedAtUtc = DateTime.UtcNow;
        }
    }
}
