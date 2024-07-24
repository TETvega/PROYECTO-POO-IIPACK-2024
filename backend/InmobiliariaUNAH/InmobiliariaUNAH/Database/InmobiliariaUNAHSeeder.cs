using InmobiliariaUNAH.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace InmobiliariaUNAH.Database
{
    public class InmobiliariaUNAHSeeder
    {
        /// <summary>
        ///  LOGER PRINCIPAL QUE CARGA LOS DEMAS 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="loggerFactory"></param>
        /// <returns></returns>
        public static async Task LoadDataAsync(InmobiliariaUNAHContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                await LoadCategoriesProductAsync(loggerFactory, context);
                await LoadClientsTypesAsync(loggerFactory, context);


                await LoadProductsAsync(loggerFactory, context);
                await LoadUsersAsync(loggerFactory, context);


                await LoadEventsAsync(loggerFactory, context);
                await LoadNotesAsync(loggerFactory, context);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHSeeder>();
                logger.LogError(e, "Error inicializando la data del API.");
            }

        }

        // aqui en adelante son los archivos a cargar
        //seed de los Users
        public static async Task LoadUsersAsync(ILoggerFactory loggerFactory, InmobiliariaUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/users.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var users = JsonConvert.DeserializeObject<List<UserEntity>>(jsonContent);

                if (!await context.Users.AnyAsync())
                {
                    context.AddRange(users);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHContext>();
                logger.LogError(e, "Error al ejecutar el Seed de Users");
            }
        }
        //seed de los eventos 
        public static async Task LoadEventsAsync(ILoggerFactory loggerFactory, InmobiliariaUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/events.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var events = JsonConvert.DeserializeObject<List<EventEntity>>(jsonContent);

                if (!await context.Events.AnyAsync())
                {
                    context.AddRange(events);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHContext>();
                logger.LogError(e, "Error al ejecutar el Seed de Eventos.");
            }
        }
        // seed de las Notas
        public static async Task LoadNotesAsync(ILoggerFactory loggerFactory, InmobiliariaUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/notes.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var notes = JsonConvert.DeserializeObject<List<NoteEntity>>(jsonContent);

                if (!await context.Notes.AnyAsync())
                {
                    context.AddRange(notes);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHContext>();
                logger.LogError(e, "Error al ejecutar el Seed de Notes.");
            }
        }
        public static async Task LoadClientsTypesAsync(ILoggerFactory loggerFactory, InmobiliariaUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/clientstypes.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var clientsTypes = JsonConvert.DeserializeObject<List<ClientTypeEntity>>(jsonContent);

                if (!await context.TypesOfClient.AnyAsync())
                {
                    context.AddRange(clientsTypes);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHContext>();
                logger.LogError(e, "Error al ejecutar el Seed de clientsTypes.");
            }
        }

        public static async Task LoadCategoriesProductAsync(ILoggerFactory loggerFactory, InmobiliariaUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/categoriesproduct.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath); 
                var categoriesproduct = JsonConvert.DeserializeObject<List<CategoryProductEntity>>(jsonContent);

                if (!await context.CategoryProducts.AnyAsync())
                {
                    context.AddRange(categoriesproduct); 
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHContext>();
                logger.LogError(e, "Error al ejecutar el Seed de categoriesProduct.");
            }
        }

        public static async Task LoadProductsAsync(ILoggerFactory loggerFactory, InmobiliariaUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/products.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath); // Lee el contenido completo del archivo JSON y lo almacena en 'jsonContent'.
                var products = JsonConvert.DeserializeObject<List<ProductEntity>>(jsonContent);
                
                if (!await context.Products.AnyAsync()) 
                {
                    

                    context.AddRange(products); 
                    await context.SaveChangesAsync(); 
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHContext>();
                logger.LogError(e, "Error al ejecutar el Seed de productos.");
            }
        }

    }
}
