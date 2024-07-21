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
                await LoadCategoriesProductAsync(loggerFactory, context);
                await LoadProductsAsync(loggerFactory, context);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<InmobiliariaUNAHSeeder>();
                logger.LogError(e, "Error inicializando la data del API.");
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
