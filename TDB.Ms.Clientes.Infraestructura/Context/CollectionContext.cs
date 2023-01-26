using MongoDB.Bson;
using MongoDB.Driver;

namespace TDB.Ms.Producto.Infraestructura.Context
{
    public class CollectionContext : ICollectionContext
    {
        private readonly IMongoDbContext _context;

        public CollectionContext(IMongoDbContext context)
        {
            _context = context;
        }

        public IMongoCollection<BsonDocument> Context(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
            {
                throw new ArgumentNullException("collectionName");
            }

            return _context.Database.GetCollection<BsonDocument>(collectionName);
        }
    }
}
