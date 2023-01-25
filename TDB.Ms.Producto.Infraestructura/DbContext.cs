using MongoDB.Driver;
using Release.MongoDB.Repository;

namespace TDB.Ms.Producto.Infraestructura
{
    public class DbContext : DataContext, IDbContext
    {
        public DbContext(MongoUrl mongoUrl) : base(mongoUrl)
        {
        }
    }
}
