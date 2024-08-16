using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Helpers;
using InmobiliariaUNAH.Services;
using InmobiliariaUNAH.Services.Interfaces;
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
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; // Esto le indica a Newtonsoft.Json que ignore las referencias cíclicas durante la serialización.
            });

            // Add DbContext
            services.AddDbContext<InmobiliariaUNAHContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add custom services
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryProductService, CategoryProductService>();
            services.AddTransient<INoteService, NotesService>();
            services.AddTransient<IClientTypeService, ClientTypeService>();
            services.AddTransient<IEventService, EventsService>();


            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
            // CORS Configuration
            services.AddCors(opt =>
            {
                var allowURLS = Configuration.GetSection("AllowURLS").Get<string[]>();

                opt.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins(allowURLS)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

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
            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
