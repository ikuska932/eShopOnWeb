using Xunit;
using ApplicationCore.Services;

public class BasketServiceTests
{
    [Fact]
    [Trait("Category", "Service")]
    public void CreateBasket_ShouldNotBeNull()
    {
        var service = new BasketService(null, null); 
        Assert.NotNull(service);
    }
}