using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.Api.Data;

//proxy patern -> cached basket repository acts as it, since the basket repostory object is wrapped around
//decorator -> as caching is implemented to already existing repo.
public class CachedBasketRepository(IBasketRepository repository, IDistributedCache cache) : IBasketRepository
{
    public async Task<bool> DeleteBasket(string userName)
    {
        await repository.DeleteBasket(userName);
        await cache.RemoveAsync(userName);
        return true;
    }

    public async Task<ShoppingCart> GetBasket(string userName)
    {
        var cachedBasket = await cache.GetStringAsync(userName);
        if (!string.IsNullOrEmpty(cachedBasket))
            return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket);

        var basket = await repository.GetBasket(userName);
        await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket));
        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket)
    {
        await repository.StoreBasket(basket);
        await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));
        return basket;
    }
}
