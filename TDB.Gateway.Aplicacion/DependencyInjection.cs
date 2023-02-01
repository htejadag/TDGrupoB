using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDB.Gateway.Aplicacion.Common;

namespace TDB.Gateway.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {            
            // Clientes
            services.AddClientes(configuration);

            return services;
        }

        public static IServiceCollection AddClientes(this IServiceCollection services, IConfiguration configuration)
        {
            //CLIENT_SETTINGS
            var msSettings = new ClientSettings();
            configuration.Bind(nameof(ClientSettings), msSettings);            

            #region Cliente Ms Productos

            services.AddHttpClient("MsProductos", client =>
            {
                client.BaseAddress = new Uri(msSettings.ProductosUrl);
            });

            #endregion

            return services;
        }
    }
}
