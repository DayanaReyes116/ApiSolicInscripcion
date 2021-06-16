using ApiSolicInscripcion.ApiSolicitud.Middlewares;
using ApiSolicInscripcion.Core.Interfaces;
using ApiSolicInscripcion.Core.Interfaces.Repositories;
using ApiSolicInscripcion.Core.Interfaces.Services;
using ApiSolicInscripcion.Core.Models;
using ApiSolicInscripcion.Infrastructure.Data.Repositories;
using ApiSolicInscripcion.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ApiSolicInscripcion
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
            services.AddControllers();
            
            var connectionString = "Data Source = Solicitud.db";
            services.AddDbContext<SolicitudDbContext>(options => options.UseSqlite(connectionString));


            services.AddScoped<ISolicitudRepository, SolicitudRepository>();
            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<ISolicitudService, SolicitudService>();
            services.AddScoped<ILogService, LogService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Doc Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Colegio Magia y Hechiceria", Version = "v1" });

                //Set the comments path for the swagger Json an UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<RequestHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Enable Middleware to server generated Swagger as a Json Endoint
            app.UseSwagger();

            //Enable middleware to server swagger -ui )htm, js, css, etc)
            app.UseSwaggerUI(
            c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Colegio Hogwarts V2");
            }
            );
        }

    }
}
