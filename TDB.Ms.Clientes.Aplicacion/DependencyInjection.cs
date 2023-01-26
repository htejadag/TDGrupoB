using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using TDB.Ms.Clientes.Aplicacion.Cliente;
using TDB.Ms.Clientes.Infraestructura;
using dominio = TDB.Ms.Clientes.Dominio.Entidades;

namespace TDB.Ms.Clientes.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration) 
        {
            #region Mongo

            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));

            //Entidades            
            services.TryAddScoped<ICollectionContext<dominio.Cliente>>(x => new CollectionContext<dominio.Cliente>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Cliente>>(x => new BaseRepository<dominio.Cliente>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IClienteService, ClienteService>();

            #endregion

            return services;
        }

    }
}
