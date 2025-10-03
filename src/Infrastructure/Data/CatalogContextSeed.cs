using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.CatalogAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext context, ILogger<CatalogContextSeed> logger)
        {
            if (!context.CatalogBrands.Any())
            {
                logger.LogInformation("Seeding CatalogBrands...");
                context.CatalogBrands.AddRange(GetPreconfiguredCatalogBrands());
                await context.SaveChangesAsync();
            }

            if (!context.CatalogTypes.Any())
            {
                logger.LogInformation("Seeding CatalogTypes...");
                context.CatalogTypes.AddRange(GetPreconfiguredCatalogTypes());
                await context.SaveChangesAsync();
            }

            if (!context.CatalogItems.Any())
            {
                logger.LogInformation("Seeding CatalogItems...");
                context.CatalogItems.AddRange(GetPreconfiguredItems());
                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>
            {
                new CatalogBrand("Brand A"),
                new CatalogBrand("Brand B"),
                new CatalogBrand("Brand C")
            };
        }

        private static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>
            {
                new CatalogType("Type 1"),
                new CatalogType("Type 2"),
                new CatalogType("Type 3")
            };
        }

        private static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>
            {
                new CatalogItem(1, 1, "Item 1", "Description 1", 100, "https://placehold.co/600x400"),
                new CatalogItem(2, 2, "Item 2", "Description 2", 200, "https://placehold.co/600x400"),
                new CatalogItem(3, 3, "Item 3", "Description 3", 300, "https://placehold.co/600x400")
            };
        }
    }
}
