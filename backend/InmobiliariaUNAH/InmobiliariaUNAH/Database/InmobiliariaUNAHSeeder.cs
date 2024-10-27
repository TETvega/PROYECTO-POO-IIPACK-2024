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
        private static List<object> userClients = new List<object>
        {
            new { id = new Guid("ca738dbb-0c10-47b2-a1e7-f61e2e46f515"), name = "Marlon Lopez", email = "m_lopez@gmail.com" },
            new { id = new Guid("ee10a477-0bb1-4f24-851a-d275f187f5fd"), name = "Shalom Henriquez", email = "s_hqz2@gmail.com" },
            new { id = new Guid("8f5046cf-d8ee-49ac-a0b0-7b1328bde15f"), name = "Siscomp", email = "siscomp.hn@gmail.com" },
            new { id = new Guid("ca02aadc-05f1-453f-bf7b-c80562d52e55"), name = "Aire Frío", email = "aire.frio@gmail.com" },
            new { id = new Guid("720ce9c4-d31d-46bc-b45b-70ece08ece67"), name = "Municipalidad de Santa Rosa de Copán", email = "src_muni@gmail.com" },
            new { id = new Guid("c6a65998-231e-4355-bf67-536a243ccfae"), name = "Empresa Municipal Aguas de Santa Rosa", email = "gerencia@aguasdesantarosa.org" },
            new { id = new Guid("367ea698-7bb6-466f-9482-5a11427b22c0"), name = "Iglesia Menonita", email = "menonita_src@gmail.com" },
            new { id = new Guid("3027d32a-e2c5-4935-bfa4-b07a5708b980"), name = "Iglesia Católica de Santa Rosa", email = "e.cat_src@gmail.com" },
            new { id = new Guid("2f1d0ac0-e87b-4daf-b153-b4ba121d4d33"), name = "PILARH", email = "pilarh_hn@gmail.com" },
            new { id = new Guid("374756e0-ce74-4b67-ae49-89b1467a0c0e"), name = "Vision Fund", email = "vision_fund@gmail.com" }
        };




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

                await LoadClientsTypesAsync(loggerFactory, context);
                await LoadClientsAsync(loggerFactory, context);
              
                await LoadCategoriesProductAsync(loggerFactory, context);


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
                   
                    //int clientsAmount = 10; // cantidad de clientes

                    for (int i = 0; i < userClients.Count(); i++)
                    {
                        dynamic clientInfo = userClients[i]; // para poder acceder a las propiedades del objeto

                        var client = new UserEntity
                        {
                            Id = clientInfo.id.ToString(), 
                            Email = clientInfo.email,
                            UserName = clientInfo.email,
                            Name = clientInfo.name
                        };

                        await userManager.CreateAsync(client, "Temporal01*"); // crear usuario cliente
                        await userManager.AddToRoleAsync(client, RolesConstant.CLIENT); // asignar rol
                    }

                    var userAdmin1 = new UserEntity
                    {
                        Email = "admin@gmail.com",
                        UserName = "admin@gmail.com",
                        Name = "Héctor Martínez"
                    };

                    var userAdmin2 = new UserEntity
                    {
                        Email = "annerh3@gmail.com",
                        UserName = "annerh3@gmail.com",
                        Name = "Anner Henríquez"
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

        //Seed de Clientes
        public static async Task LoadClientsAsync(ILoggerFactory loggerFactory, InmobiliariaUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/clients.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var clients = JsonConvert.DeserializeObject<List<ClientEntity>>(jsonContent);

                if (!await context.Clients.AnyAsync())
                {
                    context.AddRange(clients);
                    await context.SaveChangesAsync();  
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHContext>();
                logger.LogError(e, "Error al ejecutar el Seed de Clientes.");
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
