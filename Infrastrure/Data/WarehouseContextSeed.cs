using System.Reflection;
using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastrure.Data
{
    public class WarehouseContextSeed
    {
        public static async Task SeedAsync(WarehouseContext context, ILoggerFactory loggerFactory)
        {
            try
            {

                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText(@"../Infrastrure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    context.ProductBrands.AddRange(brands);

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText(@"../Infrastrure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText(@"../Infrastrure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<WarehouseContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}