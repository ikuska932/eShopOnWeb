using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace UnitTests.Infrastructure
{
    public class EfRepositoryTest
    {
        private CatalogContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase(databaseName: "TestCatalogDb")
                .Options;

            return new CatalogContext(options);
        }

        [Fact]
        [Trait("Category", "Repository")]
        public async Task AddAsync_ShouldAddEntity()
        {
            
            var dbContext = GetDbContext();
            var repository = new EfRepository<CatalogBrand>(dbContext);

            var brand = new CatalogBrand { Brand = "TestBrand" };

            
            await repository.AddAsync(brand);
            await dbContext.SaveChangesAsync();

            
            var saved = await dbContext.CatalogBrands.FirstOrDefaultAsync(b => b.Brand == "TestBrand");
            Assert.NotNull(saved);
            Assert.Equal("TestBrand", saved.Brand);
        }

        [Fact]
        [Trait("Category", "Repository")]
        public async Task GetByIdAsync_ShouldReturnEntity_WhenExists()
        {
            
            var dbContext = GetDbContext();
            var repository = new EfRepository<CatalogBrand>(dbContext);

            var brand = new CatalogBrand { Brand = "ExistingBrand" };
            dbContext.CatalogBrands.Add(brand);
            await dbContext.SaveChangesAsync();

            
            var result = await repository.GetByIdAsync(brand.Id);

            
            Assert.NotNull(result);
            Assert.Equal("ExistingBrand", result.Brand);
        }
    }
}
