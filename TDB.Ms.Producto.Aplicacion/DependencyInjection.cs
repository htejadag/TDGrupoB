using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using TDB.Ms.Producto.Aplicacion.Categoria;
using TDB.Ms.Producto.Aplicacion.Producto;
using TDB.Ms.Producto.Infraestructura;
using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Producto.Aplicacion
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
            services.TryAddScoped<ICollectionContext<dominio.Producto>>(x => new CollectionContext<dominio.Producto>(x.GetService<IDbContext>()));
            services.TryAddScoped<ICollectionContext<dominio.Categoria>>(x => new CollectionContext<dominio.Categoria>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Producto>>(x => new BaseRepository<dominio.Producto>(x.GetService<IDbContext>()));
            services.TryAddScoped<IBaseRepository<dominio.Categoria>>(x => new BaseRepository<dominio.Categoria>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            #endregion

            return services;
        }

    }
}
