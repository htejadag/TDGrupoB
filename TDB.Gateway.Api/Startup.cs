using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TDB.Gateway.Aplicacion;

namespace TDB.Gateway.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.InstallServicesAssembly(typeof(Startup).Assembly, Configuration, Environment);

            services.AddControllers(); 
            //services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Conexión a Base de Datos
            //services.Configure<DBSettings>(Configuration.GetSection("DBSettings"));
            //services.AddSingleton<IDBSettings>(x => x.GetRequiredService<IOptions<DBSettings>>().Value);
            services.AddAplicacion(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/",
                   async context =>
                   {
                       string color = env.IsDevelopment() ? "Gray" : "Green";
                       await context.Response.WriteAsync($"<h1 style='color:{color};'>[MS.Api] Environment: <a href='/swagger'>{env.EnvironmentName}</a></h1>");
                   });
            });
        }
    }
}
