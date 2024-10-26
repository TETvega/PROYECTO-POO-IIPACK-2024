using InmobiliariaUNAH;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Database.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
var app = builder.Build(); 
startup.Configure(app, app.Environment);
// agregar el using

// momento donde estan cargados todos los servicios
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<InmobiliariaUNAHContext>();
        var userManager = services.GetRequiredService<UserManager<UserEntity>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await InmobiliariaUNAHSeeder.LoadDataAsync(context, loggerFactory, userManager, roleManager);

    }
    catch (Exception e)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(e, "Error ejecutar Seed de Datos");
    }
}

app.Run(); 