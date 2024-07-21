using InmobiliariaUNAH.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace InmobiliariaUNAH.Database
{
    public class InmobiliariaUNAHSeeder
    {
        public static async Task LoadDataAsync(InmobiliariaUNAHContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                await LoadProductsAsync(loggerFactory, context);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHSeeder>();
                logger.LogError(e, "Error inicializando la data del API.");
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
                    //for (int i = 0; i < products.Count; i++) // actualiza propiedades de auditoría
                    //{
                    //    products[i].CreatedBy = "bcf446b1-700a-4478-bd5f-f0539c89d8e8";
                    //    products[i].CreatedDate = DateTime.Now;
                    //    products[i].UpdatedBy = "bcf446b1-700a-4478-bd5f-f0539c89d8e8";
                    //    products[i].UpdatedDate = DateTime.Now;
                    //}

                    context.AddRange(products); //  los está marcando para inyectar en la dataBase
                    await context.SaveChangesAsync(); // Guarda los cambios ya en la base de datos
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
