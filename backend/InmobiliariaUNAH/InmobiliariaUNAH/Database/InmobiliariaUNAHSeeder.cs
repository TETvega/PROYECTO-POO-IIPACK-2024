using InmobiliariaUNAH.Constants;
using InmobiliariaUNAH.Database.Entities;
using Microsoft.AspNetCore.Identity;
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
        public static async Task LoadDataAsync(
            InmobiliariaUNAHContext context, 
            ILoggerFactory loggerFactory,
            UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            try
            {
                await LoadRolesAndUsersAsync(userManager, roleManager, loggerFactory);
              
                await LoadCategoriesProductAsync(loggerFactory, context);
                await LoadClientsTypesAsync(loggerFactory, context);


                await LoadProductsAsync(loggerFactory, context);

                await LoadEventsAsync(loggerFactory, context);
                await LoadNotesAsync(loggerFactory, context);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHSeeder>();
                logger.LogError(e, "Error inicializando la data del API.");
            }

        }

        public static async Task LoadRolesAndUsersAsync(
            UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager,
            ILoggerFactory loggerFactory
            )
        {
            try
            {
                if (!await roleManager.Roles.AnyAsync())
                {
                    await roleManager.CreateAsync(new IdentityRole(RolesConstant.ADMIN)); // creando roles
                    await roleManager.CreateAsync(new IdentityRole(RolesConstant.CLIENT));

                }

                if (!await userManager.Users.AnyAsync())
                {
                    var clientlUser = new UserEntity
                    {
                        Email = "user@blogunah.edu",
                        UserName = "user@blogunah.edu",
                    };

                    int clientsAmount = 5; // cantidad de clientes

                    List<UserEntity> clients = new List<UserEntity>();

                    //para crear n cantidad de empleados.  Anner
                    for (int i = 1; i <= clientsAmount; i++)
                    {
                        var client = new UserEntity
                        {
                            Email = $"client{i}@gmail.com",
                            UserName = $"client{i}@gmail.com",
                            FirstName = $"Cliente {i}",
                            LastName = "Prueba",
                        };

                        clients.Add(client);
                        await userManager.CreateAsync(client, "Temporal01*"); // crear usario cliente
                        await userManager.AddToRoleAsync(client, RolesConstant.CLIENT); // asignar rol
                    }

                    var userAdmin1 = new UserEntity
                    {
                        Email = "admin@gmail.com",
                        UserName = "admin@gmail.com",
                        FirstName = "Héctor",
                        LastName = "Martínez"
                    };

                    var userAdmin2 = new UserEntity
                    {
                        Email = "annerh3@gmail.com",
                        UserName = "annerh3@gmail.com",
                        FirstName = "Anner",
                        LastName = "Henríquez"
                    };

                    await userManager.CreateAsync(userAdmin1, "Temporal01*"); 
                    await userManager.CreateAsync(userAdmin2, "Temporal01*");

                    await userManager.AddToRoleAsync(userAdmin1, RolesConstant.ADMIN); 
                    await userManager.AddToRoleAsync(userAdmin2, RolesConstant.ADMIN);

                }

            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHSeeder>();
                logger.LogError(e.Message);
            }
        }

        // aqui en adelante son los archivos a cargar

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
