using System;
using Basket.Api.Exceptions;
using Marten;

namespace Basket.Api.Data;

public class BasketRepository : IBasketRepository
{
    private readonly IDocumentSession _session;

    public BasketRepository(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<ShoppingCart> GetBasket(string userName)
    {
        var data = await _session.LoadAsync<ShoppingCart>(userName);
        return data ?? throw new BasketNotFoundException(userName);
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket)
    {
        _session.Store<ShoppingCart>(basket);
        await _session.SaveChangesAsync();
        return basket;
    }
    public async Task<bool> DeleteBasket(string userName)
    {
        _session.Delete<ShoppingCart>(userName);
        await _session.SaveChangesAsync();
        return true;
    }
}
