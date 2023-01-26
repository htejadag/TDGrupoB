using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TDB.Ms.Producto.Infraestructura.Context;

namespace TDB.Ms.Producto.Infraestructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            //BsonSerializer.RegisterSerializer(typeof(DateTime), new BsonUtcDateTimeSerializer());

            // Base de Datos MongoDb
            //var databaseSettings = new DBSettings();
            //configuration.Bind(nameof(DBSettings), databaseSettings);
            //services.AddScoped<IMongoDbContext>(x => new MongoDbContext(databaseSettings.Server, databaseSettings.Database));
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ICollectionContext, CollectionContext>();
            
            return services;
        }
    }
}
