using InmobiliariaUNAH.Database;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaUNAH
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        //Constructor de la clase Startup que recibe la configuración de la aplicación a través de IConfiguration.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //  método se utiliza para registrar SERVICIOS en el contenedor de dependencias
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // valida a nivel de controladores
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers().AddNewtonsoftJson(options => // Añadir Controladores con Newtonsoft.Json (del pack: Microsoft.AspNetCore.Mvc.NewtonsoftJson)
            {
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            // Add DbContext
            services.AddDbContext<InmobiliariaUNAHContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add custom services
            // services.AddTransient<ICategoriesService, CategoriesSQLService>();


            // Add AutoMapper

        }

        // método se utiliza para configurar el pipeline de solicitud HTTP de la aplicación
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // Configuracion del Middleware:
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
