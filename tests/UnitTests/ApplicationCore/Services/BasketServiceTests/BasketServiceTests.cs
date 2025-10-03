using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;
using Moq;
using Xunit;

namespace UnitTests.ApplicationCore.Services
{
    public class BasketServiceTests
    {
        private readonly Mock<IRepository<Basket>> _mockBasketRepo;
        private readonly BasketService _basketService;

        public BasketServiceTests()
        {
            _mockBasketRepo = new Mock<IRepository<Basket>>();
            _basketService = new BasketService(_mockBasketRepo.Object);
        }

        [Fact]
        public async Task CreateBasketForUser_ReturnsBasket()
        {
            // Arrange
            string userId = "test-user";
            var basket = new Basket(userId);
            _mockBasketRepo.Setup(r => r.AddAsync(It.IsAny<Basket>()))
                .ReturnsAsync(basket);

            // Act
            var result = await _basketService.CreateBasketForUserAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.BuyerId);
        }
    }
}
