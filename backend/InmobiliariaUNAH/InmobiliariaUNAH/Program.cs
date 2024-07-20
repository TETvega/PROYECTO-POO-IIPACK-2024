using InmobiliariaUNAH;
using InmobiliariaUNAH.Database;

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
        // await InmobiliariaUNAHSeeder.LoasDataAsync(context, loggerFactory);

    }
    catch (Exception e)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(e, "Error ejecutar Seed de Datos");
    }


}

app.Run(); 