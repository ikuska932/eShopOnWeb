using Xunit;
using Microsoft.eShopWeb.ApplicationCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Services;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

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